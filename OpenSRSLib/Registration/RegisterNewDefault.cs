using System.Collections.Generic;

namespace OpenSRSLib
{
    // "reg_type" = new
    public class RegisterNewDefault : Register
    {
        public RegisterNewDefault(string domain, ushort period, ContactSet owner, ContactSet admin = null, ContactSet billing = null, ContactSet tech = null, List<string> nameserverList = null)
        {
            this.domain = domain;
            this.period = period;
            this.owner = owner;
            this.nameserverList = nameserverList;
            this.admin = admin;
            this.billing = billing;
            this.tech = tech;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("sw_register");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"reg_type", "new"},
                {"reg_username", userInfo.Username},
                {"reg_password", userInfo.Password},
                {"period", period.ToString()},
                {"handle", handle},
                {"auto_renew", autoRenew.ToString()},
                {"f_lock_domain", fLockDomain.ToString()},
                {"contact_set", ""}
            };

            if(nameserverList != null){
                attributes.Add("custom_nameservers", "1");
                attributes.Add("nameserver_list", "");
            }
            else{
                attributes.Add("custom_nameservers", "0");
            }

            Dictionary<string, string> contacts = new Dictionary<string, string>(){
                {"owner", ""},
                {"admin", ""},
                {"billing", ""}
            };

            if(tech != null){
                attributes.Add("custom_tech_contact", "1");
                contacts.Add("tech", "");
            }

            doc.AddItemList("attributes", "dt_assoc", attributes);
            doc.AddItemList("contact_set", "dt_assoc", contacts);
            doc.AddItemList("owner", "dt_assoc", owner.Set);

            if(admin != null){
                doc.AddItemList("admin", "dt_assoc", admin.Set);
            }
            else{
                doc.AddItemList("admin", "dt_assoc", owner.Set);
            }

            if(billing != null){
                doc.AddItemList("billing", "dt_assoc", billing.Set);
            }
            else{
                doc.AddItemList("billing", "dt_assoc", owner.Set);
            }

            if(tech != null){
                doc.AddItemList("tech", "dt_assoc", tech.Set);
            }
            else{
                doc.AddItemList("tech", "dt_assoc", owner.Set);
            }

            if(nameserverList != null){
                Dictionary<string, string> ns = new Dictionary<string, string>();
                for(int i = 0; i < nameserverList.Count; i++){
                    ns.Add(i.ToString(), "");
                }

                doc.AddItemList("nameserver_list", "dt_array", ns);

                for(int i = 0; i < nameserverList.Count; i++){
                    doc.AddItemList(i.ToString(), "dt_assoc", new Dictionary<string, string>(){
                        {"name", nameserverList[i]},
                        {"sortorder", (i + 1).ToString()}
                    });
                }
            }

            return doc.XDocString;
        }
    }
}