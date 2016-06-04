using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;

namespace BatchDomainTools.IWebPanelBasicActions
{
    public interface IGet
    {
        /// <summary>
        /// Метод получает список доменов, и заносить его в переданный список 
        /// </summary>
        /// <param name="DomainName">Объект домена для добавления</param>
        /// <returns>статус выполнения операции</returns>
        ActionResultBase Get(WebPanelItemCollection saveCollection);
        /// <summary>
        /// Метод проверяет существует ли указаный объект в панели управления
        /// </summary>
        /// <returns></returns>
        ActionResultBase Exist(WebPanelItemBase panelObject);
    }
}
