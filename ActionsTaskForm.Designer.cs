namespace BatchDomainTools
{
    partial class ActionsTaskForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionsTaskForm));
            this.buttonStepForward = new System.Windows.Forms.Button();
            this.buttonStepBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Desriptionlabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TaskTypePict = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CloseFormListUpdate = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tablessControl1 = new TablessControl();
            this.ItemInputTabPage = new System.Windows.Forms.TabPage();
            this.DomaintBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddFromBuffer = new System.Windows.Forms.ToolStripButton();
            this.AddFromFile = new System.Windows.Forms.ToolStripButton();
            this.CleenDomainTBox = new System.Windows.Forms.ToolStripButton();
            this.PropertyChangeTabPage = new System.Windows.Forms.TabPage();
            this.OptionsGrid = new System.Windows.Forms.PropertyGrid();
            this.ActionResultTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ProgressListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new BSE.Windows.Forms.Panel();
            this.LogRTBox = new BatchDomainTools.UI.LogTbox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.StartAddButton = new System.Windows.Forms.ToolStripButton();
            this.StopAddButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskTypePict)).BeginInit();
            this.panel3.SuspendLayout();
            this.tablessControl1.SuspendLayout();
            this.ItemInputTabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.PropertyChangeTabPage.SuspendLayout();
            this.ActionResultTabPage.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStepForward
            // 
            this.buttonStepForward.Enabled = false;
            this.buttonStepForward.Image = global::BatchDomainTools.Properties.Resources.arrow_right;
            this.buttonStepForward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStepForward.Location = new System.Drawing.Point(441, 11);
            this.buttonStepForward.Name = "buttonStepForward";
            this.buttonStepForward.Size = new System.Drawing.Size(66, 23);
            this.buttonStepForward.TabIndex = 1;
            this.buttonStepForward.Text = "Вперед";
            this.buttonStepForward.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStepForward.UseVisualStyleBackColor = false;
            this.buttonStepForward.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonStepBack
            // 
            this.buttonStepBack.Enabled = false;
            this.buttonStepBack.Image = global::BatchDomainTools.Properties.Resources.arrow_left;
            this.buttonStepBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStepBack.Location = new System.Drawing.Point(371, 11);
            this.buttonStepBack.Name = "buttonStepBack";
            this.buttonStepBack.Size = new System.Drawing.Size(64, 23);
            this.buttonStepBack.TabIndex = 1;
            this.buttonStepBack.Text = "Назад";
            this.buttonStepBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStepBack.UseVisualStyleBackColor = true;
            this.buttonStepBack.Click += new System.EventHandler(this.buttonStepBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Desriptionlabel);
            this.panel2.Controls.Add(this.TitleLabel);
            this.panel2.Controls.Add(this.TaskTypePict);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 55);
            this.panel2.TabIndex = 2;
            // 
            // Desriptionlabel
            // 
            this.Desriptionlabel.AutoEllipsis = true;
            this.Desriptionlabel.AutoSize = true;
            this.Desriptionlabel.BackColor = System.Drawing.Color.White;
            this.Desriptionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Desriptionlabel.Location = new System.Drawing.Point(56, 30);
            this.Desriptionlabel.Name = "Desriptionlabel";
            this.Desriptionlabel.Size = new System.Drawing.Size(90, 15);
            this.Desriptionlabel.TabIndex = 2;
            this.Desriptionlabel.Text = "Desriptionlabel";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.White;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(56, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(73, 17);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "TitleLabel";
            // 
            // TaskTypePict
            // 
            this.TaskTypePict.Location = new System.Drawing.Point(12, 12);
            this.TaskTypePict.Name = "TaskTypePict";
            this.TaskTypePict.Size = new System.Drawing.Size(34, 34);
            this.TaskTypePict.TabIndex = 0;
            this.TaskTypePict.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Select");
            this.imageList1.Images.SetKeyName(1, "Success");
            this.imageList1.Images.SetKeyName(2, "Error");
            // 
            // CloseFormListUpdate
            // 
            this.CloseFormListUpdate.AutoSize = true;
            this.CloseFormListUpdate.Location = new System.Drawing.Point(12, 14);
            this.CloseFormListUpdate.Name = "CloseFormListUpdate";
            this.CloseFormListUpdate.Size = new System.Drawing.Size(210, 17);
            this.CloseFormListUpdate.TabIndex = 3;
            this.CloseFormListUpdate.Text = "Обновить список по закрытию окна";
            this.CloseFormListUpdate.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.CloseFormListUpdate);
            this.panel3.Controls.Add(this.buttonStepForward);
            this.panel3.Controls.Add(this.buttonStepBack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 486);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 40);
            this.panel3.TabIndex = 4;
            // 
            // tablessControl1
            // 
            this.tablessControl1.Controls.Add(this.ItemInputTabPage);
            this.tablessControl1.Controls.Add(this.PropertyChangeTabPage);
            this.tablessControl1.Controls.Add(this.ActionResultTabPage);
            this.tablessControl1.Location = new System.Drawing.Point(0, 55);
            this.tablessControl1.Multiline = true;
            this.tablessControl1.Name = "tablessControl1";
            this.tablessControl1.SelectedIndex = 0;
            this.tablessControl1.Size = new System.Drawing.Size(525, 427);
            this.tablessControl1.TabIndex = 0;
            // 
            // ItemInputTabPage
            // 
            this.ItemInputTabPage.BackColor = System.Drawing.Color.White;
            this.ItemInputTabPage.Controls.Add(this.DomaintBox);
            this.ItemInputTabPage.Controls.Add(this.toolStrip1);
            this.ItemInputTabPage.Location = new System.Drawing.Point(4, 22);
            this.ItemInputTabPage.Name = "ItemInputTabPage";
            this.ItemInputTabPage.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.ItemInputTabPage.Size = new System.Drawing.Size(517, 401);
            this.ItemInputTabPage.TabIndex = 0;
            this.ItemInputTabPage.Text = "Шаг 1 - добавления доменнов";
            // 
            // DomaintBox
            // 
            this.DomaintBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DomaintBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomaintBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DomaintBox.Location = new System.Drawing.Point(33, 8);
            this.DomaintBox.MaxLength = 999999999;
            this.DomaintBox.Multiline = true;
            this.DomaintBox.Name = "DomaintBox";
            this.DomaintBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DomaintBox.Size = new System.Drawing.Size(484, 385);
            this.DomaintBox.TabIndex = 1;
            this.DomaintBox.WordWrap = false;
            this.DomaintBox.TextChanged += new System.EventHandler(this.DomaintBox_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFromBuffer,
            this.AddFromFile,
            this.CleenDomainTBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 8);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(33, 385);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddFromBuffer
            // 
            this.AddFromBuffer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFromBuffer.Image = global::BatchDomainTools.Properties.Resources.cllipboardAdd;
            this.AddFromBuffer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddFromBuffer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFromBuffer.Name = "AddFromBuffer";
            this.AddFromBuffer.Size = new System.Drawing.Size(31, 28);
            this.AddFromBuffer.Text = "Добавить домены из буфера";
            this.AddFromBuffer.Click += new System.EventHandler(this.AddFromBuffer_Click);
            // 
            // AddFromFile
            // 
            this.AddFromFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFromFile.Image = global::BatchDomainTools.Properties.Resources.fileAdd;
            this.AddFromFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFromFile.Name = "AddFromFile";
            this.AddFromFile.Size = new System.Drawing.Size(31, 28);
            this.AddFromFile.Text = "Добавить домены из файла";
            this.AddFromFile.Click += new System.EventHandler(this.AddFromFile_Click);
            // 
            // CleenDomainTBox
            // 
            this.CleenDomainTBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CleenDomainTBox.Image = global::BatchDomainTools.Properties.Resources.clearList;
            this.CleenDomainTBox.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CleenDomainTBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CleenDomainTBox.Name = "CleenDomainTBox";
            this.CleenDomainTBox.Size = new System.Drawing.Size(31, 26);
            this.CleenDomainTBox.Text = "Очистить список";
            this.CleenDomainTBox.Click += new System.EventHandler(this.CleenDomainTBox_Click);
            // 
            // PropertyChangeTabPage
            // 
            this.PropertyChangeTabPage.BackColor = System.Drawing.Color.White;
            this.PropertyChangeTabPage.Controls.Add(this.OptionsGrid);
            this.PropertyChangeTabPage.Location = new System.Drawing.Point(4, 22);
            this.PropertyChangeTabPage.Name = "PropertyChangeTabPage";
            this.PropertyChangeTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.PropertyChangeTabPage.Size = new System.Drawing.Size(517, 401);
            this.PropertyChangeTabPage.TabIndex = 1;
            this.PropertyChangeTabPage.Text = "Шаг 2 - параметры доменов";
            // 
            // OptionsGrid
            // 
            this.OptionsGrid.CategoryForeColor = System.Drawing.Color.White;
            this.OptionsGrid.CommandsBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OptionsGrid.CommandsForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.OptionsGrid.CommandsVisibleIfAvailable = false;
            this.OptionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptionsGrid.HelpForeColor = System.Drawing.Color.Black;
            this.OptionsGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(219)))));
            this.OptionsGrid.Location = new System.Drawing.Point(8, 8);
            this.OptionsGrid.Name = "OptionsGrid";
            this.OptionsGrid.Size = new System.Drawing.Size(501, 385);
            this.OptionsGrid.TabIndex = 0;
            this.OptionsGrid.UseCompatibleTextRendering = true;
            this.OptionsGrid.ViewBackColor = System.Drawing.Color.White;
            this.OptionsGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ActionResultTabPage
            // 
            this.ActionResultTabPage.BackColor = System.Drawing.Color.White;
            this.ActionResultTabPage.Controls.Add(this.splitContainer1);
            this.ActionResultTabPage.Controls.Add(this.toolStrip2);
            this.ActionResultTabPage.Location = new System.Drawing.Point(4, 22);
            this.ActionResultTabPage.Name = "ActionResultTabPage";
            this.ActionResultTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.ActionResultTabPage.Size = new System.Drawing.Size(517, 401);
            this.ActionResultTabPage.TabIndex = 2;
            this.ActionResultTabPage.Text = "Шаг 3 - добавления доменов";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(8, 35);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ProgressListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(501, 358);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 5;
            // 
            // ProgressListBox
            // 
            this.ProgressListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ProgressListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressListBox.FullRowSelect = true;
            this.ProgressListBox.GridLines = true;
            this.ProgressListBox.LargeImageList = this.imageList1;
            this.ProgressListBox.Location = new System.Drawing.Point(0, 0);
            this.ProgressListBox.Name = "ProgressListBox";
            this.ProgressListBox.Size = new System.Drawing.Size(501, 243);
            this.ProgressListBox.SmallImageList = this.imageList1;
            this.ProgressListBox.TabIndex = 0;
            this.ProgressListBox.UseCompatibleStateImageBehavior = false;
            this.ProgressListBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 496;
            // 
            // panel1
            // 
            this.panel1.AssociatedSplitter = null;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.CaptionFont = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.panel1.CaptionHeight = 22;
            this.panel1.Controls.Add(this.LogRTBox);
            this.panel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel1.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel1.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel1.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel1.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel1.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Image = global::BatchDomainTools.Properties.Resources.scroll_pane_detail;
            this.panel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel1.Size = new System.Drawing.Size(501, 111);
            this.panel1.TabIndex = 4;
            this.panel1.Text = "Лог:";
            this.panel1.ToolTipTextCloseIcon = null;
            this.panel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel1.ToolTipTextExpandIconPanelExpanded = null;
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
            this.LogRTBox.Size = new System.Drawing.Size(489, 77);
            this.LogRTBox.TabIndex = 0;
            this.LogRTBox.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartAddButton,
            this.StopAddButton,
            this.toolStripSeparator1,
            this.AddProgressBar,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(8, 8);
            this.toolStrip2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(501, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // StartAddButton
            // 
            this.StartAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartAddButton.Image = global::BatchDomainTools.Properties.Resources.ActionStartIcon;
            this.StartAddButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StartAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartAddButton.Name = "StartAddButton";
            this.StartAddButton.Size = new System.Drawing.Size(24, 24);
            this.StartAddButton.Text = "Начать добавления";
            this.StartAddButton.Click += new System.EventHandler(this.StartActionsButton_Click);
            // 
            // StopAddButton
            // 
            this.StopAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopAddButton.Enabled = false;
            this.StopAddButton.Image = global::BatchDomainTools.Properties.Resources.ActionStopIcon1;
            this.StopAddButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StopAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopAddButton.Name = "StopAddButton";
            this.StopAddButton.Size = new System.Drawing.Size(24, 24);
            this.StopAddButton.Text = "Остановить добавления";
            this.StopAddButton.Click += new System.EventHandler(this.StopAddButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // AddProgressBar
            // 
            this.AddProgressBar.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.AddProgressBar.Name = "AddProgressBar";
            this.AddProgressBar.Size = new System.Drawing.Size(220, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ActionsTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 526);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tablessControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ActionsTaskForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskTypePict)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tablessControl1.ResumeLayout(false);
            this.ItemInputTabPage.ResumeLayout(false);
            this.ItemInputTabPage.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PropertyChangeTabPage.ResumeLayout(false);
            this.ActionResultTabPage.ResumeLayout(false);
            this.ActionResultTabPage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TablessControl tablessControl1;
        private System.Windows.Forms.TabPage ItemInputTabPage;
        private System.Windows.Forms.TabPage PropertyChangeTabPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox DomaintBox;
        private System.Windows.Forms.ToolStripButton AddFromBuffer;
        private System.Windows.Forms.ToolStripButton AddFromFile;
        private System.Windows.Forms.ToolStripButton CleenDomainTBox;
        private System.Windows.Forms.Button buttonStepForward;
        private System.Windows.Forms.PropertyGrid OptionsGrid;
        private System.Windows.Forms.Button buttonStepBack;
        private System.Windows.Forms.TabPage ActionResultTabPage;
        private System.Windows.Forms.ListView ProgressListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox TaskTypePict;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label Desriptionlabel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton StartAddButton;
        private System.Windows.Forms.ToolStripButton StopAddButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar AddProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private BSE.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private BatchDomainTools.UI.LogTbox LogRTBox;
        private System.Windows.Forms.CheckBox CloseFormListUpdate;
        private System.Windows.Forms.Panel panel3;

    }
}