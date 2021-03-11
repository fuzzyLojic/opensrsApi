using System.Collections.Generic;
using System.Text.RegularExpressions;

// Returns all information associated with a domain
// Returns "Authentication Error" if searched domain is not in account

namespace OpenSRSLib
{
    public class GetAllInfoRequest : GetInfo
    {
        private bool isValid;   // requested domain is in account

        public bool IsValid { 
            get{
                return isValid;
            }
        }

        public GetAllInfoRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("GET");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"type", "all_info"}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            doc.AddTopLevelItem("registrant_ip", this.GetIp());

            return doc.XDocString;
        }

        // A Get all_info request returns "Authentication Error"
        // if the requested Domain is not in account
        protected override void Preprocessing(string results)
        {
            isValid = !Regex.Match(results, @"Authentication Error").Success;
            base.Preprocessing(results);
        }
    }
}