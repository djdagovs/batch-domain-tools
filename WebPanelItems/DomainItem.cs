using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelOptionData;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BatchDomainTools.WebPanelItems
{
    public class DomainItem: WebPanelItemBase
    {
        #region << Поля и свойства >>

        public override string Name { get; protected set; }

        #endregion

        #region << ctor >>

        public DomainItem(string _name) : base(System.Web.HttpUtility.HtmlDecode(System.Web.HttpUtility.UrlDecode(PunyEncode(_name)))) { }
        public DomainItem(string _name, System.Collections.Specialized.NameValueCollection _extViewData)
            : this(_name)
        {
            this.ExtViewData = _extViewData;
        }

        #endregion

        #region << Методы >>

        public override System.Windows.Forms.ListViewItem ToListViewItem()
        {
            System.Windows.Forms.ListViewItem lsItem = new System.Windows.Forms.ListViewItem( PunyDecode(Name) );
            return lsItem;
        }
        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            return new System.Windows.Forms.ColumnHeader[]
            {
                new System.Windows.Forms.ColumnHeader()  { Text = "Имя домена" },
            };
        }

        public static string PunyEncode(string Domain)
        {
            if (!String.IsNullOrEmpty(Domain) && new Regex("[^a-z0-9\\-\\.]", RegexOptions.IgnoreCase).IsMatch(Domain))
            {
                try
                {
                    return new IdnMapping().GetAscii(Domain.Trim());
                }
                catch { }
            }
            return Domain;
        }

        public static string PunyDecode(string Domain)
        {
            if (!String.IsNullOrEmpty(Domain) && Domain.StartsWith("xn"))
            {
                try
                {
                    Domain = new IdnMapping().GetUnicode(Domain.Trim());
                }
                catch { }
            }
            return Domain;
        }

        #endregion

    }
}
