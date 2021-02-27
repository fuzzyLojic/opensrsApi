using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

// Determines the availablity of a domain
namespace OpenSRSLib
{
    public class Register : Request
    {
        protected string domain;
        protected ContactSet owner;       // required
        protected ContactSet admin;
        protected ContactSet billing;
        protected ContactSet tech;
        // protected short customTechContact;    // required 0 = use reseller tech contact, 1 = use tech contact provided
        protected string handle = "process";     // required "save" - pend order for later, "process" proceed with order immediately
        protected short period = 1;          // required for new domain reg.: 1-10
        protected static User userInfo = GetUserDetails();
        // protected string regUsername;     // required
        // protected string regPassword;     // required
        // protected string regType;         // required for domain reg. [new, transfer, landrush, premium, sunrise]
        // protected short customNameservers;    // optional 0 = user reseller default NS, 1 = use nameserverList
        protected List<string> nameserverList;  // conditional requirement

        protected string affiliateId;     // optional
        protected string authInfo;        // optional
        protected short autoRenew = 1;    // optional 0 = do not auto-renew, 1 = do auto-renew
        protected short changeContact;    // optional
        protected string comments;        // optional
        protected short customTransferNameservers;    // optional        
        protected string dnsTemplate;     // optional
        protected string encodingType;    // optional
        protected short fLockDomain = 1;      // optional 0 = do not lock, 1 = do lock
        protected char fParkp;            // optional Y or N
        protected string fWhoisPrivacy;   // optional
        protected string legalType;       // conditional requirement for .ca
        protected short linkDomains;      // optional
        protected string masterOrderId;   // conditional requirement
        protected string premiumPriceToVerify; // optional
        protected string regDomain;       // optional
        protected string tldData;         // conditional requirement for certain TLDs
        protected string tradeMarkSMD;    // conditional requirement for Sunrise orders


        // get reseller username and password from userinfo.json
        protected static User GetUserDetails()
        {
            var userOptions = GetUserInfo();  
            if (isInTestMode)
            {
                return userOptions.First(x => x.Id == "test");
            }
            else
            {
                return userOptions.First(x => x.Id == "live");    // IP must be white listed
            }
        }

        protected static IEnumerable<User> GetUserInfo(){
            using (var jsonFileReader = File.OpenText("OpenSRSLib/AccountInformation/userinfo.json"))
            {
                return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {  // these settings are optional
                    PropertyNameCaseInsensitive = true
                });
            }
        }


        
    }
}