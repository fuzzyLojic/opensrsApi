using System.Collections.Generic;

namespace OpenSRSLib
{
    public class DnsZone : Request
    {
        protected string domain;
        protected List<ARecord> aRecords;
        protected List<AAAARecord> aaaaRecords;
        protected List<CNameRecord> cNames;
        protected List<MXRecord> mxRecords;
        protected List<TXTRecord> txtRecords;
        protected List<SRVRecord> srvRecords;
    }
}