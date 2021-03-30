using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenSRSLib
{
    public class SRVRecord : DnsRecord
    {
        /// <summary>
        /// SRV Record.
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="priority"></param>
        /// <param name="weight"></param>
        /// <param name="port"></param>
        /// <param name="subdomain">required</param>
        public SRVRecord(string hostName, ushort priority, ushort weight, ushort port, string subdomain){
            this.Type = "SRV";
            this.HostName = hostName;
            this.Priority = priority.ToString();
            this.Weight = weight.ToString();
            this.Port = port.ToString();
            this.SubDomain = subdomain;
            
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
            this.Type = "SRV";
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