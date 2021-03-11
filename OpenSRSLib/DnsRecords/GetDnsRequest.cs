using System.Collections.Generic;
using System.Text.RegularExpressions;

// Returns DNS information for requested domain

namespace OpenSRSLib
{
    public class GetDnsRequest : DnsZone
    {
        private bool isValid;   // domain is in account and has DNS info

        public bool IsValid { 
            get{
                return isValid;
            }
        }

        public GetDnsRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("get_dns_zone");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            return doc.XDocString;
        }

        // Request returns "not found" if domain does not have DNS information
        // or "Authentication Error" if domain is not in account
        protected override void Preprocessing(string results)
        {
            isValid = (!Regex.Match(results, @"not found").Success && !Regex.Match(results, @"Authentication Error").Success);
            base.Preprocessing(results);
        }
    }
}