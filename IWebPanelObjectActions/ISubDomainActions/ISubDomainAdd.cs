using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.ISubDomainActions
{
    public interface ISubDomainAdd : IWebPanelBasicActions.IAdd
    {
        /// <summary>
        /// Метод добавляет переданный объект в панель управления хостингом
        /// </summary>
        /// <param name="DomainName">Объект для добавления</param>
        /// <returns>статус выполнения операции</returns>
        BatchDomainTools.WebPanelActionResult.ActionResultBase Add(BatchDomainTools.WebPanelItems.SubDomainItem SubDomain2Add, BatchDomainTools.WebPanelOptionData.IOptionData properties);
    }
}
