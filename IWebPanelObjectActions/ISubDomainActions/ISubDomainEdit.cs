using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.ISubDomainActions
{
    public interface ISubDomainEdit : IWebPanelBasicActions.IEdit
    {
        /// <summary>
        /// Метод меняет оцпии у переданного объект в панель управления хостингом
        /// </summary>
        /// <param name="DomainName">Объект для изменения</param>
        /// <returns>статус выполнения операции</returns>
        BatchDomainTools.WebPanelActionResult.ActionResultBase Edit(BatchDomainTools.WebPanelItems.SubDomainItem SubDomain2Edit, BatchDomainTools.WebPanelOptionData.IOptionData properties);
    }
}
