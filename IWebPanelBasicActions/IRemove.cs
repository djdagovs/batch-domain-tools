using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.IWebPanelBasicActions
{
    public interface IRemove
    {
        BatchDomainTools.WebPanelActionResult.ActionResultBase RemoveOject(WebPanelItems.WebPanelItemBase ObjectToRemove);
    }
}
