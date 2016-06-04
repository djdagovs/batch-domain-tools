using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;


namespace BatchDomainTools.WebPanelModules.DirectAdmin.API
{
    public partial class DirectAdminAPI : WebPanelApiBase
    {

        public DirectAdminAPI(BatchDomainTools.WebPanelAccount.Account _account)
            : base(_account) 
        {
            base.PanelType = WebPanelType.DirectAdmin;
        }

        protected override Uri BuildCommandQuery(string module, string function, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg)
        {
            UriBuilder ub = new UriBuilder(this.Account.PanelAddr);
            string args = string.Empty;
            foreach (string argNow in cArg)
                args += "&" + argNow;
            ub.Path += module;
            if (!string.IsNullOrEmpty(function))
                ub.Query += "action=" + function;
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
                return DirectAdmin.Items.DirectAdmin_Domain.ToListViewColumnHeader();
            }
            else if (typeof(SubDomainItem) == viewType)
            {
                return SubDomainItem.ToListViewColumnHeader();
            }
            return TabHeaders;
        }
    }
}
