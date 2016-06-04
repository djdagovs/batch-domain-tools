using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelItems
{
    public class SubDomainItem : DomainItem
    {
        #region << Поля и свойства >>
        /// <summary>
        /// Имя субдомена
        /// </summary>
        public string SubDomainName { get; private set; }
        /// <summary>
        /// Корневой домен
        /// </summary>
        public string RootDomain  { get; private set; }

        #endregion

        #region << Ctor >>

        public SubDomainItem(string _rootDomainName, string _subDomainName)
            : base( _subDomainName + "." + _rootDomainName)
        {
            if (string.IsNullOrEmpty(_rootDomainName))
                throw new ArgumentNullException("_rootDomainName", "Root domain can't be empty");
            this.RootDomain = _rootDomainName;
            this.SubDomainName = _subDomainName;
        }

        #endregion

        #region << Методы >>

        public override System.Windows.Forms.ListViewItem ToListViewItem()
        {
            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(new string[] 
            {
                  this.SubDomainName, this.RootDomain
            });
            return item;
        }
        new public static System.Windows.Forms.ColumnHeader[] ToListViewColumnHeader()
        {
            return new System.Windows.Forms.ColumnHeader[]
            {
                new System.Windows.Forms.ColumnHeader()  { Text = "Имя поддомена" },
                new System.Windows.Forms.ColumnHeader()  { Text = "Имя корневого домена"},
            };
        }

        public static SubDomainItem FindAndMake(string FullName, WebPanelItemCollection topDomainList) 
        {
           SubDomainItem foundSubDomain = null;
           if(!string.IsNullOrEmpty(FullName))
           {
               for (int lastPos = 0; lastPos<topDomainList.Count; lastPos++)
               {
                   WebPanelItemBase topDomainNow = topDomainList[lastPos];
                   int pos = FullName.Length - topDomainNow.Name.Length;
                   if (pos <= 1) 
                       continue;
                   pos = FullName.IndexOf(topDomainNow.Name, (pos - 1)) - 1;
                   if (pos > 0 && FullName[pos] == '.') 
                   {
                       foundSubDomain = new SubDomainItem(topDomainNow.Name, FullName.Substring(0, pos));
                       topDomainList.RemoveAt(lastPos);
                       topDomainList.Insert(0,topDomainNow);
                       break;
                   }
               }
           }
           return foundSubDomain;
        }

        #endregion
    }
}
