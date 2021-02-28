using System.Collections.Generic;

namespace OpenSRSLib
{
    public class CNameRecord : DnsRecord
    {
        public CNameRecord(string hostname, string subdomain = ""){
            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"subdomain", subdomain}
            };
        }
    }
}