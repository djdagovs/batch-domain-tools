namespace BatchDomainTools
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AccountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.WebPanelIcons = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.MainTabControl = new BatchDomainTools.xTabControl.LeftAlignTabcontrol();
            this.DomainTabPage = new BatchDomainTools.UI.xTabPage();
            this.DomainListView = new System.Windows.Forms.ListView();
            this.DomainCTRLStrip = new System.Windows.Forms.ToolStrip();
            this.IDomainGetButton = new System.Windows.Forms.ToolStripButton();
            this.IDomainAddButton = new System.Windows.Forms.ToolStripButton();
            this.IDomainRemoveButton = new System.Windows.Forms.ToolStripButton();
            this.IDomainEditButton = new System.Windows.Forms.ToolStripButton();
            this.SubDomainTabPage = new BatchDomainTools.UI.xTabPage();
            this.SubDomainListView = new System.Windows.Forms.ListView();
            this.SubDomainCTRLStrip = new System.Windows.Forms.ToolStrip();
            this.ISubDomainGetButton = new System.Windows.Forms.ToolStripButton();
            this.ISubDomainAddButton = new System.Windows.Forms.ToolStripButton();
            this.ISubDomainRemoveButton = new System.Windows.Forms.ToolStripButton();
            this.ISubDomainEditButton = new System.Windows.Forms.ToolStripButton();
            this.AccounManagerTabPage = new BatchDomainTools.UI.xTabPage();
            this.AccountListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.AccountManagerCTRLStrip = new System.Windows.Forms.ToolStrip();
            this.AddAccountButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditAccountButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveAccountButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.DomainTabPage.SuspendLayout();
            this.DomainCTRLStrip.SuspendLayout();
            this.SubDomainTabPage.SuspendLayout();
            this.SubDomainCTRLStrip.SuspendLayout();
            this.AccounManagerTabPage.SuspendLayout();
            this.AccountManagerCTRLStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccountMenuItem,
            this.SettingMenuStrip,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AccountMenuItem
            // 
            this.AccountMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AccountMenuItem.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountMenuItem.ForeColor = System.Drawing.Color.White;
            this.AccountMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AccountMenuItem.Name = "AccountMenuItem";
            this.AccountMenuItem.Size = new System.Drawing.Size(175, 24);
            this.AccountMenuItem.Text = "Добавьте учетные записи";
            this.AccountMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // SettingMenuStrip
            // 
            this.SettingMenuStrip.ForeColor = System.Drawing.Color.White;
            this.SettingMenuStrip.Image = global::BatchDomainTools.Properties.Resources.settings;
            this.SettingMenuStrip.Name = "SettingMenuStrip";
            this.SettingMenuStrip.Size = new System.Drawing.Size(101, 24);
            this.SettingMenuStrip.Text = "Настройки";
            this.SettingMenuStrip.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Image = global::BatchDomainTools.Properties.Resources.idea1;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 24);
            this.toolStripMenuItem3.Text = "Есть идеи или предложения?";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // WebPanelIcons
            // 
            this.WebPanelIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.WebPanelIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.WebPanelIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(28, 28);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.MainTabControl.BorderColor = System.Drawing.Color.White;
            this.MainTabControl.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.MainTabControl.ChevronColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.MainTabControl.ChevronShadowColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(87)))), ((int)(((byte)(99))))),
        System.Drawing.Color.White,
        System.Drawing.Color.White};
            this.MainTabControl.ChevronSize = 8;
            this.MainTabControl.Controls.Add(this.DomainTabPage);
            this.MainTabControl.Controls.Add(this.SubDomainTabPage);
            this.MainTabControl.Controls.Add(this.AccounManagerTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Verdana", 9F);
            this.MainTabControl.ItemSize = new System.Drawing.Size(52, 180);
            this.MainTabControl.Location = new System.Drawing.Point(0, 24);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabControl.Multiline = true;
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.Padding = new System.Drawing.Point(7, 0);
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.SelectTabBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.MainTabControl.SelectTabForeColor = System.Drawing.Color.White;
            this.MainTabControl.Size = new System.Drawing.Size(920, 526);
            this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabControl.TabBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(219)))));
            this.MainTabControl.TabBackgroundImage = null;
            this.MainTabControl.TabIndex = 0;
            // 
            // DomainTabPage
            // 
            this.DomainTabPage.BackColor = System.Drawing.Color.White;
            this.DomainTabPage.Controls.Add(this.DomainListView);
            this.DomainTabPage.Controls.Add(this.DomainCTRLStrip);
            this.DomainTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DomainTabPage.ForeColor = System.Drawing.Color.White;
            this.DomainTabPage.ImageIndex = 0;
            this.DomainTabPage.ItemsCount = null;
            this.DomainTabPage.Location = new System.Drawing.Point(184, 4);
            this.DomainTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.DomainTabPage.Name = "DomainTabPage";
            this.DomainTabPage.PageImage = global::BatchDomainTools.Properties.Resources.DomainTabIconwWorld;
            this.DomainTabPage.Size = new System.Drawing.Size(732, 518);
            this.DomainTabPage.TabIndex = 0;
            this.DomainTabPage.Text = "Домены";
            this.DomainTabPage.UseVisualStyleBackColor = true;
            // 
            // DomainListView
            // 
            this.DomainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainListView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DomainListView.FullRowSelect = true;
            this.DomainListView.GridLines = true;
            this.DomainListView.Location = new System.Drawing.Point(0, 35);
            this.DomainListView.Name = "DomainListView";
            this.DomainListView.Size = new System.Drawing.Size(732, 483);
            this.DomainListView.TabIndex = 1;
            this.DomainListView.UseCompatibleStateImageBehavior = false;
            this.DomainListView.View = System.Windows.Forms.View.Details;
            this.DomainListView.VirtualMode = true;
            // 
            // DomainCTRLStrip
            // 
            this.DomainCTRLStrip.BackColor = System.Drawing.Color.Transparent;
            this.DomainCTRLStrip.BackgroundImage = global::BatchDomainTools.Properties.Resources.DefaultToolbarBack;
            this.DomainCTRLStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.DomainCTRLStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDomainGetButton,
            this.IDomainAddButton,
            this.IDomainRemoveButton,
            this.IDomainEditButton});
            this.DomainCTRLStrip.Location = new System.Drawing.Point(0, 0);
            this.DomainCTRLStrip.Name = "DomainCTRLStrip";
            this.DomainCTRLStrip.Padding = new System.Windows.Forms.Padding(0);
            this.DomainCTRLStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.DomainCTRLStrip.Size = new System.Drawing.Size(732, 35);
            this.DomainCTRLStrip.TabIndex = 0;
            this.DomainCTRLStrip.Text = "toolStrip2";
            // 
            // IDomainGetButton
            // 
            this.IDomainGetButton.ForeColor = System.Drawing.Color.White;
            this.IDomainGetButton.Image = global::BatchDomainTools.Properties.Resources.ReloadIcon;
            this.IDomainGetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IDomainGetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDomainGetButton.Name = "IDomainGetButton";
            this.IDomainGetButton.Size = new System.Drawing.Size(186, 32);
            this.IDomainGetButton.Text = "Обновить список доменов";
            this.IDomainGetButton.ToolTipText = "Обновить список доменов с сервера";
            this.IDomainGetButton.Click += new System.EventHandler(this.ItemListUpdButton_Click);
            // 
            // IDomainAddButton
            // 
            this.IDomainAddButton.ForeColor = System.Drawing.Color.White;
            this.IDomainAddButton.Image = global::BatchDomainTools.Properties.Resources.AddIcon;
            this.IDomainAddButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IDomainAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDomainAddButton.Name = "IDomainAddButton";
            this.IDomainAddButton.Size = new System.Drawing.Size(138, 32);
            this.IDomainAddButton.Text = "Добавить домены";
            this.IDomainAddButton.ToolTipText = "Добавить новые домены";
            this.IDomainAddButton.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // IDomainRemoveButton
            // 
            this.IDomainRemoveButton.ForeColor = System.Drawing.Color.White;
            this.IDomainRemoveButton.Image = global::BatchDomainTools.Properties.Resources.RemoveIcon;
            this.IDomainRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IDomainRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDomainRemoveButton.Name = "IDomainRemoveButton";
            this.IDomainRemoveButton.Size = new System.Drawing.Size(130, 32);
            this.IDomainRemoveButton.Text = "Удалить домены";
            this.IDomainRemoveButton.ToolTipText = "Удалить домены выделенные домены";
            this.IDomainRemoveButton.Click += new System.EventHandler(this.ItemRemoveButton_Click);
            // 
            // IDomainEditButton
            // 
            this.IDomainEditButton.ForeColor = System.Drawing.Color.White;
            this.IDomainEditButton.Image = global::BatchDomainTools.Properties.Resources.EditIcon;
            this.IDomainEditButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IDomainEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDomainEditButton.Name = "IDomainEditButton";
            this.IDomainEditButton.Size = new System.Drawing.Size(166, 32);
            this.IDomainEditButton.Text = "Редактировать домены";
            this.IDomainEditButton.Click += new System.EventHandler(this.ItemEditButton_Click);
            // 
            // SubDomainTabPage
            // 
            this.SubDomainTabPage.BackColor = System.Drawing.Color.White;
            this.SubDomainTabPage.Controls.Add(this.SubDomainListView);
            this.SubDomainTabPage.Controls.Add(this.SubDomainCTRLStrip);
            this.SubDomainTabPage.ForeColor = System.Drawing.Color.White;
            this.SubDomainTabPage.ItemsCount = null;
            this.SubDomainTabPage.Location = new System.Drawing.Point(184, 4);
            this.SubDomainTabPage.Name = "SubDomainTabPage";
            this.SubDomainTabPage.PageImage = global::BatchDomainTools.Properties.Resources.SubDomainTabWorld1;
            this.SubDomainTabPage.Size = new System.Drawing.Size(732, 518);
            this.SubDomainTabPage.TabIndex = 7;
            this.SubDomainTabPage.Text = "Поддомены";
            // 
            // SubDomainListView
            // 
            this.SubDomainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubDomainListView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubDomainListView.FullRowSelect = true;
            this.SubDomainListView.GridLines = true;
            this.SubDomainListView.Location = new System.Drawing.Point(0, 35);
            this.SubDomainListView.Name = "SubDomainListView";
            this.SubDomainListView.Size = new System.Drawing.Size(732, 483);
            this.SubDomainListView.TabIndex = 3;
            this.SubDomainListView.UseCompatibleStateImageBehavior = false;
            this.SubDomainListView.View = System.Windows.Forms.View.Details;
            this.SubDomainListView.VirtualMode = true;
            // 
            // SubDomainCTRLStrip
            // 
            this.SubDomainCTRLStrip.BackColor = System.Drawing.Color.Transparent;
            this.SubDomainCTRLStrip.BackgroundImage = global::BatchDomainTools.Properties.Resources.DefaultToolbarBack;
            this.SubDomainCTRLStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SubDomainCTRLStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ISubDomainGetButton,
            this.ISubDomainAddButton,
            this.ISubDomainRemoveButton,
            this.ISubDomainEditButton});
            this.SubDomainCTRLStrip.Location = new System.Drawing.Point(0, 0);
            this.SubDomainCTRLStrip.Name = "SubDomainCTRLStrip";
            this.SubDomainCTRLStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.SubDomainCTRLStrip.Size = new System.Drawing.Size(732, 35);
            this.SubDomainCTRLStrip.TabIndex = 2;
            this.SubDomainCTRLStrip.Text = "toolStrip1";
            // 
            // ISubDomainGetButton
            // 
            this.ISubDomainGetButton.ForeColor = System.Drawing.Color.White;
            this.ISubDomainGetButton.Image = global::BatchDomainTools.Properties.Resources.ReloadIcon;
            this.ISubDomainGetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ISubDomainGetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ISubDomainGetButton.Name = "ISubDomainGetButton";
            this.ISubDomainGetButton.Size = new System.Drawing.Size(206, 32);
            this.ISubDomainGetButton.Text = "Обновить список поддоменов";
            this.ISubDomainGetButton.ToolTipText = "Обновить список  поддоменов с сервера";
            this.ISubDomainGetButton.Click += new System.EventHandler(this.ItemListUpdButton_Click);
            // 
            // ISubDomainAddButton
            // 
            this.ISubDomainAddButton.ForeColor = System.Drawing.Color.White;
            this.ISubDomainAddButton.Image = global::BatchDomainTools.Properties.Resources.AddIcon;
            this.ISubDomainAddButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ISubDomainAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ISubDomainAddButton.Name = "ISubDomainAddButton";
            this.ISubDomainAddButton.Size = new System.Drawing.Size(162, 32);
            this.ISubDomainAddButton.Text = "Добавить поддоменов";
            this.ISubDomainAddButton.ToolTipText = "Добавить новые поддомены";
            this.ISubDomainAddButton.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // ISubDomainRemoveButton
            // 
            this.ISubDomainRemoveButton.ForeColor = System.Drawing.Color.White;
            this.ISubDomainRemoveButton.Image = global::BatchDomainTools.Properties.Resources.RemoveIcon;
            this.ISubDomainRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ISubDomainRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ISubDomainRemoveButton.Name = "ISubDomainRemoveButton";
            this.ISubDomainRemoveButton.Size = new System.Drawing.Size(153, 32);
            this.ISubDomainRemoveButton.Text = "Удалить  поддомены";
            this.ISubDomainRemoveButton.ToolTipText = "Удалить выделенные  поддомены";
            this.ISubDomainRemoveButton.Click += new System.EventHandler(this.ItemRemoveButton_Click);
            // 
            // ISubDomainEditButton
            // 
            this.ISubDomainEditButton.ForeColor = System.Drawing.Color.White;
            this.ISubDomainEditButton.Image = global::BatchDomainTools.Properties.Resources.EditIcon;
            this.ISubDomainEditButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ISubDomainEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ISubDomainEditButton.Name = "ISubDomainEditButton";
            this.ISubDomainEditButton.Size = new System.Drawing.Size(189, 32);
            this.ISubDomainEditButton.Text = "Редактировать  поддомены";
            this.ISubDomainEditButton.ToolTipText = "Редактировать выделенные  поддомены";
            this.ISubDomainEditButton.Click += new System.EventHandler(this.ItemEditButton_Click);
            // 
            // AccounManagerTabPage
            // 
            this.AccounManagerTabPage.BackColor = System.Drawing.Color.White;
            this.AccounManagerTabPage.Controls.Add(this.AccountListView);
            this.AccounManagerTabPage.Controls.Add(this.AccountManagerCTRLStrip);
            this.AccounManagerTabPage.ForeColor = System.Drawing.Color.White;
            this.AccounManagerTabPage.ItemsCount = null;
            this.AccounManagerTabPage.Location = new System.Drawing.Point(184, 4);
            this.AccounManagerTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.AccounManagerTabPage.Name = "AccounManagerTabPage";
            this.AccounManagerTabPage.PageImage = global::BatchDomainTools.Properties.Resources.AccountsTabIcon;
            this.AccounManagerTabPage.Size = new System.Drawing.Size(732, 518);
            this.AccounManagerTabPage.TabIndex = 0;
            this.AccounManagerTabPage.Text = "Учётные записи";
            // 
            // AccountListView
            // 
            this.AccountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.AccountListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountListView.FullRowSelect = true;
            this.AccountListView.LargeImageList = this.WebPanelIcons;
            this.AccountListView.Location = new System.Drawing.Point(0, 35);
            this.AccountListView.MultiSelect = false;
            this.AccountListView.Name = "AccountListView";
            this.AccountListView.Size = new System.Drawing.Size(732, 483);
            this.AccountListView.SmallImageList = this.WebPanelIcons;
            this.AccountListView.TabIndex = 4;
            this.AccountListView.UseCompatibleStateImageBehavior = false;
            this.AccountListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Адрес панели";
            this.columnHeader3.Width = 255;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Логин";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Пароль";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Тип панели";
            this.columnHeader6.Width = 99;
            // 
            // AccountManagerCTRLStrip
            // 
            this.AccountManagerCTRLStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(219)))));
            this.AccountManagerCTRLStrip.BackgroundImage = global::BatchDomainTools.Properties.Resources.DefaultToolbarBack;
            this.AccountManagerCTRLStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AccountManagerCTRLStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAccountButton,
            this.toolStripSeparator1,
            this.EditAccountButton,
            this.toolStripSeparator2,
            this.RemoveAccountButton});
            this.AccountManagerCTRLStrip.Location = new System.Drawing.Point(0, 0);
            this.AccountManagerCTRLStrip.Name = "AccountManagerCTRLStrip";
            this.AccountManagerCTRLStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.AccountManagerCTRLStrip.Size = new System.Drawing.Size(732, 35);
            this.AccountManagerCTRLStrip.TabIndex = 3;
            this.AccountManagerCTRLStrip.Text = "toolStrip1";
            // 
            // AddAccountButton
            // 
            this.AddAccountButton.ForeColor = System.Drawing.Color.White;
            this.AddAccountButton.Image = global::BatchDomainTools.Properties.Resources.AddAccount3;
            this.AddAccountButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddAccountButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.AddAccountButton.Name = "AddAccountButton";
            this.AddAccountButton.Size = new System.Drawing.Size(181, 32);
            this.AddAccountButton.Text = "Добавить учетную запись";
            this.AddAccountButton.Click += new System.EventHandler(this.AddAccountButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // EditAccountButton
            // 
            this.EditAccountButton.Enabled = false;
            this.EditAccountButton.ForeColor = System.Drawing.Color.White;
            this.EditAccountButton.Image = global::BatchDomainTools.Properties.Resources.EditAccount;
            this.EditAccountButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditAccountButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditAccountButton.Name = "EditAccountButton";
            this.EditAccountButton.Size = new System.Drawing.Size(209, 32);
            this.EditAccountButton.Text = "Редактировать учетную запись";
            this.EditAccountButton.Click += new System.EventHandler(this.EditAccountButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // RemoveAccountButton
            // 
            this.RemoveAccountButton.Enabled = false;
            this.RemoveAccountButton.ForeColor = System.Drawing.Color.White;
            this.RemoveAccountButton.Image = global::BatchDomainTools.Properties.Resources.RemoveAccount;
            this.RemoveAccountButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RemoveAccountButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveAccountButton.Name = "RemoveAccountButton";
            this.RemoveAccountButton.Size = new System.Drawing.Size(173, 32);
            this.RemoveAccountButton.Text = "Удалить учетную запись";
            this.RemoveAccountButton.Click += new System.EventHandler(this.RemoveAccountButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 321);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Domain Tools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.DomainTabPage.ResumeLayout(false);
            this.DomainTabPage.PerformLayout();
            this.DomainCTRLStrip.ResumeLayout(false);
            this.DomainCTRLStrip.PerformLayout();
            this.SubDomainTabPage.ResumeLayout(false);
            this.SubDomainTabPage.PerformLayout();
            this.SubDomainCTRLStrip.ResumeLayout(false);
            this.SubDomainCTRLStrip.PerformLayout();
            this.AccounManagerTabPage.ResumeLayout(false);
            this.AccounManagerTabPage.PerformLayout();
            this.AccountManagerCTRLStrip.ResumeLayout(false);
            this.AccountManagerCTRLStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DomainListView;
        private System.Windows.Forms.ListView SubDomainListView;

        private BatchDomainTools.xTabControl.LeftAlignTabcontrol MainTabControl;
        private BatchDomainTools.UI.xTabPage DomainTabPage;
        private BatchDomainTools.UI.xTabPage SubDomainTabPage;
        private BatchDomainTools.UI.xTabPage AccounManagerTabPage;

        private System.Windows.Forms.ToolStrip DomainCTRLStrip;
        private System.Windows.Forms.ToolStripButton IDomainGetButton;
        private System.Windows.Forms.ToolStripButton IDomainAddButton;
        private System.Windows.Forms.ToolStripButton IDomainRemoveButton;
        private System.Windows.Forms.ToolStripButton IDomainEditButton;

        private System.Windows.Forms.ToolStrip SubDomainCTRLStrip;
        private System.Windows.Forms.ToolStripButton ISubDomainGetButton;
        private System.Windows.Forms.ToolStripButton ISubDomainAddButton;
        private System.Windows.Forms.ToolStripButton ISubDomainEditButton;
        private System.Windows.Forms.ToolStripButton ISubDomainRemoveButton;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AccountMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

        private System.Windows.Forms.ImageList WebPanelIcons;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListView AccountListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;

        private System.Windows.Forms.ToolStrip AccountManagerCTRLStrip;
        private System.Windows.Forms.ToolStripButton AddAccountButton;
        private System.Windows.Forms.ToolStripButton EditAccountButton;
        private System.Windows.Forms.ToolStripButton RemoveAccountButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;


    }
}

