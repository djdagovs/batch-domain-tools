using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelActionResult;

namespace BatchDomainTools.WebPanelActionsTask
{
    public class ActionRemoveTask : ActionTaskBase
    {
        #region << Поля и свойства >>

        IWebPanelBasicActions.IRemove RemoveInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;
        IWebPanelBasicActions.IGet GetInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;

        #endregion

        #region << ctor >>

        public ActionRemoveTask() 
        {
            base.SuccessMessage = "Успешно удален.";
            base.ErrorMessage = "При удалении произошла ошибка - ";
            base.ResultDelegates.Add(ActionResultCode.Error_ServerTimeout, ActionResultCode_Error_ServerTimeout);
        }

        #endregion

        protected override void OnDoWork2(System.ComponentModel.DoWorkEventArgs e)
        {
            PrepareData();
            for (this.CurrentIndex = 0; this.CurrentIndex < base.Quenu.Count; this.CurrentIndex++)
            {
                if (base.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                WebPanelItems.WebPanelItemBase workObject = this.Quenu[this.CurrentIndex];
                OnProgressChanged("", ViewStatus.Select);
                base.ProcessResult(RemoveInstance.RemoveOject(workObject), workObject);
                TimeOut();
            }
            this.ReportProgress(100);
        }

        private void ActionResultCode_Error_ServerTimeout(ActionResultBase result, WebPanelItems.WebPanelItemBase item) 
        {
            OnProgressChanged(result.ErrorMessage + ".Проверяем был удален или нет.", ViewStatus.ErrorNotCritical);
            if (!GetInstance.Exist(item))
            {
                base.ActionResultCode_Success(result);
            }
            else
            {
                OnProgressChanged("Объект не был удален, пробуем еще раз.", ViewStatus.ErrorNotCritical);
                this.CurrentIndex--;
            }
        }
    }
}
