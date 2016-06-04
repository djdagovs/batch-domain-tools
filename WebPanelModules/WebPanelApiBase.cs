using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BatchDomainTools.WebNet;
using BatchDomainTools.IWebPanelBasicActions;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelOptionData;

namespace BatchDomainTools.WebPanelModules
{
    /// <summary>
    /// TODO: Перенисти все интерфейсы в универсальную коллекцию <T> и возвращать из нее объекты
    /// </summary>
    public abstract class WebPanelApiBase : IAdd, IGet, IRemove, IEdit
    {
        #region << Свойства >>

        /// <summary>
        /// Аккаунт для 
        /// </summary>
        protected BatchDomainTools.WebPanelAccount.Account Account;

        /// <summary>
        /// TODO: убрать это свойства или найти ему РЕАЛЬНОЕ приминения
        /// </summary>
        public WebPanelType PanelType {  get; protected set; }

        #endregion

        #region << ctor >>

        public WebPanelApiBase(BatchDomainTools.WebPanelAccount.Account _account) 
        {
            if (_account == null)
                throw new ArgumentNullException("_account!");
            this.Account = _account;
        }

        #endregion

        #region << Методы >>

        protected abstract Uri BuildCommandQuery(string module, string function, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg);
        public abstract System.Windows.Forms.ColumnHeader[] GetViewTab(Type viewType);

        #endregion

        #region << Члены IAdd >>

        ActionResultBase IAdd.Add(WebPanelItemBase addObject, IOptionData properties)
        {
            if (addObject is SubDomainItem && this is IWebPanelObjectActions.ISubDomainActions.ISubDomainAdd)
            {
                return ((IWebPanelObjectActions.ISubDomainActions.ISubDomainAdd)this).Add(addObject as SubDomainItem, properties);
            }
            else if (addObject is DomainItem && this is IWebPanelObjectActions.IDomainActions.IDomainAdd)
            {
                return ((IWebPanelObjectActions.IDomainActions.IDomainAdd)this).Add(addObject as DomainItem, properties);
            }
            throw new ArgumentException("Not Supported add object type!");
        }

        #endregion

        #region << Члены IGet >>

        ActionResultBase IGet.Get(WebPanelItemCollection saveCollection)
        {
            if (saveCollection.CollectionType == typeof(SubDomainItem) && this is IWebPanelObjectActions.ISubDomainActions.ISubDomainGet)
            {
                return ((IWebPanelObjectActions.ISubDomainActions.ISubDomainGet)this).Get(saveCollection);
            }
            else if (saveCollection.CollectionType == typeof(DomainItem) && this is IWebPanelObjectActions.IDomainActions.IDomainGet)
            {
                return ((IWebPanelObjectActions.IDomainActions.IDomainGet)this).Get(saveCollection);
            }
            throw new ArgumentException("Not Supported object type!");
        }

        ActionResultBase IGet.Exist(WebPanelItemBase panelObject)
        {
            if (panelObject is SubDomainItem && this is IWebPanelObjectActions.ISubDomainActions.ISubDomainGet)
            {
                return ((IWebPanelObjectActions.ISubDomainActions.ISubDomainGet)this).Exist(panelObject as SubDomainItem);
            }
            else if (panelObject is DomainItem && this is IWebPanelObjectActions.IDomainActions.IDomainGet)
            {
                return ((IWebPanelObjectActions.IDomainActions.IDomainGet)this).Exist(panelObject as DomainItem);
            }
            throw new ArgumentException("Not Supported object type!");
        }

        #endregion

        #region << Члены IRemove >>

        ActionResultBase IRemove.RemoveOject(WebPanelItemBase ObjectToRemove)
        {
            if (ObjectToRemove is SubDomainItem && this is IWebPanelObjectActions.ISubDomainActions.ISubDomainRemove)
            {
                return ((IWebPanelObjectActions.ISubDomainActions.ISubDomainRemove)this).RemoveOject(ObjectToRemove as SubDomainItem);
            }
            else if (ObjectToRemove is DomainItem && this is IWebPanelObjectActions.IDomainActions.IDomainRemove)
            {
                return ((IWebPanelObjectActions.IDomainActions.IDomainRemove)this).RemoveOject(ObjectToRemove as DomainItem);
            }
            throw new ArgumentException("Not supported object type!");
        }

        #endregion

        #region << Члены IEdit >>

        ActionResultBase IEdit.Edit(WebPanelItemBase editObject, IOptionData properties)
        {
            if (editObject is SubDomainItem && this is IWebPanelObjectActions.ISubDomainActions.ISubDomainEdit)
            {
                return ((IWebPanelObjectActions.ISubDomainActions.ISubDomainEdit)this).Edit(editObject as SubDomainItem, properties);
            }
            else if (editObject is DomainItem && this is IWebPanelObjectActions.IDomainActions.IDomainEdit)
            {
                return ((IWebPanelObjectActions.IDomainActions.IDomainEdit)this).Edit(editObject as DomainItem, properties);
            }
            throw new ArgumentException("Not Supported object type!");
        }

        #endregion
    }
}
