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

        protected static string xml;
        // XML document is assemebled differently depending on type of request
        // Override this property in request objects to return their completed
        //      xml request document
        protected virtual string Xml {
            get {
                return xml;
            }
        }        

        protected static string signature;
        // OpenSRS API IS CASE SENSITIVE FOR THE HASH AUTHENTICATION!!
        protected string Signature {
            get {
                signature = MD5Hash(MD5Hash(this.Xml + connectionDetails.ApiKey).ToLower() + connectionDetails.ApiKey).ToLower();
                return signature;
            }
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


        public async Task Post()
        {        
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(this.Xml);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
                content.Headers.Add("X-Username", connectionDetails.ResellerUsername);
                content.Headers.Add("X-Signature", this.Signature);
                content.Headers.ContentLength = this.Xml.Length;

                var response = await client.PostAsync(connectionDetails.ApiHostPort, content);
                string results = await response.Content.ReadAsStringAsync();

                Console.WriteLine(response);
                Console.WriteLine("results: \n" + results);

                client.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // get reseller username, api host port, and api key from connection.json
        public static Connection GetConnectionDetails()
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

        public static IEnumerable<Connection> GetConnectionInfo(){
            using (var jsonFileReader = File.OpenText("OpenSRSLib/AccountInformation/connection.json"))
            {
                return JsonSerializer.Deserialize<Connection[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {  // these settings are optional
                    PropertyNameCaseInsensitive = true
                });
            }
        }
    }
}