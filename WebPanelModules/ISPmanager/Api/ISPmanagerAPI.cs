using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;

namespace BatchDomainTools.WebPanelModules.ISPmanager.Api
{
    public partial class ISPmanagerAPI : WebPanelApiBase
    {
        #region << Поля и свойства >>


        #endregion

        #region << Ctor >>
        public ISPmanagerAPI(BatchDomainTools.WebPanelAccount.Account _account)
            : base(_account) 
        {
            base.PanelType = WebPanelType.ISPmanager;
        }
        #endregion

        #region << Методы >>

        protected override Uri BuildCommandQuery(string module, string function, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg)
        {
            return BuildCommandQuery(module, cArg);
        }
        
        protected Uri BuildCommandQuery(string module, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg)
        {
            UriBuilder ub = new UriBuilder(this.Account.PanelAddr);
            string args = string.Empty;
            foreach (string argNow in cArg)
                args += "&" + argNow;
            ub.Path += "ispmgr";
            ub.Query = string.Format("authinfo={0}:{1}&func={2}&out=xml&sok=yes", base.Account.PanelAccountLogin, base.Account.PanelAccountPass, module);
            if (!string.IsNullOrEmpty(args))
                ub.Query += args;
            ub.Query = ub.Query.TrimStart('?').TrimStart('&');
            return ub.Uri;
        }

        public override System.Windows.Forms.ColumnHeader[] GetViewTab(Type viewType)
        {
            System.Windows.Forms.ColumnHeader[] TabHeaders = null;
            if (typeof(DomainItem) == viewType)
            {
                return ISPmanager.Items.ISPmanager_Domain.ToListViewColumnHeader();
            }
            else if (typeof(SubDomainItem) == viewType)
            {
                return SubDomainItem.ToListViewColumnHeader();
            }
            return TabHeaders;
        }

        #endregion
    }
}
