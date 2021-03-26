using System.Collections.Generic;

// Emails EPP to registered Admin contact

namespace OpenSRSLib
{
    public class AuthCodeRequest : Request<Response>
    {
        private string domain;

        /// <summary>
        /// Sends email to Account Owner with Transfer Authorization code (EPP)
        /// </summary>
        /// <param name="domain"></param>
        public AuthCodeRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("send_authcode");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain_name", domain}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            return doc.XDocString;
        }
    }
}