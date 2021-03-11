using System.Collections.Generic;

namespace OpenSRSLib
{
    public class UnlockRequest : Modify
    {
        public UnlockRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("modify");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"affect_domains", affectDomains.ToString()},
                {"data", "status"},
                {"lock_state", "0"}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            return doc.XDocString;
        }
    }
}