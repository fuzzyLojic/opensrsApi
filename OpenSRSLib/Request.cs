using System;
using System.Text;
using System.Xml.Linq;              // just to return an XDocument from Post
using System.Text.Json;             // for connection information
using System.IO;                    // for connection information
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography; // for MD5 encryption
using System.Threading.Tasks;       // needed for Task object for PostAsync
using System.Net.Http;
using System.Net;


namespace OpenSRSLib
{
    public class Request
    {
        public static bool isInTestMode = true;
        protected static Connection connectionDetails = GetConnectionDetails();
        protected string xml;
        protected Response response;

        // review xml request doc before Posting
        public string XML { 
            get
            { 
                return xml;
            }
        }

        public Response Response { 
            get
            {
                return response;
            }
        }

        // OpenSRS API IS CASE SENSITIVE FOR THE HASH AUTHENTICATION!!
        protected string Signature {
            get {
                return MD5Hash(MD5Hash(this.xml + connectionDetails.ApiKey).ToLower() + connectionDetails.ApiKey).ToLower();
            }
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
            response = XmlDoc.CreateResponse(results);
            return;
        }

        // internal use: actual Post of Request object
        public async Task PostRequest()
        {        
            string results;
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(this.xml);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
                content.Headers.Add("X-Username", connectionDetails.ResellerUsername);
                content.Headers.Add("X-Signature", this.Signature);
                content.Headers.ContentLength = this.xml.Length;

                HttpResponseMessage response = await client.PostAsync(connectionDetails.ApiHostPort, content);
                results = await response.Content.ReadAsStringAsync();

                client.Dispose();
            }
            catch (Exception e)
            {
                ErrorHandling("Oops! Post broke...\nIs your IP whitelisted in live mode?" + e, 5);
                results = "";
                // return "";
            }

            Preprocessing(results);  // use results before returning to requestor
            // return this.Response;
            // return results;
            return;
        }

        // external use: used to have Request object Posted
        public void Post(){
            PostRequest().Wait();
            return;
            // return this.Response;
            // return task.Result.ToString();
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
            else{
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                ipRequest = ipAddress.ToString();
            }

            return ipRequest.Replace("\n", "").Replace("\r", "");
        }

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