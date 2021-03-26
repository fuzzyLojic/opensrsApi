using System.Collections.Generic;

namespace OpenSRSLib
{
    public class DnsZone
    {
        public List<ARecord> A { get; set; }
        public List<AAAARecord> AAAA { get; set; }
        public List<CNameRecord> CName { get; set; }
        public List<MXRecord> MX { get; set; }
        public List<TXTRecord> TXT { get; set; }
        public List<SRVRecord> SRV { get; set; }


        /// <summary>
        /// Create new Zone file and assign individual record lists afterward
        /// </summary>
        public DnsZone(){}

        /// <summary>
        /// Create new Zone file with already created record lists
        /// </summary>
        /// <param name="aRecords">can be null</param>
        /// <param name="aaaaRecords">can be null</param>
        /// <param name="cnameRecords">can be null</param>
        /// <param name="mxRecords">can be null</param>
        /// <param name="txtRecords">can be null</param>
        /// <param name="srvRecords">can be null</param>
        public DnsZone(List<ARecord> aRecords, List<AAAARecord> aaaaRecords, List<CNameRecord> cnameRecords, List<MXRecord> mxRecords, List<TXTRecord> txtRecords, List<SRVRecord> srvRecords){
            this.A = aRecords;
            this.AAAA = aaaaRecords;
            this.CName = cnameRecords;
            this.MX = mxRecords;
            this.TXT = txtRecords;
            this.SRV = srvRecords;
        }
    }
}