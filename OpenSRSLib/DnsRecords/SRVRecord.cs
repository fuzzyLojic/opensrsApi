using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenSRSLib
{
    public class SRVRecord : DnsRecord
    {
        public string HostName { get; set; }
        public string Priority { get; set; }
        public string Weight { get; set; }
        public string Port { get; set; }
        public string SubDomain { get; set; }


        /// <summary>
        /// SRV Record.
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="priority"></param>
        /// <param name="weight"></param>
        /// <param name="port"></param>
        /// <param name="subdomain">required</param>
        public SRVRecord(string hostName, ushort priority, ushort weight, ushort port, string subdomain){
            record = new Dictionary<string, string>(){
                {"hostname", hostName},
                {"priority", priority.ToString()},
                {"weight", weight.ToString()},
                {"port", port.ToString()},
                {"subdomain", subdomain}
            };
        }

        [JsonConstructor]
        public SRVRecord(string hostName, string priority, string weight, string port, string subdomain){
            this.HostName = hostName;
            this.Priority = priority;
            this.Weight = weight;
            this.Port = port;
            this.SubDomain = subdomain;
            record = new Dictionary<string, string>(){
                {"hostname", hostName},
                {"priority", priority},
                {"weight", weight},
                {"port", port},
                {"subdomain", subdomain}
            };
        }
    }
}