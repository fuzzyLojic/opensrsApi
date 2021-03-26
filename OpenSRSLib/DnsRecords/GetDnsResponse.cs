using System;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace OpenSRSLib
{
    public class GetDnsResponse : Response
    {
        /// <summary>
        /// Indicates if a zone file exists
        /// </summary>
        /// <value>0 - does not exist, 1 - does exist</value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Indicates whether the domain is set up to use the OpenSRS nameservers.
        /// </summary>
        /// <value>0 - Not native NS, 1 - Native NS</value>
        public string NameserversOk { get; set; }

        public DnsZone Records { get; set; }

        public override void Process(string json)
        {
            base.Process(json);
            IsValid = !Regex.Match(ResponseText, @"not found").Success;
            if (!IsValid) { return; }
            if (!Success) { return; }

            GetDnsResponse data = JsonSerializer.Deserialize<GetDnsResponse>(Attributes.ToString(),
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