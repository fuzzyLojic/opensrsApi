using System.Collections.Generic;

namespace OpenSRSLib
{
    public class AAAARecord : DnsRecord
    {
        public string IpAddress { get; set; }
        public string SubDomain { get; set; }
        
        /// <summary>
        /// AAAA record. Must be IPv6
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="subdomain">can be left out</param>
        public AAAARecord(string ipAddress, string subdomain = ""){
            ValidateIP(ipAddress);
            this.IpAddress = ipAddress;
            this.SubDomain = subdomain;

            record = new Dictionary<string, string>(){
                {"ipv6_address", ipAddress},
                {"subdomain", subdomain}
            };
        }


    }
}