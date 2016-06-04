
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BatchDomainTools.WebPanelMisc
{
    public static class StrHelpClass
    {
        public static string GetSubstring(string input, string forStr, string toStr) 
        {
            if (!string.IsNullOrEmpty(input)) 
            {
                int begin = input.IndexOf(forStr);
                if (begin != -1) 
                {
                    begin += forStr.Length;
                    int end = input.IndexOf(toStr, begin);
                    if (end == -1)
                        end = input.Length;
                    return input.Substring(begin, end - begin);
                }
            }
            return null;
        }
   
        /// <summary>
        /// Возвращает строку URL в качестве списка KeyValuePair, допускаются дубликаты по имени аргументов 
        /// </summary>
        public static List<KeyValuePair<string, string>> ToKeyValueURLString(string input, bool HttpUrlDecode) 
        {
            List<KeyValuePair<string, string>> separated = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrEmpty(input)) 
            {
                foreach (string urlNameValues in  input.Split(new char[]{ '&' }, StringSplitOptions.RemoveEmptyEntries ) ) 
                {
                   string[] NameValueVar = urlNameValues.Split('=');
                   if (NameValueVar.Length == 2)
                   {
                       if (HttpUrlDecode)
                       {
                           NameValueVar[0] = HttpUtility.UrlDecode(HttpUtility.HtmlDecode(NameValueVar[0]));
                           NameValueVar[1] = HttpUtility.UrlDecode(HttpUtility.HtmlDecode(NameValueVar[1]));
                       }
                       separated.Add(new KeyValuePair<string, string>(NameValueVar[0], NameValueVar[1]));
                   }
                }
            }
            return separated;
        }
        /// <summary>
        /// Возвращает строку URL в качестве списка KeyValuePair, допускаются дубликаты по имени аргументов 
        /// </summary>
        public static List<KeyValuePair<string, string>> ToKeyValueURLString(string input)
        { 
          return  ToKeyValueURLString(input, false);
        }

        /// <summary>
        /// Возвращает строку URL в качестве списка NameValueCollection, дубликаты по имени аргументов не допускаются 
        /// </summary>
        public static System.Collections.Specialized.NameValueCollection ToNameValueURLString(string input, bool HttpUrlDecode)
        {
            System.Collections.Specialized.NameValueCollection separated = new System.Collections.Specialized.NameValueCollection();
            if (!string.IsNullOrEmpty(input))
            {
                foreach (string urlNameValues in input.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] NameValueVar = urlNameValues.Split('=');
                    if (NameValueVar.Length == 2)
                    {
                        if (HttpUrlDecode)
                        {
                            NameValueVar[0] = HttpUtility.UrlDecode(HttpUtility.HtmlDecode(NameValueVar[0]));
                            NameValueVar[1] = HttpUtility.UrlDecode(HttpUtility.HtmlDecode(NameValueVar[1]));
                        }
                        separated.Add(NameValueVar[0], NameValueVar[1]);
                    }
                }
            }
            return separated;
        }

        public static System.Collections.Specialized.NameValueCollection ToNameValueURLString(string input)
        {
          return  ToNameValueURLString(input, false);
        }
    }
}
