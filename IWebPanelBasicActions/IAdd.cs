using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;

namespace BatchDomainTools.IWebPanelBasicActions
{
    public interface IAdd
    {
        /// <summary>
        /// Метод добавляет переданный объект в панель управления хостингом
        /// </summary>
        /// <param name="DomainName">Объект для добавления</param>
        /// <returns>статус выполнения операции</returns>
        ActionResultBase Add(WebPanelItemBase addObject, BatchDomainTools.WebPanelOptionData.IOptionData properties);
    }
}
