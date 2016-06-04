using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelObjectActions.ISubDomainActions
{
    public interface ISubDomainRemove : IWebPanelBasicActions.IRemove
    {
        BatchDomainTools.WebPanelActionResult.ActionResultBase RemoveOject(WebPanelItems.SubDomainItem SubDomain2Remove);
    }
}
