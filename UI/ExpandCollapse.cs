using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIContols
{
    public class ExpandCollapse : PictureBox
    {
        public event EventHandler<EventArgs> ExpandEvent;
        public event EventHandler<EventArgs> CollapseEvent;
        private bool m_IsExpand;
        public bool IsExpand
        {
            get 
            {
                return this.m_IsExpand;
            }
            set
            {
                this.m_IsExpand = value;
                if (this.m_IsExpand && ExpandEvent != null)
                {
                    ExpandEvent(this, new EventArgs());
                }
                else if (CollapseEvent != null)
                {
                    CollapseEvent(this, new EventArgs());
                }
                if(!this.Focused) OnMouseLeave(null);
            }
        }

        public ExpandCollapse() 
        {
            this.Image = BatchDomainTools.Properties.Resources.ExpandMouseIn;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            IsExpand = !IsExpand;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            OnMouseEnter(new EventArgs());
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.m_IsExpand)
                this.Image = BatchDomainTools.Properties.Resources.CollapseLButtonClick;
            else
                this.Image = BatchDomainTools.Properties.Resources.ExpandLButtonClick;
           
        }

        public void Click() 
        {
           OnMouseClick(null);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Image = this.m_IsExpand ? BatchDomainTools.Properties.Resources.ExpandMouseIn
                                   : BatchDomainTools.Properties.Resources.CollapseMouseIn;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = this.m_IsExpand ? BatchDomainTools.Properties.Resources.ExpandMouseIn
                                           : BatchDomainTools.Properties.Resources.CollapseNormal;
        }
    }
}
