using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace BatchDomainTools.WebPanelItems
{
    public abstract class WebPanelItemBase
    {
        public virtual string Name { get; protected set; }
        /// <summary>
        /// Дополнительные данные объекта веб-панели
        /// </summary>
        public NameValueCollection ExtViewData { get; protected set; }
        public WebPanelItemBase(string _name)
        {
            if (string.IsNullOrEmpty(_name)) 
                throw new ArgumentNullException("_name");
            this.Name = _name;
        }
        public abstract System.Windows.Forms.ListViewItem ToListViewItem();
        public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader() { return null; }
        public override bool Equals(object obj)
        {
            return Equals(obj as WebPanelItemBase);
        }
        public bool Equals(WebPanelItemBase obj)
        {
            if (obj == null)
                return false;
            return obj.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase);
        }
        public override int GetHashCode()
        {
            return this.Name.ToLower().GetHashCode();
        }
    }
}
