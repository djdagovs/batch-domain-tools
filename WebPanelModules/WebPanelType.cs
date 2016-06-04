using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelModules
{
    [Serializable]
    public enum WebPanelType : int
    {
        ISPmanager = 0,
        DirectAdmin = 1,
        cPanel = 2
    }
}
