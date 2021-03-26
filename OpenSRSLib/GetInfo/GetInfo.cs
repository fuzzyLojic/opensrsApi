namespace OpenSRSLib
{
    public class GetInfo<T> : Request<T>
    {
        protected string domain;
        protected bool activeContactsOnly;    // optional: gets ACTIVE contacts regardless of transfer status
        protected bool cleanCaSubset;         // optional
        protected ushort limit;               // optional: list - max number of domains to return per page
        protected ushort page;                // optional: list - determines page the index starts at

        // type options: all_info, admin, billing, ca_whois_display_setting, domain_auth_info,
        //      expire_action, forwarding_email, list, nameservers, owner, rsp_whois_info,
        //      status, tech, tld_data, waiting_history, whois_privacy_state
    }
}