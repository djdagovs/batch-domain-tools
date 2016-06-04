using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons
{
    public class ReportProgress
    {
        #region << Поля и свойства >>
        /// <summary>
        /// Имя текущего элемента
        /// </summary>
        public string ItemNameNow { get; set; }
  
        private string m_message;
        public string MessageReport 
        {
            get 
            {
                if (string.IsNullOrEmpty(this.m_message))
                    return this.m_message;
                return string.Format(MessagesTypeFormat[this.Status], ItemNameNow, m_message);
            }
        }
        /// <summary>
        /// Текущее статус 
        /// </summary>
        public ObjectViewStatus Status { get; set; }

        private readonly Dictionary<ObjectViewStatus, string> MessagesTypeFormat = new Dictionary<ObjectViewStatus, string>() 
        {
           {ObjectViewStatus.Select, ""},
           {ObjectViewStatus.Error, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:Red]{1}[/MCOLOR]"},
           {ObjectViewStatus.Success, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:White]{1}[/MCOLOR]"},
           {ObjectViewStatus.ErrorNotCritical, "[MCOLOR:Yellow]<{0}>[/MCOLOR]: [MCOLOR:Red]{1}[/MCOLOR]"},
        };

        #endregion

        #region << ctor >>

        public ReportProgress(int _totalItemName, ObjectViewStatus status)
        {
            this.Status = status;
        }

        #endregion

        #region << Методы >>

        /// <summary>
        /// Меняем текущее сообщения
        /// </summary>
        /// <param name="Message"></param>
        public void ChangeMessageReport(string Message)
        {
            this.m_message = Message;
        }
        /// <summary>
        /// Метод меняет текущее сообщения и статус
        /// </summary>
        /// <param name="Message"></param>
        public void ChangeMessageReport(string Message, ObjectViewStatus status) 
        {
            this.m_message = Message;
            this.Status = status;
        }
        /// <summary>
        /// Метод меняем текущее сообщения и вызывает делегат сообщения и передавая все необходимые данные
        /// </summary>
        public void MakeReport(string Message) 
        {
            MakeReport(Message);
        }
        /// <summary>
        /// Метод меняем текущее сообщения и вызывает делегат сообщения и передавая все необходимые данные
        /// </summary>
        public void MakeReport(string Message, ObjectViewStatus status)
        {
            ChangeMessageReport(Message, status);
        }

        #endregion

        public enum ObjectViewStatus
        {
            Select,
            Success,
            Error,
            ErrorNotCritical
        }

        public struct ReportProgressStruct 
        {
            public ObjectViewStatus status;
            public string messages;
        }
    }

}
