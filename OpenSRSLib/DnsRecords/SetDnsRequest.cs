using System;
using System.Collections.Generic;

namespace OpenSRSLib
{
    public class SetDnsRequest : Request<SetDnsResponse>
    {
        private string action;

        private string domain;
        private DnsZone records;

        /// <summary>
        /// Set a DNS Zone file
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="records"></param>
        public SetDnsRequest(string domain, DnsZone records)
        {
            this.domain = domain;
            this.records = records;
            CheckNew();
            xml = BuildXML();
        }

        protected override string BuildXML(){
            XmlDoc doc = new XmlDoc(action);
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"records", ""},
                {"nameservers_ok", "1"}
            };

            doc.AddItemList("attributes", "dt_assoc", attributes);

            Dictionary<string, List<DnsRecord>> temp = new Dictionary<string, List<DnsRecord>>();
            


            if(records.A != null){
                temp.Add("A", records.A.ConvertAll(x => (DnsRecord)x));
            }

            if(records.AAAA != null){
                temp.Add("AAAA", records.AAAA.ConvertAll(x => (DnsRecord)x));
            }

            if(records.CName != null){
                temp.Add("CNAME", records.CName.ConvertAll(x => (DnsRecord)x));
            }

            if(records.MX != null){
                temp.Add("MX", records.MX.ConvertAll(x => (DnsRecord)x));
            }

            if(records.TXT != null){
                temp.Add("TXT", records.TXT.ConvertAll(x => (DnsRecord)x));
            }

            if(records.SRV != null){
                temp.Add("SRV", records.SRV.ConvertAll(x => (DnsRecord)x));
            }

            Dictionary<string, string> recordTypes = new Dictionary<string, string>();

            foreach (var item in temp)
            {
                recordTypes.Add(item.Key, "");
            }

            doc.AddItemList("records", "dt_assoc", recordTypes);

            foreach (var item in temp)
            {
                AddRecordTypeList(doc, item.Key, item.Value);
            }

            return doc.XDocString;
        }


        private void AddRecordTypeList(XmlDoc doc, string type, List<DnsRecord> records){
            Dictionary<string, string> recordsType = new Dictionary<string, string>();
            for(int i = 0; i < records.Count; i++){
                recordsType.Add(i.ToString(), "");
            }

            doc.AddItemList(type, "dt_array", recordsType);

            for(int i = 0; i < records.Count; i++){
                doc.AddItemSubList(type, i.ToString(), "dt_assoc", records[i].Record);
            }
        }

        // if GetDnsRequest is invalid, no dns zone exists and a new one
        // must be created
        // if it is valid, we set it with the new values
        private void CheckNew(){
            GetDnsRequest req = new GetDnsRequest(domain);
            action = req.Post().IsValid ? "set_dns_zone" : "create_dns_zone";
            return;
        }
    }
}