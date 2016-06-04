using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.cPanel.Items
{
    public class cPanel_Domain : WebPanelItems.DomainItem
    {
        #region << ctor >>

        public cPanel_Domain(XmlNode dataNode) : base(dataNode["domain"].InnerText)
        {
            this.ExtViewData = new System.Collections.Specialized.NameValueCollection();
            foreach (XmlElement element in dataNode) 
            {
                this.ExtViewData.Add(element.Name, element.InnerText);
            }
        }

        public cPanel_Domain(WebPanelItems.DomainItem domain) : base(domain.Name) { }

        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            List<System.Windows.Forms.ColumnHeader> headers = new List<System.Windows.Forms.ColumnHeader>(WebPanelItems.DomainItem.ToListViewColumnHeader());
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "Каталог документов" });
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

        #endregion
    }
}
