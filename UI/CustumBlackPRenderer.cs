using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BatchDomainTools.UI
{
  
    public class CustumBlackPRenderer : ToolStripProfessionalRenderer
    {
        public CustumBlackPRenderer() : base(new CustumColors()) { }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem item = e.Item as System.Windows.Forms.ToolStripMenuItem;
            if (item != null && item.Selected || item.DropDown.Visible)
            {
               // Properties.Resources.ResourceManager.GetObject(
                e.TextColor = Color.FromArgb(55, 55, 55);
            }
            base.OnRenderItemText(e);
        }
   
    }

   public class CustumColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(253, 253, 253); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(254, 254, 254); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(255, 255, 255); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.White; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.White; }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.White; }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(55, 55, 55);
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(70, 70, 70);
            }
        }
        /*
         public override Color MenuBorder
         {
             get
             {
                 return Color.FromArgb(55, 55, 55);
             }
         }
        */
        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(55, 55, 55);
            }
        }
    }
}
