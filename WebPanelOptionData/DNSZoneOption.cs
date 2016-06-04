using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BatchDomainTools.WebPanelOptionData
{
    public enum DNSZoneTypes
    {
        A, AAAA, CNAME, DNAME, NS, MX, TXT, SRV, PTR
    }
    public struct DNSZoneOption 
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DNSZoneTypes TypeValue { get; set; }
    }
}
