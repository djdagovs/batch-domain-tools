using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelOptionData;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebPanelActionsTask;

namespace BatchDomainTools
{
    public partial class ActionsTaskForm : Form
    {
        #region << События >>

        public event EventHandler<SimpleEventArgs> FormClosedEvent;

        #endregion

        #region << Поля и свойства >>

        WebPanelItems.WebPanelItemCollection workCollection = null;
        WebPanelActionsTask.ActionTaskBase ActionBackGroundWorker = null;
        IOptionData PropertyData = null;
        Dictionary<string, string> desription;
        Type workType;
        ActionsType actionsType;
        
        #endregion

        #region << Ctor >>
        /// <summary>
        /// Создает экземпляр ActionsExecuteForm для удаления переданных элементов
        /// </summary>
        public ActionsTaskForm(WebPanelItemCollection ItemsToProcess) : this(ActionsType.Remove, ItemsToProcess, ItemsToProcess.CollectionType, null) { }
        /// <summary>
        /// Создает экземпляр ActionsExecuteForm для изменения переданных элементов
        /// </summary>
        public ActionsTaskForm(WebPanelItemCollection ItemsToProcess, WebPanelOptionData.IOptionData EditOptions) : 
            this(ActionsType.Edit, ItemsToProcess, ItemsToProcess.CollectionType, EditOptions) { }
        /// <summary>
        /// Создает экземпляр ActionsExecuteForm для добавления элементов указанного типа, использую дополнительные опции добавления
        /// </summary>
        public ActionsTaskForm(Type AddType, WebPanelOptionData.IOptionData AddOptions) :  this(ActionsType.Add, null, AddType, AddOptions) { }
        public ActionsTaskForm(ActionsType _actionsType, WebPanelItemCollection ItemsToProcess, Type _workType, WebPanelOptionData.IOptionData ExtOptions)
        {
            InitializeComponent();
            this.actionsType = _actionsType;
            if (this.actionsType == ActionsType.Add)
            {
                this.ActionBackGroundWorker = new WebPanelActionsTask.ActionAddTask();
                this.TaskTypePict.Image = global::BatchDomainTools.Properties.Resources.AddTaskIcon;
                this.Text = "Добавления новых объектов";
                this.desription = new Dictionary<string, string>() 
                {
                  { "Укажите объекты для добавления","Каждый добавляемый объект должен начинаться с новой строки"},
                  { "Вы можете указать параметры для добавляемых объектов","По умолчанию используются стандартные параметры для панели"},// из настроек программы"},
                  { "Все готово, можно начинать процесс добавления","Нажмите кнопку старта для начала процесса добавления"}
                };
            }
            else
            {
                if (this.actionsType == ActionsType.Edit)
                {
                    this.ActionBackGroundWorker = new WebPanelActionsTask.ActionEditTask();
                    this.TaskTypePict.Image = global::BatchDomainTools.Properties.Resources.EditTaskIcon;
                    this.Text = "Редактирование выделенных объектов";
                    this.desription = new Dictionary<string, string>() 
                    {
                      { "Укажите объекты для редактирования","Каждый редактируемый объект должен начинаться с новой строки"},
                      { "Измените параметры для редактируемых объектов","По умолчанию используются стандартные параметры для панели"},
                      { "Все готово, можно начинать процесс редактирования","Нажмите кнопку старта для начала процесса редактирования"}
                    };
                }
                else if (this.actionsType == ActionsType.Remove) 
                {
                    this.ActionBackGroundWorker = new WebPanelActionsTask.ActionRemoveTask();
                    this.TaskTypePict.Image = global::BatchDomainTools.Properties.Resources.DeleteTaskIcon;
                    this.Text = "Удаление выделенных объектов";
                    this.desription = new Dictionary<string, string>() 
                    {
                      { "Укажите объекты для удаления","Каждый удаляемый объект должен начинаться с новой строки"},
                      { "Измените параметры удаления объектов","По умолчанию будут использованны параметры из настроек программы"},
                      { "Можно начинать процесс удаления","Для начала процесса удаления нажмите на кнопку старта"}
                    };
                }
            }
            if (ExtOptions == null)
            {
                this.tablessControl1.TabPages.Remove(this.PropertyChangeTabPage);
                this.desription.Remove(this.desription.ElementAt(1).Key);
            }
            else
            {
                this.PropertyData = ExtOptions;
                this.OptionsGrid.SelectedObject = this.PropertyData;
                this.OptionsGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(OprionsGrid_PropertyValueChanged);
            }
            this.tablessControl1.SelectedIndexChanged += new EventHandler(tablessControl1_SelectedIndexChanged);
            this.ActionBackGroundWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            this.ActionBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ActionBackGroundWorker_RunWorkerCompleted);
            this.workType = _workType;
            this.panel3.Paint += new PaintEventHandler((_sender, _e) =>
            {
                ControlPaint.DrawBorder(_e.Graphics, _e.ClipRectangle, 
                                        Color.Transparent, 0, ButtonBorderStyle.None, 
                                        Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid, 
                                        Color.Transparent, 0, ButtonBorderStyle.None, 
                                        Color.Transparent, 0, ButtonBorderStyle.None);
            });
            this.panel2.Paint += new PaintEventHandler((__sender, __e) =>
            {
                ControlPaint.DrawBorder(__e.Graphics, __e.ClipRectangle, 
                                        Color.Transparent, 0,  ButtonBorderStyle.None,
                                        Color.Transparent, 0, ButtonBorderStyle.Solid, 
                                        Color.Transparent, 0, ButtonBorderStyle.None,
                                        Color.FromArgb(223, 223, 223), 1, ButtonBorderStyle.Solid);
            });
            this.TitleLabel.Text = desription.ElementAt(this.tablessControl1.SelectedIndex).Key;
            this.Desriptionlabel.Text = desription.ElementAt(this.tablessControl1.SelectedIndex).Value;
            if(ItemsToProcess!=null)
            {
                this.DomaintBox.Lines = ItemsToProcess.ToStringArray();
            }
        }
        #endregion

