using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.ISPmanager.Items
{
    public class ISPmanager_Domain: DomainItem
    {
        #region << ctor >>
        public ISPmanager_Domain(XmlNode elementNode): base(elementNode["name"].InnerText)
        {
            this.ExtViewData = new System.Collections.Specialized.NameValueCollection();
            foreach (XmlElement element in elementNode)
            {
                this.ExtViewData.Add(element.Name, string.IsNullOrEmpty(element.InnerText) ? "On" : element.InnerText);
            }
        }
        #endregion

        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            List<System.Windows.Forms.ColumnHeader> headers = new List<System.Windows.Forms.ColumnHeader>(WebPanelItems.DomainItem.ToListViewColumnHeader());
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "Каталог документов" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "IP адрес" });
            headers.Add(new System.Windows.Forms.ColumnHeader() { Text = "Поддержка PHP" });
            return headers.ToArray();
        }

        public override System.Windows.Forms.ListViewItem ToListViewItem()
        {
            System.Windows.Forms.ListViewItem item = base.ToListViewItem();
            if (base.ExtViewData != null)
            {
                item.SubItems.Add(base.ExtViewData["docroot"]);
                item.SubItems.Add(base.ExtViewData["ip"]);
                switch (base.ExtViewData["php"])
                {
                    case "phpnone":
                        item.SubItems.Add("Нет поддержки PHP");
                        break;
                    case "phpmod":
                        item.SubItems.Add("PHP как модуль Apache");
                        break;
                    case "phpcgi":
                        item.SubItems.Add("PHP как CGI");
                        break;
                    case "phpfcgi":
                        item.SubItems.Add("PHP как FastCGI");
                        break;
                    case "On":
                        goto case "phpmod";
                    default :
                        goto case "phpnone";
                }
            }
            return item;
        }
    }
}
