using System.Collections.Generic;

namespace OpenSRSLib
{
    public class TXTRecord : DnsRecord
    {
        /// <summary>
        /// TXT Record.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subdomain">can be left out</param>
        public TXTRecord(string text, string subdomain = ""){
            this.Type = "TXT";
            this.Text = text;
            this.SubDomain = subdomain;
            
            record = new Dictionary<string, string>(){
                {"text", text},
                {"subdomain", subdomain}
            };
        }
    }
}