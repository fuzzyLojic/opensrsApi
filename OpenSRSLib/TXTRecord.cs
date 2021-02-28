using System.Collections.Generic;

namespace OpenSRSLib
{
    public class TXTRecord : DnsRecord
    {
        public TXTRecord(string text, string subdomain = ""){
            record = new Dictionary<string, string>(){
                {"text", text},
                {"subdomain", subdomain}
            };
        }
    }
}