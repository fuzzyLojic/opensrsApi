using System.Collections.Generic;

namespace OpenSRSLib
{
    public class AAAARecord : DnsRecord
    {
        public AAAARecord(string ipAddress, string subdomain = ""){
            ValidateIP(ipAddress);

            record = new Dictionary<string, string>(){
                {"ipv6_address", ipAddress},
                {"subdomain", subdomain}
            };
        }
    }
}