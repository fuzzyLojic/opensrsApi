using System;
using System.Text.Json;

namespace OpenSRSLib
{
    public class LookupResponse : Response
    {
        public string Status { get; set; }
        public string Reason { get; set; }

        /// <summary>
        /// Applies to .Name domains only
        /// </summary>
        /// <value>0 or 1</value>
        public string EmailAvailable { get; set; }

        /// <summary>
        /// Returned for the new TLDs during the claims period (90 days from the start of GA)
        /// Indicates whether the domain name has a matching mark registered at the Trademark Clearinghouse (TMCH)
        /// </summary>
        /// <value>0 or 1</value>
        public string HasClaim { get; set; }

        /// <summary>
        /// Applies to .Name domains
        /// Indicates Registry Agent availability. If RA is available, noservice does not appear in response.
        /// </summary>
        /// <value>0 or 1</value>
        public string NoService { get; set; }

        /// <summary>
        /// Pricing status
        /// </summary>
        /// <value>Undef — Non .TV domains, Fixed — Price is fixed for .TV domains</value>
        public string PriceStatus { get; set; }

        
        public override void Process(string json)
        {
            base.Process(json);
            if(!Success){ return; }
            
            LookupResponse data = JsonSerializer.Deserialize<LookupResponse>(Attributes.ToString(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            this.Status = data.Status;
            this.Reason = data.Reason;
            this.EmailAvailable = data.EmailAvailable;
            this.HasClaim = data.HasClaim;
            this.NoService = data.NoService;
            this.PriceStatus = data.PriceStatus;

            return;
        }
    }
}