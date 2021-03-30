using System.Collections.Generic;

namespace OpenSRSLib
{
    public class ARecord : DnsRecord
    {
        /// <summary>
        /// A record. Must be IPv4
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="subdomain">can be left out</param>
        public ARecord(string ipAddress, string subdomain = ""){
            ValidateIP(ipAddress);
            this.Type = "A";
            this.IpAddress = ipAddress;
            this.SubDomain = subdomain;

            record = new Dictionary<string, string>(){
                {"ip_address", ipAddress},
                {"subdomain", subdomain}
            };
        }
    }
}