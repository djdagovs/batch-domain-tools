using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;

namespace BatchDomainTools.WebPanelActionsTask
{
    public class ActionEditTask : ActionTaskBase
    {
        public ActionEditTask() 
        {
            base.SuccessMessage = "Успешно изменен.";
            base.ErrorMessage = "При изменении произошла ошибка - ";
        }

        protected override void OnDoWork2(System.ComponentModel.DoWorkEventArgs e)
        {
            IWebPanelBasicActions.IEdit EditInstance = WebPanelAccount.AccountManager.SelectAccount.WebPanelAPI;
            for (this.CurrentIndex = 0; this.CurrentIndex < base.Quenu.Count; this.CurrentIndex++)
            {
                if (base.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                WebPanelItems.WebPanelItemBase workObject = this.Quenu[this.CurrentIndex];
                OnProgressChanged("", ViewStatus.Select);
                base.ProcessResult(EditInstance.Edit(workObject, this.PropertyData), workObject);
                TimeOut();
            }
            this.ReportProgress(100);
        }

    }
}
