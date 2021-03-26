using System.Collections.Generic;

namespace OpenSRSLib
{
    public class TXTRecord : DnsRecord
    {
        public string Text { get; set; }
        public string SubDomain { get; set; }

        /// <summary>
        /// TXT Record.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subdomain">can be left out</param>
        public TXTRecord(string text, string subdomain = ""){
            this.Text = text;
            this.SubDomain = subdomain;
            
            record = new Dictionary<string, string>(){
                {"text", text},
                {"subdomain", subdomain}
            };
        }
    }
}