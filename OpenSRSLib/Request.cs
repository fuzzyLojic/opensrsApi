using System;
using System.Text;
using System.Text.Json;             // for connection information
using System.IO;                    // for connection information
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography; // for MD5 encryption
using System.Threading.Tasks;       // needed for Task object for PostAsync
using System.Net.Http;
using System.Net;
using System.Reflection;


namespace OpenSRSLib
{
    public abstract class Request<T>
    {
        protected static bool isInTestMode = ApiSettings.IsInTestMode;
        protected static Connection connectionDetails = GetConnectionDetails();
        protected string xml;
        protected T response;

        /// <summary>
        /// review xml request doc before Posting
        /// </summary>
        /// <value></value>
        public string XML { 
            get => xml;
        }

        /// <summary>
        /// Response object. Type dependant on Request class
        /// </summary>
        /// <value></value>
        public T Response { 
            get => response;
            set{}
        }

        // OpenSRS API IS CASE SENSITIVE FOR THE HASH AUTHENTICATION!!
        protected string Signature {
            get => MD5Hash(MD5Hash(this.xml + connectionDetails.ApiKey).ToLower() + connectionDetails.ApiKey).ToLower();
        }

        // XML document is assemebled differently depending on type of request
        // Override this function in request object decendants to return their completed
        //      xml request document
        protected virtual string BuildXML(){
            return xml;
        }

        
        // perform MD5 hash on input string
        protected string MD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }

        // used to process Post results further before returning
        protected virtual void Preprocessing(string results){
            string json = XmlDoc.ToJson(results);
            response = JsonSerializer.Deserialize<T>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            // use reflection to find Process method of Response and derived    
            MethodInfo res = typeof(T).GetMethod("Process");
            object[] args = { json };
            res.Invoke(response, args);
            return;
        }

        /// <summary>
        /// Post of Request object: does not block
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <returns>Task object with Response property</returns>
        public async Task PostAsync(HttpClient client)
        {        
            string results;
            StringContent content = new StringContent(this.xml);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
            content.Headers.Add("X-Username", connectionDetails.ResellerUsername);
            content.Headers.Add("X-Signature", this.Signature);
            content.Headers.ContentLength = this.xml.Length;

            try
            {
                HttpResponseMessage response = await client.PostAsync(connectionDetails.ApiHostPort, content);
                results = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                ErrorHandling("Oops! Post broke...\nIs your IP whitelisted in live mode?\n" + e, 5);
                results = "";
            }

            Preprocessing(results);  // use results before returning to requestor
            
            return;
        }

        /// <summary>
        /// Post of Request object: does block
        /// </summary>
        /// <returns>Response class or derived. Dependant on Request type</returns>
        public T Post(){            
            try
            {
                HttpClient client = new HttpClient();
                PostAsync(client).Wait();
                client.Dispose();
            }
            catch (Exception e)
            {
                ErrorHandling("Trouble establishing HttpClient?\n" + e, 5);
            }
            
            return this.Response;
        }   

        // get reseller username, api host port, and api key from connection.json
        protected static Connection GetConnectionDetails()
        {
            var connectionOptions = GetConnectionInfo();  
            if (isInTestMode)
            {
                return connectionOptions.First(x => x.Id == "test");
            }
            else
            {
                return connectionOptions.First(x => x.Id == "live");    // IP must be white listed
            }
        }

        // helper function to get account information from file
        protected static IEnumerable<Connection> GetConnectionInfo(){
            using (var jsonFileReader = File.OpenText("OpenSRSLib/AccountInformation/connection.json"))
            {
                return JsonSerializer.Deserialize<Connection[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {  // these settings are optional
                    PropertyNameCaseInsensitive = true
                });
            }
        }


        protected async Task<string> GetPublicIP(){
            string ipRequest;
            if(isInTestMode){
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync("http://icanhazip.com");
                    ipRequest = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    ErrorHandling("Oops! GetIP broke...\n" + e, 5);
                    return "";
                }
            }
            else{   /****** TODO: needs testing ******/
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                ipRequest = ipAddress.ToString();
            }

            return ipRequest.Replace("\n", "").Replace("\r", "");
        }

        /// <summary>
        /// Get outward facing IP address. Used in some requests.
        /// </summary>
        /// <returns>IP address string</returns>
        public string GetIp(){
            Task<string> ip = GetPublicIP();
            return ip.Result.ToString();
        }


        public static void ErrorHandling(string error, short errorCode){
            Console.WriteLine($"{error}\n\nError Code: {errorCode}");
            System.Environment.Exit(errorCode);
        }
    }
}