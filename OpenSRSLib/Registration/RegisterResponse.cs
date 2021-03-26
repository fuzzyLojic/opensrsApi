using System.Collections.Generic;
using System.Text.Json;

namespace OpenSRSLib
{
    public class RegisterResponse : Response
    {
        public string AdminEmail { get; set; }
        public string AyncReason { get; set; }
        public List<string> CancelledOrders { get; set; }
        public string Error { get; set; }
        public string ForcedPending { get; set; }
        public string Id { get; set; }
        public string QueueRequestId { get; set; }
        public string RegistrationCode { get; set; }
        public string RegistrationText { get; set; }
        public string TransferId { get; set; }
        public string WhoisPrivacyState { get; set; }

        public override void Process(string json){
            base.Process(json);
            if(!Success){ return; }

            RegisterResponse data = JsonSerializer.Deserialize<RegisterResponse>(Attributes.ToString(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            
            this.AdminEmail = data.AdminEmail;
            this.AyncReason = data.AyncReason;
            this.CancelledOrders = data.CancelledOrders;
            this.Error = data.Error;
            this.ForcedPending = data.ForcedPending;
            this.Id = data.Id;
            this.QueueRequestId = data.QueueRequestId;
            this.RegistrationCode = data.RegistrationCode;
            this.RegistrationText = data.RegistrationText;
            this.TransferId = data.TransferId;
            this.WhoisPrivacyState = data.WhoisPrivacyState;
        }
    }
}