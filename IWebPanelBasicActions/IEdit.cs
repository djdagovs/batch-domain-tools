using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelOptionData;

namespace BatchDomainTools.IWebPanelBasicActions
{
    public interface IEdit
    {
        /// <summary>
        /// Метод меняет опции у переданного объект в панель управления хостингом
        /// </summary>
        /// <param name="DomainName">Объект для изменения</param>
        /// <returns>статус выполнения операции</returns>
        ActionResultBase Edit(WebPanelItemBase editObject, IOptionData propertie);
    }
}
