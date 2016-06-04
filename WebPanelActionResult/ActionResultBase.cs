using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using BatchDomainTools.WebNet;

namespace BatchDomainTools.WebPanelActionResult
{
    public abstract class ActionResultBase
    {
        public delegate ActionResultCode DataNodeHandler(XmlNodeList dataNode);
        public delegate ActionResultCode DataTextHandler(string responce);

        #region << Поля и свойства >>

        protected Dictionary<ActionResultCode, string> KnowErrorTranscription = new Dictionary<ActionResultCode, string>() 
        {
           { ActionResultCode.Error_EmptyServerAnswer, "От сервера получена пустая строка" },
           { ActionResultCode.Error_WebConnection, "Соединения с сервером не установленно"},
           { ActionResultCode.Error_AuthError, "Не удалось войти в панель управления хостингом используя указанную пару логин/пароль" },
           { ActionResultCode.Error_WrongPanelPath, "Указан неверный путь к панели управления хостингом, не верное названия API функции, или API сервис отключен в панели управления хостингом"},
           { ActionResultCode.Error_ServerTimeout, "Превышен таймаут ответа от сервера"}
        };
        /// <summary>
        /// Статус-результат выполнения операциии
        /// </summary>
        public abstract ActionResultType ReturnType { get; }
        /// <summary>
        /// HTTP Status-Code в ответе сервера
        /// </summary>
        public HttpStatusCode ActionHttpStatusCode { get; private set; }
        /// <summary>
        /// HTTP заголовки в ответе
        /// </summary>
        public WebHeaderCollection ResponceHeaders { get; private set; }
        public virtual String ErrorMessage { get; protected set; }
        public virtual ActionResultCode ActionCode
        {
            get { return this._actionCode; }
            protected set 
            {
                if (this.KnowErrorTranscription.ContainsKey(value))
                {
                    this.ErrorMessage = KnowErrorTranscription[value];
                }
                this._actionCode = value;
            }
        }
        private ActionResultCode _actionCode;

        #endregion

        #region << Методы >>

        protected void ProcessResult(string _result)
        {
            if (this.ActionHttpStatusCode == HttpStatusCode.Forbidden) 
            {
                this.ActionCode = ActionResultCode.Error_AuthError;
                return;
            }
            else if (this.ActionHttpStatusCode == HttpStatusCode.NotFound || 
                     this.ActionHttpStatusCode == HttpStatusCode.MovedPermanently ||
                     this.ActionHttpStatusCode == HttpStatusCode.Moved ||
                     this.ActionHttpStatusCode == HttpStatusCode.Found) 
            {
                this.ActionCode = ActionResultCode.Error_WrongPanelPath;
                return;
            }
            if (string.IsNullOrEmpty(_result))
            {
                if(this.ReturnType != ActionResultType.Any && this.ReturnType != ActionResultType.PlainText)
                   this.ActionCode = ActionResultCode.Error_EmptyServerAnswer;
                return;
            }
            if (this.ReturnType != ActionResultType.Any && this.ReturnType != ActionResultType.PlainText)
            {
                _result = _result.Trim();
                if (this.ReturnType == ActionResultType.Xml)
                {
                    if (_result.StartsWith("<?xml"))
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(_result);
                        ProcessXmlResult(xml);
                    }
                    else 
                    {
                        this.ActionCode = ActionResultCode.Error_InvalidServerAnswer;
                        this.ErrorMessage = _result;
                    }
                }
            }
            else
                ProcessTextResult(_result);
        }
        protected virtual void ProcessXmlResult(XmlDocument _xmlDocument) 
        {
            throw new NotImplementedException("ProcessXmlResult Not Implemented!");
        }
        protected virtual void ProcessTextResult(String _string) 
        {
            throw new NotImplementedException("ProcessTextResult Not Implemented!");
        }
        public virtual void ExecuteQuery(HttpWebRequest _httpWebRequest) 
        {
            string serverAnswer = string.Empty;
            if (_httpWebRequest == null)
            {
                ActionCode = ActionResultCode.Error_WebConnection;
                return;
            }
            try
            {
                using (HttpWebResponse _httpWebResponse = (HttpWebResponse)_httpWebRequest.GetResponse())
                {
                    this.ActionHttpStatusCode = _httpWebResponse.StatusCode;
                    this.ResponceHeaders = _httpWebResponse.Headers;
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(_httpWebResponse.GetResponseStream()))
                    {
                        serverAnswer = sr.ReadToEnd();
                        ProcessResult(serverAnswer);
                    }
                }
            }
            catch (WebException wex)
            {
                this.ActionCode = ActionResultCode.Error_WebConnection;
                if (wex.Response != null)
                {
                    wex.Response.Close();
                    this.ActionHttpStatusCode = ((HttpWebResponse)wex.Response).StatusCode;
                    if (this.ActionHttpStatusCode == HttpStatusCode.Forbidden)
                        this.ActionCode = ActionResultCode.Error_AuthError;
                    else if (this.ActionHttpStatusCode == HttpStatusCode.NotFound)
                        this.ActionCode = ActionResultCode.Error_WrongPanelPath;
                }
                else
                {
                    if (wex.Status == WebExceptionStatus.Timeout)
                    {
                        this.ActionCode = ActionResultCode.Error_ServerTimeout;
                    }
                    this.ErrorMessage = wex.Message;
                }
            }
            catch (Exception ex)
            {
                this.ActionCode = ActionResultCode.Error_InternalProgramError;
                this.ErrorMessage = string.Format("\r\nПроизошла внутреняя ошибка приложения: {0}\r\n----------------------\r\n", ex.Message);
                this.ErrorMessage += string.Format("Стек вызовова на момент возникновения ошибки: {0}\r\n----------------------\r\n", ex.StackTrace);
                if(!string.IsNullOrEmpty(serverAnswer))
                    this.ErrorMessage += string.Format("Ответ сервера: {0}\r\n----------------------\r\n", serverAnswer);
            }
        }
        public void SetInternalProgramError(string errorMessage) 
        {
            this.ActionCode = ActionResultCode.Error_InternalProgramError;
            this.ErrorMessage = errorMessage;
        }
        public static implicit operator bool(ActionResultBase instance)
        {
            if (instance == null)
                return false;
            return instance.ActionCode == ActionResultCode.Success;
        }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.ErrorMessage))
                return this.ErrorMessage;
            else
                return this.ActionCode.ToString();
        }

        #endregion
  
    }

}
