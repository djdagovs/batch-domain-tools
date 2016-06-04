using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons
{
    public class AccountSelectEventArgs : EventArgs
    {
        /// <summary>
        /// Статус выполнения операции выбора аккаунтов
        /// </summary>
        public SelectStatus Status { get; private set; }
        /// <summary>
        /// Индекс выбранного аккаунта
        /// </summary>
        public int SelectIndex { get; set; }
        /// <summary>
        /// Аккаунт, который выбран на данный момент
        /// </summary>
        public BatchDomainTools.WebPanelAccount.Account SelectAccount { get; set; }
        public AccountSelectEventArgs(SelectStatus status) 
        {
            this.Status = status;
        }
        public AccountSelectEventArgs(SelectStatus status, int selectIndex, BatchDomainTools.WebPanelAccount.Account account)
            : this(status)
        {
            this.SelectIndex = selectIndex;
            this.SelectAccount = account;
        }
    }

    public enum SelectStatus 
    {
        /// <summary>
        /// Процесс выбора аккаунтов начат
        /// </summary>
       start,
       /// <summary>
       /// Процесс выбора аккаунтов закончен
       /// </summary>
       end
    }
}
