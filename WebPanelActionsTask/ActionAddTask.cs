using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelActionResult;

namespace BatchDomainTools.WebPanelActionsTask
{
    public class ActionAddTask : ActionTaskBase
    {
        #region << Поля и свойства >>

        IWebPanelBasicActions.IAdd AddInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;
        IWebPanelBasicActions.IGet GetInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;

        #endregion

        #region << ctor >>

        public ActionAddTask() 
        {
            base.ResultDelegates.Add(ActionResultCode.Error_ItemAlreadyExist, ActionResultCode_Error_ObjectAlreadyExist);
            base.ResultDelegates.Add(ActionResultCode.Error_ServerTimeout, ActionResultCode_Error_ServerTimeout);
            base.SuccessMessage = "Успешно добавлен.";
            base.ErrorMessage = "При добавлении произошла ошибка - ";
        }

        #endregion

        #region << Ovverided методы >>

        protected override void OnDoWork2(System.ComponentModel.DoWorkEventArgs e)
        {
            ActionResultBase result = null;
            WebPanelItemCollection TopDomainList = null;
            if (this.Quenu.CollectionType == typeof(SubDomainItem))
            {
                this.ReportProgress(0, "Получаем список основных доменов.");
                TopDomainList = new WebPanelItemCollection(typeof(DomainItem));
                if (!(result = this.GetInstance.Get(TopDomainList)))
                {
                    this.ReportProgress(0, string.Format("[MCOLOR:Red]Не удалось получить список основных доменов:{0}[/MCOLOR]", result.ErrorMessage));
                    this.CancelAsync();
                    return;
                }
                if (TopDomainList.Count == 0)
                {
                    this.ReportProgress(0, "[MCOLOR:Red]Не обнаруженно основных доменов. Невозможно добавит поддомены не имея основных доменов.[/MCOLOR]");
                    this.CancelAsync();
                    return;
                }
            }
            for (this.CurrentIndex = 0; this.CurrentIndex < base.Quenu.Count; this.CurrentIndex++)
            {
                if (base.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                WebPanelItems.WebPanelItemBase workObject = this.Quenu[this.CurrentIndex];
                OnProgressChanged("",ViewStatus.Select);
                if (TopDomainList != null)
                {
                    workObject = WebPanelItems.SubDomainItem.FindAndMake(workObject.Name, TopDomainList);
                    if (workObject == null)
                    {
                        OnProgressChanged("Не возможно добавить поддомен, поскольку не найден основной домен.", ViewStatus.Error);
                        continue;
                    }
                }
                result = AddInstance.Add(workObject, base.PropertyData);
                base.ProcessResult(result,workObject);
                TimeOut();
            }
            this.ReportProgress(100);
        }

        #endregion

        #region << Делегаты результатов операции >>

        /// <summary>
        /// Метод вызывается при попытки добавить объект, который уже есть в панели управления
        /// </summary>
        private void ActionResultCode_Error_ObjectAlreadyExist(ActionResultBase result, WebPanelItems.WebPanelItemBase item) 
        {
            OnProgressChanged("Уже добавлен!", ViewStatus.ErrorNotCritical);
            base.ActionResultCode_Success(result);
        }
        /// <summary>
        /// Метод вызывается при успешной попытки добавления объекта
        /// </summary>
        private void ActionResultCode_Error_ServerTimeout(ActionResultBase result, WebPanelItems.WebPanelItemBase item)
        {
            OnProgressChanged(result.ErrorMessage + ". Проверяем был добавлен или нет.", ViewStatus.ErrorNotCritical);
            if (GetInstance.Exist(item))
            {
                base.ActionResultCode_Success(result);
            }
            else
            {
                OnProgressChanged("Не добавлен, пробуем еще раз.", ViewStatus.ErrorNotCritical);
                this.CurrentIndex--;
            }
        }

        #endregion
    }
}
