using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;

namespace BatchDomainTools.WebPanelModules.cPanel.API
{
    public partial class cPanelAPI : WebPanelApiBase
    {
        public cPanelAPI(BatchDomainTools.WebPanelAccount.Account _account) : base(_account) 
        {
            base.PanelType = WebPanelType.cPanel;
        }

        protected override Uri BuildCommandQuery(string module, string function, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg)
        {
            return BuildCommandQuery(module, function, APIVersion.v2, cArg);
        }

        private Uri BuildCommandQuery(string module, string function, APIVersion _apiVersion, params BatchDomainTools.WebPanelCommons.CommandArgs[] cArg) 
        {
            UriBuilder ub = new UriBuilder(this.Account.PanelAddr);
            string args = string.Empty;
            foreach (string argNow in cArg)
                     args += "&" + argNow;
            ub.Path += "xml-api/cpanel";
            ub.Query += string.Format("cpanel_xmlapi_apiversion={0}&cpanel_xmlapi_module={1}", (int)_apiVersion, module);
            if(!string.IsNullOrEmpty(function))
                ub.Query += "&cpanel_xmlapi_func=" + function;
            if (!string.IsNullOrEmpty(args))
                ub.Query += args;
            ub.Query = ub.Query.TrimStart('?');
            return ub.Uri;
        }

        public override System.Windows.Forms.ColumnHeader[] GetViewTab(Type viewType)
        {
            if (typeof(DomainItem) == viewType)
            {
                return cPanel.Items.cPanel_Domain.ToListViewColumnHeader();
            }
            else if (typeof(SubDomainItem) == viewType) 
            {
                return cPanel.Items.cPanel_SubDomain.ToListViewColumnHeader();
            }
            return null;
        }
    }
}
