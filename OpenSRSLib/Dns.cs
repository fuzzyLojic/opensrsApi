using System.Collections.Generic;

namespace OpenSRSLib
{
    public class Dns : Request
    {
        protected string domain;
        protected List<ARecord> aRecords;
        protected List<AAAARecord> aaaaRecords;
        protected List<CName> cNames;
        protected List<MXRecord> mxRecords;
        protected List<SRVRecord> srvRecords;
        protected List<string> txtRecords;
    }
}