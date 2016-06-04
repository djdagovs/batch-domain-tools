using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BatchDomainTools.WebNet
{
    /// <summary>
    /// TODO: перенисти класс 
    /// </summary>
    public static class WebNetCommunication
    {
        public static HttpWebRequest BuildGetRequest(Uri _addr, WebSession _session) 
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            if (_session.querySessionVars != null && _session.querySessionVars.Count > 0) 
            {
                _addr = new Uri(string.Format("{0}&{1}", _addr.AbsoluteUri, _session.GetCombinedVars()));
            }
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_addr);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.Method = "GET";
            if (Setting.SettingInstance.Proxy != null && Setting.SettingInstance.Proxy.Address!=null)
                httpWebRequest.Proxy = Setting.SettingInstance.Proxy;
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.KeepAlive = false;
            if (_session.sessionHeader!= null && _session.sessionHeader.Count>0)
                httpWebRequest.Headers.Add(_session.sessionHeader);
            if (_session.sessionCookie != null && _session.sessionCookie.Count>0)
                httpWebRequest.CookieContainer = _session.sessionCookie;
            httpWebRequest.Timeout = Setting.SettingInstance.HttpReadWriteTimeout;
            return httpWebRequest;
        }

        public struct WebSession 
        {
            public CookieContainer sessionCookie { get; set; }
            public Dictionary<string, string> querySessionVars { get; set; }
            public WebHeaderCollection sessionHeader { get; set; }
            /*public WebSession(CookieCollection _sessionCookie, Dictionary<string, string> _querySessionVars, WebHeaderCollection _sessionHeader) 
            {
                this.sessionCookie = _sessionCookie;
                this.querySessionVars = _querySessionVars;
                this.sessionHeader = _sessionHeader;
            }*/
            public string GetCombinedVars() 
            {
                string CombinedVars = string.Empty;
                foreach (KeyValuePair<string,string> keyValue in querySessionVars) 
                {
                    CombinedVars += string.Format("{0}={1}&", keyValue.Key, keyValue.Value);
                }
                return CombinedVars.TrimEnd('&');
            }
        }
    }
}
