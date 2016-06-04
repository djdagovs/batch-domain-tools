using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BatchDomainTools.UI
{
    /// <summary>
    /// Класс для решения проблемы с ImageList и изoбражениями с alpha chanel 
    /// </summary>
    public class xTabPage : System.Windows.Forms.TabPage
    {
        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Drawing.Image PageImage { get; set; }
        public string ItemsCount { get; set; }
    }
}
