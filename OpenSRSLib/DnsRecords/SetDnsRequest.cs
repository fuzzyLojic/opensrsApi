using System.Collections.Generic;

namespace OpenSRSLib
{
    public class SetDnsRequest : DnsZone
    {
        private string action;

        public SetDnsRequest(string domain, List<ARecord> aRecords, List<AAAARecord> aaaaRecords, List<CNameRecord> cNames, List<MXRecord> mxRecords, List<TXTRecord> txtRecords, List<SRVRecord> srvRecords)
        {
            this.domain = domain;
            this.aRecords = aRecords;
            this.aaaaRecords = aaaaRecords;
            this.cNames = cNames;
            this.mxRecords = mxRecords;
            this.txtRecords = txtRecords;
            this.srvRecords = srvRecords;
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
            
            if(aRecords != null){
                temp.Add("A", aRecords.ConvertAll(x => (DnsRecord)x));
            }

            if(aaaaRecords != null){
                temp.Add("AAAA", aaaaRecords.ConvertAll(x => (DnsRecord)x));
            }

            if(cNames != null){
                temp.Add("CNAME", cNames.ConvertAll(x => (DnsRecord)x));
            }

            if(mxRecords != null){
                temp.Add("MX", mxRecords.ConvertAll(x => (DnsRecord)x));
            }

            if(txtRecords != null){
                temp.Add("TXT", txtRecords.ConvertAll(x => (DnsRecord)x));
            }

            if(srvRecords != null){
                temp.Add("SRV", srvRecords.ConvertAll(x => (DnsRecord)x));
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
            req.Post();
            action = req.IsValid ? "set_dns_zone" : "create_dns_zone";
        }
    }
}