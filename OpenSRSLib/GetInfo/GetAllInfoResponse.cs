using System.Collections.Generic;
using System.Text.Json;

namespace OpenSRSLib
{
    public class GetAllInfoResponse : Response
    {
        public string AutoRenew { get; set; }
        public string RegistryCreateDate { get; set; }
        public string RegistryExpireDate { get; set; }
        public string RegistryUpdateDate { get; set; }
        public string AffiliateId { get; set; }
        public string SponsoringRsp { get; set; }
        public string ExpireDate { get; set; }
        public string LetExpire { get; set; }
        public Dictionary<string, ContactSet> ContactSet { get; set; }
        public List<NameServer> NameserverList { get; set; }

        public override void Process(string json)
        {
            base.Process(json);
            if(!Success){ return; }

            GetAllInfoResponse data = JsonSerializer.Deserialize<GetAllInfoResponse>(Attributes.ToString(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            this.AutoRenew = data.AutoRenew;
            this.RegistryCreateDate = data.RegistryCreateDate;
            this.RegistryExpireDate = data.RegistryExpireDate;
            this.RegistryUpdateDate = data.RegistryUpdateDate;
            this.AffiliateId = data.AffiliateId;
            this.SponsoringRsp = data.SponsoringRsp;
            this.ExpireDate = data.ExpireDate;
            this.LetExpire = data.LetExpire;
            this.ContactSet = data.ContactSet;
            this.NameserverList = data.NameserverList;
        }

        // public GetAllInfoResponse(string IsSuccess, string ResponseCode, string ResponseText, JsonElement Attributes)
        // {
        //     this.IsSuccess = IsSuccess;
        //     this.ResponseCode = ResponseCode;
        //     this.ResponseText = ResponseText;
        //     if(!Success){ return; }
        //     else{
        //         this.Attributes = Attributes;
        //         CheckAttributePropValue("autorenew", value => this.AutoRenew = value);
        //         CheckAttributePropValue("registrycreatedate", value => this.RegistryCreateDate = value);
        //         CheckAttributePropValue("registryexpiredate", value => this.RegistryExpireDate = value);
        //         CheckAttributePropValue("registryupdatedate", value => this.RegistryUpdateDate = value);
        //         CheckAttributePropValue("affiliateid", value => this.AffiliateId = value);
        //         CheckAttributePropValue("sponsoringrsp", value => this.SponsoringRsp = value);
        //         CheckAttributePropValue("expiredate", value => this.ExpireDate = value);
        //         CheckAttributePropValue("letexpire", value => this.LetExpire = value);
        //         CheckAttributePropValue("contactset", value => this.ContactSet = JsonSerializer.Deserialize<Dictionary<string, ContactSet>>(value));
        //         CheckAttributePropValue("nameserverlist", value => this.NameserverList = JsonSerializer.Deserialize<List<NameServer>>(value));
        //     }
        // }
    }
}