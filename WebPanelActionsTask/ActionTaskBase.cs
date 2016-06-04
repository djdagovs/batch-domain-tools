using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BatchDomainTools.WebPanelActionResult;

namespace BatchDomainTools.WebPanelActionsTask
{
    public abstract class ActionTaskBase : BackgroundWorker
    {
        #region << Поля и свойства >>
        /// <summary>
        /// Сообщения при успешно выполненной операции
        /// </summary>
        protected string SuccessMessage = "";
        /// <summary>
        /// Сообщения при не удачно выполненной операции
        /// </summary>
        protected string ErrorMessage = "";
        /// <summary>
        /// Очередь с элементами для обработки
        /// </summary>
        protected WebPanelItems.WebPanelItemCollection Quenu;
        /// <summary>
        /// Общее число элементов очереди в самом начале операции
        /// </summary>
        protected decimal TotalQuenuCount;
        /// <summary>
        /// Процент выполненной операций
        /// </summary>
        protected volatile int ProgressPercentage;
        /// <summary>
        /// Дополнительные опции объектов в очереди
        /// </summary>
        public WebPanelOptionData.IOptionData PropertyData { get; set; }
        /// <summary>
        /// Текущий индекс в очереди для обработки
        /// </summary>
        protected int CurrentIndex 
        {
            get { return this.m_CurrentIndex; }
            set 
            {
                this.m_CurrentIndex = value;
                ReCountProgressPercentage(this.m_CurrentIndex);
            }
        }
        private int m_CurrentIndex;
        /// <summary>
        /// Результат выполнения операции
        /// </summary>
        protected string Result;

        protected readonly Dictionary<ViewStatus, string> MessagesTypeFormat = new Dictionary<ViewStatus, string>() 
        {
           {ViewStatus.Select, ""},
           {ViewStatus.Error, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:Red]{1}[/MCOLOR]"},
           {ViewStatus.Success, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:White]{1}[/MCOLOR]"},
           {ViewStatus.ErrorNotCritical, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:Red]{1}[/MCOLOR]"},
        };
        public delegate void ResultAction(ActionResultBase result, WebPanelItems.WebPanelItemBase item);
        protected Dictionary<ActionResultCode, ResultAction> ResultDelegates = new Dictionary<ActionResultCode, ResultAction>() { };

        #endregion

        #region << Методы >>

        /// <summary>
        /// Метод пересчитывает процент выполненной оперции
        /// </summary>
        protected virtual void ReCountProgressPercentage(int CurrentIndex) 
        {
            if(this.Quenu.Count!=0)
              this.ProgressPercentage = 100 - (int)Math.Ceiling(((this.Quenu.Count - CurrentIndex) / this.TotalQuenuCount) * 100);
        } 
        /// <summary>
        /// Метод обрабатывает результат выполнеия оцерации над объектом из очереди
        /// </summary>
        /// <param name="result"></param>
        protected void ProcessResult(ActionResultBase result, WebPanelItems.WebPanelItemBase item) 
        {
            if (ResultDelegates.ContainsKey(result.ActionCode))
            {
                ResultDelegates[result.ActionCode](result, item);
            }
            else 
            {
                if (result)
                    this.ActionResultCode_Success(result);
                else
                    this.ActionResultCode_ErrorBasic(result);
            }
        }

        protected void TimeOut() 
        {
            if (Setting.SettingInstance.QueryPause != 0 && this.Quenu.Count > 0 && this.Quenu.Count - 1 != this.CurrentIndex)
            {
                int sleepCount = Setting.SettingInstance.QueryPause;
                while (!this.CancellationPending && sleepCount > 0)
                {
                    System.Threading.Thread.Sleep(500);
                    sleepCount -= 500;
                }
            }
        }

