using System.Collections.Generic;

namespace OpenSRSLib
{
    public class Modify<T> : Request<T>
    {
        protected string domain;
        protected ushort affectDomains = 0;
        protected string data;
        // protected List<string> tld_data; //TODO
    }
}