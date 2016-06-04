using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelActionResult
{
    public enum ActionResultType : int
    {
        PlainText = 1,
        Xml = 2,
        Html = 4,
        Json = 8,
        Any = 15
    }
}
