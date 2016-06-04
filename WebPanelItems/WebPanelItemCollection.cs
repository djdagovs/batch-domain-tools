using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelItems
{
    public class WebPanelItemCollection : List<WebPanelItemBase>
    {
        // TODO: Заменить на struct или строку
        public Type CollectionType { get; private set; }

        public WebPanelItemCollection(Type typeOfCollection) 
        {
            if (typeOfCollection == null) 
            {
                throw new ArgumentNullException("typeOfCollection");
            }
            this.CollectionType = typeOfCollection;
        }

        public WebPanelItemCollection SelectRange(IEnumerable<int> list) 
        {
            WebPanelItemCollection collection = new WebPanelItemCollection(this.CollectionType);
            collection.AddRange(from n in list select this[n]);
            return collection;
        }

        public string[] ToStringArray()
        {
            string[] array = null;
            if (this.Count > 0) 
            {
                array = new string[this.Count];
                for(int index = 0; index <  this.Count; index++)
                {
                    array[index] = this[index].Name; 
                }
            }
            return array;
        }
    }
}
