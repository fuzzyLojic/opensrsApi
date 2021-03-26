using System.Text.Json;

namespace OpenSRSLib
{
    public class SetDnsResponse : Response
    {
        /// <summary>
        /// Indicates whether the domain is set up to use the OpenSRS nameservers.
        /// </summary>
        /// <value>0 - Not native NS, 1 - Native NS</value>
        public string NameserversOk { get; set; }

        public DnsZone Records { get; set; }

        public override void Process(string json)
        {
            base.Process(json);
            if (!Success) { return; }

            SetDnsResponse data = JsonSerializer.Deserialize<SetDnsResponse>(Attributes.ToString(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            this.NameserversOk = data.NameserversOk;
            this.Records = data.Records;

            return;
        }
    }
}