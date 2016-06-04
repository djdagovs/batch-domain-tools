using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelModules;
using BatchDomainTools.WebPanelItems;
using System.Xml.Serialization;
using System.Runtime.Serialization;
 

namespace BatchDomainTools.WebPanelAccount
{
    [Serializable]
    public class Account : ISerializable
    {
        #region << Свойства и поля >>
        /// <summary>
        /// Объекты веб панели(домены, поддомены и etc.)
        /// TODO: Заменить Type на string, бессмыслено создавать целый класс для простой идентификации
        /// </summary>
        public Dictionary<Type, WebPanelItems.WebPanelItemCollection> PanelItems
        {
            get;
            private set;
        }

        /// <summary>
        /// Возвращает объект для работы с API панели управления
        /// </summary>
        public WebPanelApiBase WebPanelAPI
        {
            get;
            private set;
        }

        /// <summary>
        /// Возврашает сессию для входа в панель управления
        /// </summary>
        public BatchDomainTools.WebNet.WebNetCommunication.WebSession WebSession
        {
            get;
            private set;
        }

        /// <summary>
        /// Возвращает тип панели
        /// </summary>
        public WebPanelType PanelType 
        {
            get { return this.m_PanelType; }
        }
        WebPanelType m_PanelType;

        public WebPanelOptionData.IOptionData WebPanelAPIOptions 
        {
            get 
            {
                return Setting.WebPanelAPIoptions[this.PanelType];
            } 
        }

        /// <summary>
        /// Возвращает или устанавливает логин от панели
        /// </summary>
        public string PanelAccountLogin
        {
            get
            {
                if (this.m_PanelAccountLogin == null)
                    this.m_PanelAccountLogin = string.Empty;
                return this.m_PanelAccountLogin;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Логин не может быть пустым!");
                if (value != this.m_PanelAccountLogin)
                {
                    this.m_PanelAccountLogin = value;
                    this.WebSession.sessionHeader.Remove(System.Net.HttpRequestHeader.Authorization);
                    this.WebSession.sessionHeader[System.Net.HttpRequestHeader.Authorization] = "Basic " + this.ToBasicAuth();
                }
            }
        }
        private string m_PanelAccountLogin;

        /// <summary>
        /// Возвращает или устанавливает пароль от панели 
        /// </summary>
        public string PanelAccountPass
        {
            get
            {
                if (this.m_PanelAccountPass == null)
                    this.m_PanelAccountPass = string.Empty;
                return this.m_PanelAccountPass;
            }
            set
            {
                if (value != this.m_PanelAccountPass)
                {
                    this.m_PanelAccountPass = value;
                    this.WebSession.sessionHeader.Remove(System.Net.HttpRequestHeader.Authorization);
                    this.WebSession.sessionHeader[System.Net.HttpRequestHeader.Authorization] = "Basic " + this.ToBasicAuth();
                }
            }
        }
        private string m_PanelAccountPass;

        /// <summary>
        /// Возвращает или устанавливает адрес панели управления
        /// </summary>
        public Uri PanelAddr
        {
            get;
            set;
        }

        #endregion

        #region << ctor >>

        public Account(WebPanelType panelType) 
        {
            this.m_PanelType = panelType;
            switch (this.m_PanelType)
            {
                case WebPanelType.cPanel:
                    this.WebPanelAPI = new WebPanelModules.cPanel.API.cPanelAPI(this);
                    break;
                case WebPanelType.DirectAdmin:
                    this.WebPanelAPI = new WebPanelModules.DirectAdmin.API.DirectAdminAPI(this);
                    break;
                case WebPanelType.ISPmanager:
                    this.WebPanelAPI = new WebPanelModules.ISPmanager.Api.ISPmanagerAPI(this);
                    break;
            }
            Type[] ifaces = this.WebPanelAPI.GetType().GetInterfaces();
            this.PanelItems = new Dictionary<Type, WebPanelItemCollection>();
            if (ifaces.Any(inf => inf.Namespace == "BatchDomainTools.IWebPanelObjectActions.ISubDomainActions"))
                this.PanelItems.Add(typeof(WebPanelItems.SubDomainItem), new WebPanelItemCollection(typeof(WebPanelItems.SubDomainItem)));
            if (ifaces.Any(inf => inf.Namespace == "BatchDomainTools.IWebPanelObjectActions.IDomainActions"))
                this.PanelItems.Add(typeof(WebPanelItems.DomainItem), new WebPanelItemCollection(typeof(WebPanelItems.DomainItem)));
            this.WebSession = new BatchDomainTools.WebNet.WebNetCommunication.WebSession()
            {
                querySessionVars = new Dictionary<string, string>(),
                sessionCookie = new System.Net.CookieContainer(),
                sessionHeader = new System.Net.WebHeaderCollection()
            };
        }

        /// <summary>
        /// Конструктор, вызываемый при десериализации объекта
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Account(SerializationInfo info, StreamingContext context)
            : this((WebPanelType)info.GetValue("PanelType", typeof(WebPanelType)))
        {
            this.PanelAddr = (Uri)info.GetValue("PanelAddr", typeof(Uri));
            this.PanelAccountPass = (string)info.GetValue("PanelAccountPass", typeof(string));
            this.PanelAccountLogin = (string)info.GetValue("PanelAccountLogin", typeof(string));
        }

        #endregion

        #region << Методы >>
        /// <summary>
        /// Возвращает пару логин:пароль в формате пригодном для использования в HTTP заголовке Authorization: Basic
        /// </summary>
        public string ToBasicAuth()
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(this.PanelAccountLogin + ":" + this.PanelAccountPass));
        }

        public override string ToString()
        {
            return string.Format("{0}({1})" , this.m_PanelAccountLogin ,this.PanelAddr.DnsSafeHost);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Account);
        }

        public bool Equals(Account account)
        {
            if (account == null)
                return false;
            return this.PanelAddr.Equals(account.PanelAddr) && this.PanelAccountLogin.Equals(account.PanelAccountLogin);
        }

        public override int GetHashCode()
        {
            return this.PanelAddr.GetHashCode() + this.PanelAccountLogin.GetHashCode();
        }

        #endregion

        #region Члены ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PanelAddr",  this.PanelAddr, typeof(Uri));
            info.AddValue("PanelAccountPass", this.PanelAccountPass, typeof(string));
            info.AddValue("PanelAccountLogin",  this.PanelAccountLogin, typeof(string));
            info.AddValue("PanelType",  this.PanelType, typeof(WebPanelType));
        }

        #endregion
    }
}
