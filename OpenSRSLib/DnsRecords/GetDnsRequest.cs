using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenSRSLib
{
    public class GetDnsRequest : DnsZone
    {
        private bool isValid;

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

        protected override void Preprocessing(string results)
        {
            isValid = !Regex.Match(results, @"not found").Success;
        }
    }
}