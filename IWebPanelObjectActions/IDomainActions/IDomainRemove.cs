using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.IDomainActions
{
    public interface IDomainRemove : IWebPanelBasicActions.IRemove
    {
        BatchDomainTools.WebPanelActionResult.ActionResultBase RemoveOject(WebPanelItems.DomainItem DomainToRemove);
    }
}
