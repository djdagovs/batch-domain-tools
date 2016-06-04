using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchDomainTools
{
    public partial class BackGroundForm : Form
    {
        #region << Поля >>

        Type UpdateType;

        #endregion

        #region << ctor >>

        public BackGroundForm(DoWorkEventHandler backgWorker_DoWork, Type _updateType)
        {
            InitializeComponent();
            this.backgroundWorker1.DoWork += backgWorker_DoWork;
            this.UpdateType = _updateType;
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.RunWorkerAsync(this.UpdateType);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.expandCollapse1.CollapseEvent += new EventHandler<EventArgs>(expandCollapse1_CollapseEvent);
            this.expandCollapse1.ExpandEvent += new EventHandler<EventArgs>(expandCollapse1_ExpandEvent);
            this.pictureBox1.Image = global::BatchDomainTools.Properties.Resources.loading52;
        }

        #endregion

        #region << Обработчики событий формы >>

        void expandCollapse1_ExpandEvent(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height + 195);
            this.panel2.Size = new System.Drawing.Size(this.panel2.Size.Width, this.panel2.CaptionHeight + 180);
            this.panel2.Show();
            label1.Text = "Скрыть лог";
        }

        void expandCollapse1_CollapseEvent(object sender, EventArgs e)
        {
            this.panel2.Size = new System.Drawing.Size(this.panel2.Size.Width, 0);
            this.panel2.Hide();
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - 195);
            label1.Text = "Показать лог";
        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Transparent, 0, ButtonBorderStyle.None, Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid, Color.Transparent, 0, ButtonBorderStyle.None, Color.Transparent, 0, ButtonBorderStyle.None);
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
                this.Close();
            else
            {
                this.label2.Text = "Операция прошла неудачно, подробности в логе";
                this.pictureBox1.Image = this.pictureBox1.Image = global::BatchDomainTools.Properties.Resources.error;
                this.RepeatButton.Enabled = RepeatButton.Visible = true;
            }
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.LogRTBox.WriteToLog(e.UserState.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            expandCollapse1.Click();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            this.RepeatButton.Enabled = false;
            this.LogRTBox.Clear();
            this.label2.Text = "Операция в процессе выполнения, подождите пожалуйста";
            this.pictureBox1.Image = global::BatchDomainTools.Properties.Resources.loading52;
            this.backgroundWorker1.RunWorkerAsync(this.UpdateType);
        }

        #endregion
    }
}
