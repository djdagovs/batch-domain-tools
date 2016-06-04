using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.cPanel.Items
{
    public class cPanel_SubDomain : BatchDomainTools.WebPanelItems.SubDomainItem
    {
        public cPanel_SubDomain(XmlNode dataNode) : base(dataNode["rootdomain"].InnerText, dataNode["subdomain"].InnerText)
        {
            this.ExtViewData = new System.Collections.Specialized.NameValueCollection();
            foreach (XmlElement element in dataNode)
            {
                this.ExtViewData.Add(element.Name, element.InnerText);
            }
        }

        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            List<System.Windows.Forms.ColumnHeader> headers = new List<System.Windows.Forms.ColumnHeader>(WebPanelItems.SubDomainItem.ToListViewColumnHeader());
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "Каталог документов поддомена" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "Перенаправление" });
            return headers.ToArray();
        }

        public override System.Windows.Forms.ListViewItem ToListViewItem()
        {
            System.Windows.Forms.ListViewItem item = base.ToListViewItem();
            item.SubItems.Add(base.ExtViewData["basedir"]);
            item.SubItems.Add(base.ExtViewData["status"]);
            if (base.ExtViewData["status"] != "not redirected")
                item.ImageIndex = 0;
            return item;
        }
        
    }
}
