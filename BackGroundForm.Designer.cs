namespace BatchDomainTools
{
    partial class BackGroundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackGroundForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RepeatButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.expandCollapse1 = new UIContols.ExpandCollapse();
            this._CancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new BSE.Windows.Forms.Panel();
            this.LogRTBox = new BatchDomainTools.UI.LogTbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expandCollapse1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.RepeatButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.expandCollapse1);
            this.panel1.Controls.Add(this._CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 39);
            this.panel1.TabIndex = 0;
            // 
            // RepeatButton
            // 
            this.RepeatButton.Enabled = false;
            this.RepeatButton.Location = new System.Drawing.Point(304, 8);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(75, 23);
            this.RepeatButton.TabIndex = 3;
            this.RepeatButton.Text = "Повторить";
            this.RepeatButton.UseVisualStyleBackColor = true;
            this.RepeatButton.Visible = false;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(47, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Показать лог";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // expandCollapse1
            // 
            this.expandCollapse1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expandCollapse1.Image = ((System.Drawing.Image)(resources.GetObject("expandCollapse1.Image")));
            this.expandCollapse1.IsExpand = false;
            this.expandCollapse1.Location = new System.Drawing.Point(23, 10);
            this.expandCollapse1.Name = "expandCollapse1";
            this.expandCollapse1.Size = new System.Drawing.Size(19, 20);
            this.expandCollapse1.TabIndex = 1;
            this.expandCollapse1.TabStop = false;
            // 
            // CancelButton
            // 
            this._CancelButton.Location = new System.Drawing.Point(396, 9);
            this._CancelButton.Name = "CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(70, 22);
            this._CancelButton.TabIndex = 0;
            this._CancelButton.Text = "Отмена";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Операция в процессе выполнения, подождите пожалуйста";
            // 
            // panel2
            // 
            this.panel2.AssociatedSplitter = null;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.CaptionFont = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.CaptionHeight = 22;
            this.panel2.Controls.Add(this.LogRTBox);
            this.panel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Image = global::BatchDomainTools.Properties.Resources.scroll_pane_detail;
            this.panel2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel2.Location = new System.Drawing.Point(4, 61);
            this.panel2.MinimumSize = new System.Drawing.Size(22, 22);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel2.Size = new System.Drawing.Size(472, 23);
            this.panel2.TabIndex = 5;
            this.panel2.Text = "Лог:";
            this.panel2.ToolTipTextCloseIcon = null;
            this.panel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel2.ToolTipTextExpandIconPanelExpanded = null;
            this.panel2.Visible = false;
            // 
            // LogRTBox
            // 
            this.LogRTBox.BackColor = System.Drawing.Color.Black;
            this.LogRTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogRTBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogRTBox.ForeColor = System.Drawing.Color.White;
            this.LogRTBox.Location = new System.Drawing.Point(6, 28);
            this.LogRTBox.Name = "LogRTBox";
            this.LogRTBox.ReadOnly = true;
            this.LogRTBox.Size = new System.Drawing.Size(460, 0);
            this.LogRTBox.TabIndex = 0;
            this.LogRTBox.Text = "";
            // 
            // BackGroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 120);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BackGroundForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expandCollapse1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _CancelButton;
        private UIContols.ExpandCollapse expandCollapse1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private BSE.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private BatchDomainTools.UI.LogTbox LogRTBox;
        private System.Windows.Forms.Button RepeatButton;
    }
}