using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.ISubDomainActions
{
    public interface ISubDomainGet : IWebPanelBasicActions.IGet
    {
        /// <summary>
        /// Метод получает список доменов, и заносить его в переданный список 
        /// </summary>
        /// <param name="DomainName">Объект домена для добавления</param>
        /// <returns>статус выполнения операции</returns>
        new BatchDomainTools.WebPanelActionResult.ActionResultBase Get(BatchDomainTools.WebPanelItems.WebPanelItemCollection saveCollection);
        /// <summary>
        /// Метод проверяет существует ли указаный объект в панели управления
        /// </summary>
        /// <returns></returns>
        BatchDomainTools.WebPanelActionResult.ActionResultBase Exist(BatchDomainTools.WebPanelItems.SubDomainItem SubDomain2Check);
    }
}
