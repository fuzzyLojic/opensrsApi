using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenSRSLib
{
    public class MXRecord : DnsRecord
    {

        public string HostName { get; set; }
        public string Priority { get; set; }
        public string SubDomain { get; set; }

        /// <summary>
        /// MX Record.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="priority"></param>
        /// <param name="subdomain">can be left out</param>
        public MXRecord(string hostname, ushort priority, string subdomain = ""){
            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"priority", priority.ToString()},
                {"subdomain", subdomain}
            };
        }

        [JsonConstructor]
        public MXRecord(string hostname, string priority, string subdomain = ""){
            this.HostName = hostname;
            this.Priority = priority;
            this.SubDomain = subdomain;
            
            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"priority", priority.ToString()},
                {"subdomain", subdomain}
            };
        }
    }
}