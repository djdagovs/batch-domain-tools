using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace BatchDomainTools.WebPanelModules.DirectAdmin.Items
{
    public class DirectAdmin_Domain : WebPanelItems.DomainItem
    {
        public DirectAdmin_Domain(string DomainName, NameValueCollection initNameValue)
            : base(DomainName, initNameValue)  { }
        public override System.Windows.Forms.ListViewItem ToListViewItem()
        {
            System.Windows.Forms.ListViewItem item = base.ToListViewItem();
            item.SubItems.AddRange(new string[] 
            {
                this.ExtViewData["ip"], this.ExtViewData["php"], this.ExtViewData["cgi"], this.ExtViewData["ssl"]
            });
            return item;
        }

        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            List<System.Windows.Forms.ColumnHeader> headers = new List<System.Windows.Forms.ColumnHeader>(WebPanelItems.DomainItem.ToListViewColumnHeader());
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "IP адрес домена" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "PHP Доступ" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "CGI Доступ" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "SSL Доступ" });
            return headers.ToArray();
        }
    }
}