        #region << Form control event handler-s >>

        #region << Остальные обрабочики событий формы >>
        private void OprionsGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Type classType = e.ChangedItem.PropertyDescriptor.ComponentType;
            PropertyInfo propertyInfo = classType.GetProperty(e.ChangedItem.PropertyDescriptor.Name);
            if (propertyInfo != null)
            {
                object[] attributes = propertyInfo.GetCustomAttributes(true);
                if (attributes != null && attributes.Length > 0)
                {
                    foreach (object attribute in attributes)
                    {
                        BatchDomainTools.WebPanelCommons.CharValidateAttribute CharValidate = attribute as BatchDomainTools.WebPanelCommons.CharValidateAttribute;
                        if (CharValidate != null)
                        {
                            if (!CharValidate.IsHasBadChars(e.ChangedItem.Value))
                            {
                                propertyInfo.SetValue(OptionsGrid.SelectedObject, e.OldValue, null);
                                MessageBox.Show(CharValidate.ErrorMessage, "Некорректные данные!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            if (e.ChangedItem.Value is string[]) 
            {
                List<string> value = new List<string>((IEnumerable<string>)e.ChangedItem.Value);
                value.RemoveAll(x=>String.IsNullOrEmpty(x));
                value = value.Distinct().ToList();
                propertyInfo.SetValue(OptionsGrid.SelectedObject, value.ToArray(), null);
            }
        }
        private void tablessControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonStepForward.Enabled = (this.tablessControl1.SelectedIndex != this.tablessControl1.TabPages.Count - 1 &&
                                                  !string.IsNullOrEmpty(this.DomaintBox.Text));
            this.buttonStepBack.Enabled = (this.tablessControl1.SelectedIndex != 0);
            this.TitleLabel.Text = desription.ElementAt(this.tablessControl1.SelectedIndex).Key;
            this.Desriptionlabel.Text = desription.ElementAt(this.tablessControl1.SelectedIndex).Value;
            panel2.Refresh();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.ActionBackGroundWorker.IsBusy) 
            {
                if (MessageBox.Show("Процесс добавления еще не закончен, остановить процесс добавления?", 
                                    "Подтверждения", 
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question) == DialogResult.OK) 
                {
                    StopAddButton_Click(null, null);
                }
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.Hide();
            if (this.FormClosedEvent != null) 
            {
               this.FormClosedEvent(this, new SimpleEventArgs() { EventArg = this.CloseFormListUpdate.Checked });
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ++this.tablessControl1.SelectedIndex;
        }
        private void buttonStepBack_Click(object sender, EventArgs e)
        {
            --this.tablessControl1.SelectedIndex;
        }
        #endregion

        #region << Обработчики события вкладки с доменами >>
        private void DomaintBox_TextChanged(object sender, EventArgs e)
        {
            this.buttonStepForward.Enabled = this.tablessControl1.SelectedIndex != this.tablessControl1.TabPages.Count - 1 &&
                                             (this.StartAddButton.Enabled = !string.IsNullOrEmpty(this.DomaintBox.Text));
        }
        private void AddFromBuffer_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Clipboard.ContainsText())
            {
                this.DomaintBox.Text += System.Windows.Forms.Clipboard.GetText();
            }
        }

        private void AddFromFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openDomainFileDialog = new System.Windows.Forms.OpenFileDialog();
            openDomainFileDialog.Title = "Выбирите файл с объектами";
            openDomainFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDomainFileDialog.FilterIndex = 1;
            openDomainFileDialog.RestoreDirectory = true;
            openDomainFileDialog.CheckFileExists = openDomainFileDialog.DereferenceLinks = openDomainFileDialog.CheckPathExists = true;
            if (openDomainFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                !string.IsNullOrEmpty(openDomainFileDialog.SafeFileName))
            {
                this.DomaintBox.Text += System.IO.File.ReadAllText(openDomainFileDialog.FileName);
            }
        }

        private void CleenDomainTBox_Click(object sender, EventArgs e)
        {
            DomaintBox.Text = String.Empty;
        }

        #endregion

        #region << Обработчики события вкладки добавления и результатов работы >>
        private void StartActionsButton_Click(object sender, EventArgs e)
        {
            this.LogRTBox.Clear();
            this.ProgressListBox.Items.Clear();
            this.workCollection = new WebPanelItemCollection(this.workType);
            System.Text.RegularExpressions.Regex domainPatern = new System.Text.RegularExpressions.Regex(".+\\..{2,8}$");
            for (int id = 0; id < this.DomaintBox.Lines.Length; id++)
            {
                string Domain = this.DomaintBox.Lines[id].Trim().ToLower().Replace("https://", "").Replace("http://", "");
                int foundSlashSubdomain = Domain.IndexOf("/");
                if (foundSlashSubdomain != -1)
                {
                    Domain = Domain.Remove(foundSlashSubdomain, Domain.Length - foundSlashSubdomain);
                }
                if (Domain.StartsWith("www."))
                {
                    Domain = Domain.TrimStart('w', '.');
                }
                if (!String.IsNullOrEmpty(Domain) && domainPatern.IsMatch(Domain))
                {
                    this.ProgressListBox.Items.Add(new ListViewItem(Domain) { Name = Domain });
                    this.workCollection.Add(new WebPanelItems.DomainItem(Domain));
                }
            }
            this.DomaintBox.Lines = this.workCollection.ToStringArray();
            if (this.workCollection.Count == 0)
            {
                this.StartAddButton.Enabled = false;
                MessageBox.Show("Прежде чем продолжить, укажите объекты для добавления в правильном формате!");
                this.tablessControl1.SelectedIndex = 0;
                return;
            }
            this.StopAddButton.Enabled = !(this.buttonStepBack.Enabled = this.StartAddButton.Enabled = false);

            this.LogRTBox.WriteToLog("Процесс начат.");
            this.ActionBackGroundWorker.PropertyData = this.PropertyData;
            this.ActionBackGroundWorker.RunWorkerAsync(this.workCollection);
        }
        private void StopAddButton_Click(object sender, EventArgs e)
        {
            this.StopAddButton.Enabled = false;
            this.ActionBackGroundWorker.CancelAsync();
        }
        #endregion

        #region << Обработчики события BackGroundWorker-а >>
        private void ActionBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.StopAddButton.Enabled = !(this.buttonStepBack.Enabled = true);
            this.StartAddButton.Enabled = this.workCollection.Count > 0;
            if(e.Cancelled)
                this.LogRTBox.WriteToLog("Процесс отменен пользователем.");
            else
                this.LogRTBox.WriteToLog(String.Format("Процесс завершен({0}).", e.Result.ToString()));
            this.DomaintBox.Lines = this.workCollection.ToStringArray();
            this.CloseFormListUpdate.Checked = true;
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string) 
            {
                this.LogRTBox.WriteToLog(e.UserState.ToString());
            }
            else if (e.UserState is ReportProgressStruct)
            {
                ReportProgressStruct state = (ReportProgressStruct)e.UserState;
                ListViewItem item = this.ProgressListBox.Items[BatchDomainTools.WebPanelItems.DomainItem.PunyDecode(state.ItemName)];
                if (item != null)
                {
                    switch (state.status)
                    {
                        case ViewStatus.Success:
                            item.ImageKey = "Success";
                            break;
                        case ViewStatus.Select:
                            item.ImageKey = "Select";
                            break;
                        case ViewStatus.Error:
                            item.ImageKey = "Error";
                            break;
                    }
                }
                if(!string.IsNullOrEmpty(state.Message))
                    this.LogRTBox.WriteToLog(state.Message);
            }
            if(e.ProgressPercentage >= 0 && e.ProgressPercentage <= 100)
               this.AddProgressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #endregion

        #region << Методы >>
 
        #endregion

        public enum ActionsType 
        {
           Add,
           Remove,
           Edit
        }

    }
}