        protected virtual void PrepareData() 
        {
            if (this.PropertyData is WebPanelOptionData.ISPmanager_DomainOption)
            {
                BatchDomainTools.WebPanelOptionData.ISPmanager_DomainOption options = this.PropertyData as WebPanelOptionData.ISPmanager_DomainOption;
                if (options.IPAddrs == null || options.IPAddrs.Length == 0)
                {
                    try
                    {
                        options.IPAddrs = new string[] {
                           System.Net.Dns.GetHostAddresses(WebPanelAccount.AccountManager.SelectAccount.PanelAddr.DnsSafeHost)[0].ToString()
                        };
                    }
                    catch (Exception ex)
                    {
                        this.ReportProgress(0,string.Format("[MCOLOR:Red]Не удалось получить основной IP адрес для веб-панели ISPmanager:{0}[/MCOLOR]", ex.Message));
                        this.CancelAsync();
                        return;
                    }
                }
            }
            if (this is ActionEditTask || this is ActionRemoveTask)
            {
                IWebPanelBasicActions.IGet GetInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;
                WebPanelItems.WebPanelItemCollection TempCollection = new BatchDomainTools.WebPanelItems.WebPanelItemCollection(this.Quenu.CollectionType);
                ActionResultBase result = GetInstance.Get(TempCollection);
                if (!result)
                {
                    this.ReportProgress(0,
                        String.Format("[MCOLOR:Red]Не удалось получить список для сопоставления объектов: {0}[/MCOLOR]", result.ErrorMessage));
                    this.CancelAsync();
                    return;
                }
                if (TempCollection.Count == 0) 
                {
                    this.ReportProgress(0, "[MCOLOR:Red]В хостинг панели нет указанных объектов .[/MCOLOR]");
                    this.CancelAsync();
                    return;
                }
                for (int iNeddle = 0; iNeddle < this.Quenu.Count; iNeddle++)
                {
                    for (int iHaystack = 0; iHaystack < TempCollection.Count; iHaystack++)
                    {
                        if (this.Quenu[iNeddle].Equals(TempCollection[iHaystack])) 
                        {
                            this.Quenu[iNeddle] = TempCollection[iHaystack];
                            TempCollection.RemoveAt(iHaystack);
                            break;
                        }
                    }
                }
            }
        }

        protected abstract void OnDoWork2(System.ComponentModel.DoWorkEventArgs e);

        #endregion

        #region << Ctor >>

        public ActionTaskBase() 
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        #endregion

        #region << ActionResultCode делегаты обработчики >>

        protected virtual void ActionResultCode_Success(ActionResultBase result) 
        {
            OnProgressChanged(this.SuccessMessage, ViewStatus.Success);
            this.Quenu.RemoveAt(this.CurrentIndex);
            this.CurrentIndex--;
        }

        protected virtual void ActionResultCode_ErrorBasic(ActionResultBase result)
        {
            OnProgressChanged(ErrorMessage + result.ErrorMessage, ViewStatus.Error);
            if (result.ActionCode == ActionResultCode.Error_AuthError)
                this.CancelAsync();
        }

        #endregion

        #region << Ovverided Методы >>

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            this.Quenu = (BatchDomainTools.WebPanelItems.WebPanelItemCollection)e.Argument;
            this.TotalQuenuCount = this.Quenu.Count;
            PrepareData();
            OnDoWork2(e);
        }

        protected virtual void OnProgressChanged(string Message, ViewStatus viStatus)
        {
            ReportProgressStruct progRepo = new ReportProgressStruct();
            progRepo.ItemName = this.Quenu[this.CurrentIndex].Name;
            progRepo.Message = String.Format(MessagesTypeFormat[viStatus], progRepo.ItemName, Message);
            progRepo.status = viStatus;
            this.ReportProgress(this.ProgressPercentage, progRepo);
        }

        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            string Result = string.Format("{0}/{1}", this.TotalQuenuCount-this.Quenu.Count, this.TotalQuenuCount);
            RunWorkerCompletedEventArgs _e = new RunWorkerCompletedEventArgs(Result, e.Error, e.Cancelled);
            base.OnRunWorkerCompleted(_e);
        }

        #endregion
   
    }
}
