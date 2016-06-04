using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.IDomainActions
{
    public interface IDomainEdit : IWebPanelBasicActions.IEdit
    {
        /// <summary>
        /// Метод меняет оцпии у переданного объект в панель управления хостингом
        /// </summary>
        /// <param name="DomainName">Объект для изменения</param>
        /// <returns>статус выполнения операции</returns>
        BatchDomainTools.WebPanelActionResult.ActionResultBase Edit(BatchDomainTools.WebPanelItems.DomainItem Domain2Edit, BatchDomainTools.WebPanelOptionData.IOptionData properties);
    }
}
