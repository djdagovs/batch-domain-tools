using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace BatchDomainTools.xTabControl
{
    public partial class LeftAlignTabcontrol : TabControl
    {
        #region << Поля и свойства >>

      /*  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Набор цветов для заполнения фона выделенной градиентым цветом")]
        public GradientColors SelectTabGradientColors
        {
            get
            {
                return this.m_TabGradientColors;
            }
            set
            {
                if (value != null)
                {
                    this.m_TabGradientColors = value;
                    this.Invalidate(false);
                }
            }
        }
        private GradientColors m_TabGradientColors;*/

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает фоновое изображения для области с вкладками панели."), Category("Behavior")]
        public Image TabBackgroundImage
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвет текста в заголовке для выбраной вкладки."), Category("Behavior")]
        public Color SelectTabForeColor
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает размерность шеврона."), Category("Behavior")]
        public int ChevronSize
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвета, которые используются для прорисовки тени шеврона."), Category("Behavior")]
        public Color[] ChevronShadowColors
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвет фона шеврона."), Category("Behavior")]
        public Color ChevronColor
        {
            get;
            set;
        }
        
        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвет фона заголовка для выбранной вкладки."), Category("Behavior")]
        public Color SelectTabBackgroundColor
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвет фона для области с вкладками панели."), Category("Behavior")]
        public Color TabBackgroundColor
        {
            get;
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает стиль, для отрисовки границ вокруг всего TabContol."), Category("Behavior")]
        public ButtonBorderStyle BorderStyle 
        {
            get; 
            set;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Устанавливает или возврашает цвет, который будет использован для отрисовки границ."), Category("Behavior")]
        public Color BorderColor 
        { 
            get; 
            set; 
        }

        #endregion

        #region << Ctor >>

        public LeftAlignTabcontrol()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
         
            this.TabBackgroundColor = Color.FromArgb(255, 255, 255);
            this.SelectTabForeColor = System.Drawing.Color.White;
            this.BorderStyle = ButtonBorderStyle.Solid;
            this.BorderColor = Color.FromArgb(198, 203, 214);
            this.SelectTabBackgroundColor = Color.FromArgb(237, 240, 244);
            this.ChevronSize = 10;
            this.ChevronColor = Color.FromArgb(255, 255, 255);
            this.ChevronShadowColors = new Color[] 
            {
                Color.FromArgb(229, 233, 238),
                Color.FromArgb(229, 233, 232),
                Color.FromArgb(221, 225, 232)
            };
            base.SizeMode = TabSizeMode.Fixed;
            base.ItemSize = new Size(42, 220);
            base.Size = new Size(688, 441);
            base.Alignment = TabAlignment.Left;
            //// Уменьшаем padding для изображений
            base.Padding = new Point(10, 0);
        }

        #endregion

        #region << Ovveride методы >>

       /*public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle r = base.DisplayRectangle;
                //r.Inflate(2, 1);
                r.Offset(0, -2);
                return r;
            }
        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    Rectangle TabHeaderRectangle = new Rectangle(0, 0, ItemSize.Height, Height);
                    if (base.SelectedTab != null && base.SelectedTab.BackColor != Color.Transparent)
                    {
                        G.Clear(base.SelectedTab.BackColor);
                    }
                    //// Заполняем background области с вкладками 
                    using (Brush tabBackGrnBrush = new SolidBrush(this.TabBackgroundColor))
                           G.FillRectangle(tabBackGrnBrush, TabHeaderRectangle);
                    //// Отрисовываем внешние границы контрола
                    ControlPaint.DrawBorder(G, this.ClientRectangle, this.BorderColor, this.BorderStyle);
                    //// Отрисовываем границу между областью панели с вкладками и панелью с содержимым
                    using (Pen borderPen = new Pen(this.BorderColor))
                           G.DrawLine(borderPen, TabHeaderRectangle.Width - 1, 1, TabHeaderRectangle.Width - 1, TabHeaderRectangle.Height);
                    //// Начинаем отрисовывать вкладки
                    for (int i = 0; i < this.TabCount; i++)
                    {
                        DrawTab(G, GetTabRect(i), i);
                    }
                    e.Graphics.DrawImage((Image)B, 0, 0);
                }
            }
        }
 
        protected override void OnDeselected(TabControlEventArgs e)
        {
            base.OnDeselected(e);
            base.Invalidate();
        }
 
        #endregion

        #region << Методы >>

        /// <summary>
        /// Метод производит отрисовку шеврона для активной панели
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="TabRectangle"></param>
        private void DrawChevron(Graphics graphics, Rectangle TabRectangle)
        {
            //// вычисляем ординату центра шеврона
            int yCenter = ((int)Math.Ceiling((double)(TabRectangle.Height * 50) / 100) + TabRectangle.Y)-1;
            //// Отрисовываем тень для шеврона
            for (int pIx = 0; pIx < this.ChevronShadowColors.Length; pIx++)
            {
                int sz = this.ChevronSize + (ChevronShadowColors.Length - pIx);
                Point[] psh = {
                                //// Начало шеврона
                                new Point(TabRectangle.Width,  yCenter - (sz - 1)),
                                //// Центр шеврона
                                new Point(TabRectangle.Width - sz + 1, yCenter),
                                new Point(TabRectangle.Width - sz + 1, yCenter + 1),
                                //// Окончание шеврона
                                new Point(TabRectangle.Width, yCenter + sz),
                              };
                using (Pen shadow1 = new Pen(this.ChevronShadowColors[pIx], 1))
                       graphics.DrawLines(shadow1, psh);
            }
            //// Границы шеврона
            Point[] p = {
                           new Point(TabRectangle.Width, 0),
                           //// Начало шеврона
                           new Point(TabRectangle.Width,  yCenter - (this.ChevronSize - 1)),
                           //// Центр шеврона
                           new Point(TabRectangle.Width - this.ChevronSize + 1, yCenter),
                           new Point(TabRectangle.Width - this.ChevronSize + 1, yCenter + 1),
                           //// Окончание шеврона
                           new Point(TabRectangle.Width, yCenter + this.ChevronSize),
                           new Point(TabRectangle.Width, TabRectangle.Height + TabRectangle.Y)
                        };
            //// Заполняем шеврон
            graphics.FillPolygon(new SolidBrush(this.ChevronColor), p);
            //// Отрисовываем border слева вкладки и для шеврона
           /* using (Pen border = new Pen(this.BorderColor, 1))
            {
              //  graphics.DrawLines(border, p);
                //// :|
               // border.Color = this.ChevronColor;
               // graphics.DrawLines(border, new Point[]
              //  {    
               //    new Point(TabRectangle.Width,  yCenter - (this.ChevronSize-2)),
               //    new Point(TabRectangle.Width, yCenter + this.ChevronSize-1)
               // });
            }*/
        }

        /// <summary>
        /// Метод производит отрисовку указанной вкладки
        /// </summary>
        /// <param name="grcs"></param>
        /// <param name="tabIndex"></param>
        protected void DrawTab(Graphics grcs, Rectangle TabRectanle, int tabIndex) 
        {
            Rectangle tabImageRectangle = default(Rectangle);
            /* Поcкольку верхняя панель выше на 1px от границы контрола, то необходимо поднять все панели на 2px вверх. 
             * Таким образом верхняя граница первой вкладки будет проходит по границе контрола, поэтому верхий border для первой вкладки отрисовывать не будем.
             * Также необходимо поднять вторую вкладку на 3px вверх, что бы скомпенсировать размер границы первой вкладки. 
             * В результате этого, все вкладки будут находиться на плошади соседней верхней вкладки на 2px, что фактически не заметно.
             */
            Rectangle tabBorderRectangle = TabRectanle;// GetTabRect(tabIndex);
            tabBorderRectangle.Width--;
            tabBorderRectangle.X = 0;
            tabBorderRectangle.Y -= (tabIndex != 0 ? 3 : 2);
            Rectangle tabDisplayRectangle = new Rectangle(1, tabBorderRectangle.Y + 1, tabBorderRectangle.Width, tabBorderRectangle.Height - 2);
            Rectangle tabTextRectangle = new Rectangle(tabDisplayRectangle.X, 
                                                       tabDisplayRectangle.Y + 2, 
                                                       tabDisplayRectangle.Width, 
                                                       tabDisplayRectangle.Height - 4);
            BatchDomainTools.UI.xTabPage tabPage = base.TabPages[tabIndex] as BatchDomainTools.UI.xTabPage;
            //// если текущий индекс является индексом выбранной вкладки, то отрисовываем background, border и шеврон
            if (base.SelectedIndex == tabIndex)
            {
                //// Заполняет background текущей вкладки
                grcs.FillRectangle(new SolidBrush(this.SelectTabBackgroundColor), tabDisplayRectangle);
                //// Отрисовываем границу внизу и сверху
                ControlPaint.DrawBorder(grcs, tabBorderRectangle, this.BorderColor, 0, ButtonBorderStyle.None,
                                                       this.BorderColor, 1, (tabIndex == 0 && this.BorderStyle != ButtonBorderStyle.None ? ButtonBorderStyle.None : ButtonBorderStyle.Solid),
                                                       this.BorderColor, 0, ButtonBorderStyle.None,
                                                       this.BorderColor, 1, ButtonBorderStyle.Solid);
                DrawChevron(grcs, tabDisplayRectangle);
            }
            //// Прорисовываем изображения, если есть
            if (tabPage.PageImage!=null)
            {
               // Image tabImage = base.ImageList.Images[base.TabPages[tabIndex].ImageIndex];
                tabImageRectangle = new Rectangle(tabDisplayRectangle.X + base.Padding.X, tabDisplayRectangle.Y + base.Padding.Y, tabPage.PageImage.Width, tabPage.PageImage.Height);
                tabImageRectangle.Y += (tabDisplayRectangle.Height - tabPage.PageImage.Height) / 2;
                grcs.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grcs.DrawImage(tabPage.PageImage, tabImageRectangle);
              //  ControlPaint.DrawBorder(grcs, tabImageRectangle, Color.Black, ButtonBorderStyle.Dashed);
                int iSpace = (tabImageRectangle.Right + base.Margin.Right);
                tabTextRectangle.X += iSpace;
                tabTextRectangle.Width -= iSpace;
            }
            tabTextRectangle.Width -= this.ChevronSize + 5 + base.Margin.Right;
            
            StringFormat TabPageTextFormat = new StringFormat() 
            {
                Alignment = StringAlignment.Near, 
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisWord
            };
          //  ControlPaint.DrawBorder(grcs, tabTextRectangle, Color.Black, ButtonBorderStyle.Dashed);
            Color textColor = tabIndex==base.SelectedIndex && this.SelectTabForeColor != Color.Transparent ? this.SelectTabForeColor : base.TabPages[tabIndex].ForeColor;
            Font fnt = base.Font;
            grcs.DrawString(base.TabPages[tabIndex].Text, fnt, new SolidBrush(textColor), tabTextRectangle, TabPageTextFormat);
        }

        #endregion
    }
}
