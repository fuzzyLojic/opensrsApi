using System;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography; // for MD5 encryption
using System.Threading.Tasks;       // needed for Task object for PostAsync
using System.Net.Http;


namespace OpenSRSLib
{
    public class Request
    {
        public static bool isInTestMode = true;
        protected static Connection connectionDetails = GetConnectionDetails();
        protected string xml;

        public string XML { 
            get
            { 
                return xml;
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

        // takes Request results XML string and returns a Dictionary
        // of key names and values
        // ex: <item key="moop">floop</item> returns
        // { "moop", "floop" }
        // override to do additional processing
        protected virtual Dictionary<string, string> ProcessedResults(string results){
            return XmlDoc.ProcessResponse(results);
        }          


        // perform MD5 hash on input string
        protected static string MD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }


        public async Task<Dictionary<string, string>> Post()
        {        
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(this.xml);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
                content.Headers.Add("X-Username", connectionDetails.ResellerUsername);
                content.Headers.Add("X-Signature", this.Signature);
                content.Headers.ContentLength = this.xml.Length;

                HttpResponseMessage response = await client.PostAsync(connectionDetails.ApiHostPort, content);
                string results = await response.Content.ReadAsStringAsync();

                client.Dispose();
                return ProcessedResults(results);
            }
            catch (Exception e)
            {
                ErrorHandling("Oops! Post broke...\n" + e, 0);
                return new Dictionary<string, string>();
            }
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

        public static void ErrorHandling(string error, short errorCode){
            Console.WriteLine($"{error}\n\nError Code: {errorCode}");
            System.Environment.Exit(errorCode);
        }
    }
}