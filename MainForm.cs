using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BatchDomainTools.WebPanelAccount;

namespace BatchDomainTools
{
    public partial class MainForm : Form
    {
        #region << Поля и свойства >>

        #endregion

        #region << Ctor >>

        public MainForm()
        {
            InitializeComponent();
            this.menuStrip1.Items.Remove(this.SettingMenuStrip);
            InitCustumRuntimeUI();
            DesignateControlsInterfaces();
            InitEventHandlers();
            AccountManager.LoadAccounts(Setting.AccountFileName);
            if (AccountManager.ManagerInstance.Count == 0) {
                ManagerInstance_AccountChangeEvent(this, new BatchDomainTools.WebPanelCommons.AccountSelectEventArgs(WebPanelCommons.SelectStatus.end) );
            }
            if (!this.Visible)
            { 
                IntPtr hWnd = this.Handle;
                this.Show();
                this.Activate();
            }
        }


        #endregion

        #region << Обработчики событий >>

        #region << Menu Strip >>

        private void AccountMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.AccountMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem);
            AccountManager.ManagerInstance.SelectAccountByAt(index);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
          //  new SettingForm().ShowDialog();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                try
                {
                    process.StartInfo.FileName = "https://github.com/w3bstate/batch-domain-tools/issues";
                    process.Start();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show( string.Format("Не удалось открыть внешний адресс: {0}", ex.Message) );
                }
            }
        }

        #endregion

        #region << AccountManager >>

        private void ManagerInstance_AccountChangeEvent(object sender, BatchDomainTools.WebPanelCommons.AccountSelectEventArgs e)
        {
            if (e.Status == BatchDomainTools.WebPanelCommons.SelectStatus.start) 
            {
                this.DomainListView.BeginUpdate();
                this.SubDomainListView.BeginUpdate();
                this.DomainListView.Clear();
                this.SubDomainListView.Clear();
            }
            else
            {
                if (AccountManager.ManagerInstance.Count > 0 )
                {
                    ToolStripMenuItem selectMenuItem = (ToolStripMenuItem)this.AccountMenuItem.DropDownItems[e.SelectIndex];
                    selectMenuItem.Checked = true;
                    this.AccountMenuItem.Text = selectMenuItem.Text;
                    ToolStripMenuItem lastSelectMenuItem = this.AccountMenuItem.Tag as ToolStripMenuItem;
                    if (lastSelectMenuItem != null)
                        lastSelectMenuItem.Checked = false;
                    this.AccountMenuItem.Tag = selectMenuItem;
                    this.AccountMenuItem.Image = selectMenuItem.Image;
                    Type[] ifaces = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI.GetType().GetInterfaces();
                    InitApiItemComponent(this.DomainTabPage, typeof(IWebPanelObjectActions.IDomainActions.IDomainGet).Namespace, ifaces);
                    InitApiItemComponent(this.SubDomainTabPage, typeof(IWebPanelObjectActions.ISubDomainActions.ISubDomainGet).Namespace, ifaces);
                }
                else
                {
                    this.AccountMenuItem.Text = "Добавьте учетные записи";
                    this.AccountMenuItem.Tag = null;
                    this.DomainCTRLStrip.Enabled = SubDomainCTRLStrip.Enabled = false;
                   // this.SubDomainTabPage.Enabled = this.DomainTabPage.Enabled = false;
                    //TODO: добавить изображения при отсутсвии аккаунтов
                    this.AccountMenuItem.Image = null;//global::BatchDomainTools.Properties.Resources.AccountMenuImage;
                    this.MainTabControl.SelectedTab = this.AccounManagerTabPage;
                }
                this.DomainListView.EndUpdate();
                this.SubDomainListView.EndUpdate();
            }
        }
        private void ManagerInstance_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) 
            {
                case (System.Collections.Specialized.NotifyCollectionChangedAction.Add):
                {
                    foreach (Account account in e.NewItems)
                    {
                       ToolStripItem newitem = this.AccountMenuItem.DropDownItems.Add(account.ToString());
                       newitem.Click += new EventHandler(AccountMenuItem_Click);
                       newitem.Image = this.WebPanelIcons.Images[account.PanelType.ToString()];
                       this.AccountListView.Items.Add(CastToListViewItem(account));
                    }
                    if ( this.AccountMenuItem.Tag == null && AccountManager.ManagerInstance.Count > 0) 
                    {
                        AccountManager.ManagerInstance.SelectAccountByAt(0);
                    }
                    break;
                }
                case (System.Collections.Specialized.NotifyCollectionChangedAction.Replace):
                {
                   this.AccountMenuItem.DropDownItems[e.NewStartingIndex].Text = e.NewItems[0].ToString();
                   this.AccountListView.Items[e.NewStartingIndex] = CastToListViewItem((Account)e.NewItems[0]);
                   break;
                }
                case (System.Collections.Specialized.NotifyCollectionChangedAction.Remove):
                {
                    this.AccountMenuItem.DropDownItems.RemoveAt(e.OldStartingIndex);
                    this.AccountListView.Items.RemoveAt(e.OldStartingIndex);
                    if (AccountManager.ManagerInstance.Count == 0)
                    {
                        this.MainTabControl.SelectedTab = this.AccounManagerTabPage;
                    }
                    break;
                }
            }
        }

        #endregion

        #region << Вкладка управления аккаунтами >>

        private void AccountListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditAccountButton_Click(sender, e);
        }

        private void AccountListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RemoveAccountButton.Enabled = this.EditAccountButton.Enabled = this.AccountListView.SelectedIndices.Count > 0;
        }
     
        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            AccountViewForm acfr = new AccountViewForm(null);
            ////TODO: Weak References?
            acfr.AccountEditComplited += new EventHandler<EventArgs>((account, _e) =>
            {
                WebPanelAccount.AccountManager.ManagerInstance.Add((WebPanelAccount.Account)account);
                AccountManager.SaveAccounts(Setting.AccountFileName);
            });
            acfr.ShowDialog();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            if (this.AccountListView.SelectedIndices.Count > 0)
            {
                int index = this.AccountListView.SelectedIndices[0];
                AccountViewForm acfr = new AccountViewForm(AccountManager.ManagerInstance[index]);
                acfr.AccountEditComplited += new EventHandler<EventArgs>((account, _e) =>
                {
                    WebPanelAccount.AccountManager.ManagerInstance[index] = (Account)account;
                    AccountManager.SaveAccounts(Setting.AccountFileName);
                });
                acfr.ShowDialog();
            }
        }

        private void RemoveAccountButton_Click(object sender, EventArgs e)
        {
            if (this.AccountListView.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выделенный аккаунт?", "Подтверждения", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    WebPanelAccount.AccountManager.ManagerInstance.RemoveAt(this.AccountListView.SelectedIndices[0]);
                    AccountManager.SaveAccounts(Setting.AccountFileName);
                }
            }
        }

        #endregion

        #region << Общие обработчики событий >>
        ///TODO: передавать на обработку список со строками а не WebPanelItems.WebPanelItemCollection
        /// <summary>
        /// Открываем форму получения списка объектов
        /// </summar
        private void ItemListUpdButton_Click(object sender, EventArgs e)
        {
            Type upType = null;
            ListView listView = null;
            if (sender.Equals(this.IDomainGetButton) || sender.Equals(typeof(WebPanelItems.DomainItem)))
            {
                upType = typeof(WebPanelItems.DomainItem);
                listView = this.DomainListView;
            }
            else if (sender.Equals(this.ISubDomainGetButton) || sender.Equals(typeof(WebPanelItems.SubDomainItem)))
            {
                upType = typeof(WebPanelItems.SubDomainItem);
                listView = this.SubDomainListView;
            }
            BackGroundForm bgf = new BackGroundForm(UpdateList_DoWork, upType);
            bgf.Text = "Получаем список...";
            listView.VirtualListSize = 0;
            bgf.FormClosed += new FormClosedEventHandler((_sender, _e) =>
            {
                listView.VirtualListSize = AccountManager.SelectAccount.PanelItems[upType].Count;
            });
            bgf.ShowDialog(this);
        }
        /// <summary>
        /// Открываем форму добавления объектов
        /// TODO: Объединить часть кода получения типа объектов с ItemRemoveButton_Click, ItemEditButton_Click, ItemListUpdButton_Click в один метод
        /// </summary>
        private void ItemAdd_Click(object sender, EventArgs e)
        {
            WebPanelOptionData.IOptionData options = AccountManager.SelectAccount.WebPanelAPIOptions.Clone() as WebPanelOptionData.IOptionData; 
            Type addType = null;
            if (sender.Equals(this.IDomainAddButton))
            {
                addType = typeof(WebPanelItems.DomainItem);
            }
            else if (sender.Equals(this.ISubDomainAddButton))
            {
                addType = typeof(WebPanelItems.SubDomainItem);
            }
            ActionsTaskForm addForm = new ActionsTaskForm(addType, options);
            addForm.FormClosedEvent += new EventHandler<BatchDomainTools.WebPanelCommons.SimpleEventArgs>((_sender, _e) =>
            {
                if ((bool)_e.EventArg)
                {
                    ItemListUpdButton_Click(addType, e);
                }
            });
            addForm.ShowDialog();
        }
        /// <summary>
        /// Открываем форму удаления выделенных объектов
        /// </summary>
        private void ItemRemoveButton_Click(object sender, EventArgs e)
        {
            Type remType = null;
            ListView listView = null;
            WebPanelOptionData.IOptionData options = AccountManager.SelectAccount.WebPanelAPIOptions.Clone() as WebPanelOptionData.IOptionData;
            if (sender.Equals(this.IDomainRemoveButton))
            {
                remType = typeof(WebPanelItems.DomainItem);
                listView = this.DomainListView;
            }
            else if (sender.Equals(this.ISubDomainRemoveButton))
            {
                remType = typeof(WebPanelItems.SubDomainItem);
                listView = this.SubDomainListView;
            }
            WebPanelItems.WebPanelItemCollection remCollection = WebPanelAccount.AccountManager.SelectAccount.PanelItems[remType].SelectRange(listView.SelectedIndices.Cast<int>().Select(item => item));
            ActionsTaskForm removeForm = new ActionsTaskForm(remCollection);
            removeForm.FormClosedEvent+=new EventHandler<BatchDomainTools.WebPanelCommons.SimpleEventArgs>((_sender,_e)=>{
                if ((bool)_e.EventArg)
                {
                    ItemListUpdButton_Click(remType, e);
                }
                DisplayListView_SelectedIndexChanged(listView, null);
            });
            removeForm.ShowDialog();
        }
        /// <summary>
        /// Открываем форму редактирования выделенных объектов
        /// </summary>
        private void ItemEditButton_Click(object sender, EventArgs e)
        {
            Type editType = null;
            ListView listView = null;
            WebPanelOptionData.IOptionData options = AccountManager.SelectAccount.WebPanelAPIOptions.Clone() as WebPanelOptionData.IOptionData;
            if (sender.Equals(this.IDomainEditButton))
            {
                editType = typeof(WebPanelItems.DomainItem);
                listView = this.DomainListView;
            }
            else if (sender.Equals(this.ISubDomainEditButton))
            {
                editType = typeof(WebPanelItems.SubDomainItem);
                listView = this.SubDomainListView;
            }
            WebPanelItems.WebPanelItemCollection remCollection = WebPanelAccount.AccountManager.SelectAccount.PanelItems[editType].SelectRange(listView.SelectedIndices.Cast<int>().Select(item => item));
            ActionsTaskForm editForm = new ActionsTaskForm(remCollection, options);
            editForm.FormClosedEvent += new EventHandler<BatchDomainTools.WebPanelCommons.SimpleEventArgs>((_sender, _e) =>
            {
                if ((bool)_e.EventArg)
                {
                    ItemListUpdButton_Click(editType, e);
                }
            });
            editForm.ShowDialog();
        }
        /// <summary>
        /// Обрабатываем получения элемента списка
        /// </summary>
        private void DisplayListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListView listView = sender as ListView;
            Type dType = null; 
            if (AccountManager.SelectAccount != null && listView != null)
            {
                 WebPanelItems.WebPanelItemCollection collection = null;
                 if(listView == this.SubDomainListView)
                     dType = typeof(WebPanelItems.SubDomainItem);
                 else if(listView == this.DomainListView)
                     dType = typeof(WebPanelItems.DomainItem);
                 collection = AccountManager.SelectAccount.PanelItems[dType];
                 if (e.ItemIndex != -1 && e.ItemIndex < collection.Count)
                 {
                    e.Item = collection[e.ItemIndex].ToListViewItem();
                    if (e.ItemIndex % 2 == 1)
                    {
                        e.Item.UseItemStyleForSubItems = false;
                        foreach (ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
                            subItem.BackColor = Color.FromArgb(213, 218, 224); //System.Drawing.Color.Azure;
                    }
                 }
            }
        }
        private void DisplayListView_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*  ListView listView = sender as ListView;
            if (listView != null)
            {
                if(listView == this.DomainListView)
                   this.IDomainEditButton.Enabled = this.IDomainRemoveButton.Enabled = (listView.SelectedIndices.Count > 0);
                if (listView == this.SubDomainListView)
                    this.ISubDomainEditButton.Enabled = this.ISubDomainRemoveButton.Enabled = (listView.SelectedIndices.Count > 0);
            }*/
        }
        private void DisplayListView_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {
            /*if (e.IsSelected)
            {
                ListView listView = sender as ListView;
                if (listView != null)
                {
                    listView.SelectedIndices.Clear();
                    for (int index = e.StartIndex; index <= e.EndIndex; index++)
                        listView.SelectedIndices.Add(index);
                    DisplayListView_SelectedIndexChanged(sender, null);
                }
            }*/
        }
        private void DisplayListView_Resize(object sender, EventArgs e)
        {
            ListView list = (sender as ListView);
            if (list != null && list.Columns.Count>0)
            {
                int chWidth = (list.Width / list.Columns.Count) - list.Columns.Count;
                foreach (ColumnHeader ch in list.Columns)
                    ch.Width = chWidth;
            }
        }

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        #endregion

        #region << Методы >>
        /// <summary>
        /// Метода получает список с объектами панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateList_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            IWebPanelBasicActions.IGet getObject = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;
            WebPanelItems.WebPanelItemCollection collection = WebPanelAccount.AccountManager.SelectAccount.PanelItems[(Type)e.Argument];
            worker.ReportProgress(99, "Пытаемся получить список.");
            collection.Clear();
            WebPanelActionResult.ActionResultBase result = getObject.Get(collection);
            if (!result)
            {
                worker.ReportProgress(0, String.Format("Во время получения списка произошла ошибка:[MCOLOR:Red]{0}[/MCOLOR].", result.ErrorMessage));
                e.Result = false;
            }
            else
            {
                e.Result = true;
            }
        }
        private void InitEventHandlers() 
        {
            this.AccountListView.MouseDoubleClick += new MouseEventHandler(AccountListView_MouseDoubleClick);
            this.AccountListView.SelectedIndexChanged += new EventHandler(AccountListView_SelectedIndexChanged);

            this.DomainListView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(DisplayListView_RetrieveVirtualItem);
            this.DomainListView.SelectedIndexChanged += new EventHandler(DisplayListView_SelectedIndexChanged);
            this.DomainListView.VirtualItemsSelectionRangeChanged += new ListViewVirtualItemsSelectionRangeChangedEventHandler(DisplayListView_VirtualItemsSelectionRangeChanged);
            this.DomainListView.Resize += new EventHandler(DisplayListView_Resize);

            this.SubDomainListView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(DisplayListView_RetrieveVirtualItem);
            this.SubDomainListView.SelectedIndexChanged += new EventHandler(DisplayListView_SelectedIndexChanged);
            this.SubDomainListView.VirtualItemsSelectionRangeChanged += new ListViewVirtualItemsSelectionRangeChangedEventHandler(DisplayListView_VirtualItemsSelectionRangeChanged);
            this.SubDomainListView.Resize += new EventHandler(DisplayListView_Resize);

            AccountManager.ManagerInstance.AccountChangeEvent += new EventHandler<BatchDomainTools.WebPanelCommons.AccountSelectEventArgs>(ManagerInstance_AccountChangeEvent);
            AccountManager.ManagerInstance.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ManagerInstance_CollectionChanged);
        }
        /// <summary>
        /// При изменении выбранного аккаунта изменяет UI под его поддерживаемые интерфейсы
        /// </summary>
        private void InitApiItemComponent(TabPage page, string Namespace, Type[] ifaces) 
        {
            bool isSupportedNamespace = ifaces.Any(t => t.Namespace.Equals(Namespace));
            foreach (Control ctrl in page.Controls)
            {
                if (ctrl is ToolStrip)
                {
                    DomainCTRLStrip.Enabled = true;
                    ToolStrip controlStrip = ctrl as ToolStrip;
                    if (controlStrip.Enabled = isSupportedNamespace)
                    {
                        for (int index = 0; index < controlStrip.Items.Count; index++)
                        {
                            if (controlStrip.Items[index] is ToolStripButton)
                            {
                                controlStrip.Items[index].Visible = ifaces.Any(t => t.FullName.Equals(controlStrip.Items[index].Tag.ToString()));
                            }
                        }
                    }
                }
                else if (ctrl is ListView)
                {
                    ListView displayList = ctrl as ListView;
                    if (displayList.Enabled = isSupportedNamespace)
                    {
                        Type displayType = (Type)displayList.Tag;
                        displayList.Columns.AddRange(AccountManager.SelectAccount.WebPanelAPI.GetViewTab(displayType));
                        displayList.VirtualListSize = AccountManager.SelectAccount.PanelItems[displayType].Count;
                        DisplayListView_Resize(displayList, null);
                    }
                }
            }
        }
        /// <summary>
        /// Метод связывает управляющие кнопки с интерфесами управления панели управления
        /// </summary>
        private void DesignateControlsInterfaces()
        {
            this.IDomainAddButton.Tag = typeof(IWebPanelObjectActions.IDomainActions.IDomainAdd).FullName;
            this.IDomainEditButton.Tag = typeof(IWebPanelObjectActions.IDomainActions.IDomainEdit).FullName;
            this.IDomainRemoveButton.Tag = typeof(IWebPanelObjectActions.IDomainActions.IDomainRemove).FullName;
            this.IDomainGetButton.Tag = typeof(IWebPanelObjectActions.IDomainActions.IDomainGet).FullName;

            this.ISubDomainAddButton.Tag = typeof(IWebPanelObjectActions.ISubDomainActions.ISubDomainAdd).FullName;
            this.ISubDomainEditButton.Tag = typeof(IWebPanelObjectActions.ISubDomainActions.ISubDomainEdit).FullName;
            this.ISubDomainRemoveButton.Tag = typeof(IWebPanelObjectActions.ISubDomainActions.ISubDomainRemove).FullName;
            this.ISubDomainGetButton.Tag = typeof(IWebPanelObjectActions.ISubDomainActions.ISubDomainGet).FullName;

            this.DomainListView.Tag = typeof(WebPanelItems.DomainItem);
            this.SubDomainListView.Tag = typeof(WebPanelItems.SubDomainItem);
        }
        /// <summary>
        /// Инициализируемы компоненты UI, которые должны инициализироваться только во время исполнения программы 
        /// </summary>
        private void InitCustumRuntimeUI()
        {
            /*this.imageList2.ImageSize = new Size(28, 28);
            this.imageList2.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.AddStrip(global::BatchDomainTools.Properties.Resources.ActionControlIcons28x28px);

            //this.ISubDomainAddButton.Image = this.IDomainAddButton.Image = this.imageList2.Images[0];
            this.ISubDomainGetButton.Image = this.IDomainGetButton.Image = this.imageList2.Images[0];
            this.ISubDomainEditButton.Image = this.IDomainEditButton.Image = this.imageList2.Images[2];
            this.ISubDomainRemoveButton.Image = this.IDomainRemoveButton.Image = this.imageList2.Images[1];*/

            this.WebPanelIcons.Images.Add(WebPanelModules.WebPanelType.cPanel.ToString(), global::BatchDomainTools.Properties.Resources.cPanel);
            this.WebPanelIcons.Images.Add(WebPanelModules.WebPanelType.ISPmanager.ToString(), global::BatchDomainTools.Properties.Resources.ISPmanager);
            this.WebPanelIcons.Images.Add(WebPanelModules.WebPanelType.DirectAdmin.ToString(), global::BatchDomainTools.Properties.Resources.DirectAdmin);
            this.menuStrip1.Renderer = new BatchDomainTools.UI.CustumBlackPRenderer();
        }
        private ListViewItem CastToListViewItem(Account account)
        {
            return new System.Windows.Forms.ListViewItem(new string[]
                    {  account.PanelAddr.ToString(),  
                       account.PanelAccountLogin,
                       account.PanelAccountPass,
                       account.PanelType.ToString()
                    }, account.PanelType.ToString());
        }
        #endregion
 
    }
}
