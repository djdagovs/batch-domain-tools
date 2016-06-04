using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons.EnumViewHelp
{
    /// <summary>
    /// Attribute which can be used to provide a good name for a field
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class EnumDisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        #region << ctor >>

        public EnumDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }

        #endregion

    }
}
