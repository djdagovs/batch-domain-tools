using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace xTabControl
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GradientColors
    {
        #region << Properties and Fields >>

        private Color[] colors = { Color.White, Color.Yellow, Color.Blue };

        private Color m_GradientBegin = Color.White;
        [Description("Начальный цвет градиента")]
        public virtual Color GradientBegin
        {
            get { return this.m_GradientBegin; }
            set
            {
                if (value.Equals(this.m_GradientBegin) == false)
                {
                    colors[0] = this.m_GradientBegin = value;
                }
            }
        }

        private Color m_GradientMiddle = Color.Yellow;
        [Description("Средний цвет градиента")]
        public virtual Color GradientMiddle
        {
            get { return this.m_GradientMiddle; }
            set
            {
                if (value.Equals(this.m_GradientMiddle) == false)
                {
                    colors[1] = this.m_GradientMiddle = value;
                }
            }
        }

        private Color m_GradientEnd = Color.Blue;
        [Description("Конечний цвет градиента")]
        public virtual Color GradientEnd
        {
            get { return this.m_GradientEnd; }
            set
            {
                if (value.Equals(this.m_GradientEnd) == false)
                {
                    colors[2] = this.m_GradientEnd = value;
                }
            }
        }

        #endregion

        #region << Methods >>

        public Color[] GetColors()
        {
            return colors;
        }

        #endregion
    }

}
