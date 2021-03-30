using System.Collections.Generic;

namespace OpenSRSLib
{
    public class AAAARecord : DnsRecord
    {        
        /// <summary>
        /// AAAA record. Must be IPv6
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="subdomain">can be left out</param>
        public AAAARecord(string ipAddress, string subdomain = ""){
            ValidateIP(ipAddress);
            this.Type = "AAAA";
            this.IpAddress = ipAddress;
            this.SubDomain = subdomain;

            record = new Dictionary<string, string>(){
                {"ipv6_address", ipAddress},
                {"subdomain", subdomain}
            };
        }


    }
}