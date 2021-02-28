using System.Collections.Generic;

namespace OpenSRSLib
{
    public class ARecord : DnsRecord
    {
        public ARecord(string ipAddress, string subdomain = ""){
            ValidateIP(ipAddress);

            record = new Dictionary<string, string>(){
                {"ip_address", ipAddress},
                {"subdomain", subdomain}
            };
        }
    }
}