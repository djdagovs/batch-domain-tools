using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.IWebPanelObjectActions.ISubDomainActions;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelOptionData;
using BatchDomainTools.WebNet;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebPanelMisc;

namespace BatchDomainTools.WebPanelModules.DirectAdmin.API
{
    public partial class DirectAdminAPI : ISubDomainAdd, ISubDomainGet, ISubDomainRemove
    {
        #region << Члены IAddSubDomain >>

        ActionResultBase ISubDomainAdd.Add(SubDomainItem SubDomain2Add, IOptionData properties)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            CommandArgs[] commands = new CommandArgs[]
            {
                new CommandArgs("domain", SubDomain2Add.RootDomain),
                new CommandArgs("subdomain", SubDomain2Add.SubDomainName),
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_SUBDOMAINS", "create", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IGetSubDomain >>

        /// <summary>
        /// Метод получает все поддомены для указанного поддомена
        /// </summary>
        ActionResultBase GetAllAdditionalDomains(DomainItem domain, WebPanelItemCollection SubDomainList)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            result.DataTextProccessor = new DirectAdmin_ActionResult.DataTextHandler((InputText) =>
            {
                foreach (KeyValuePair<string, string> domainNow in StrHelpClass.ToKeyValueURLString(InputText, true))
                {
                   SubDomainList.Add(new SubDomainItem(domain.Name, domainNow.Value));
                }
                return ActionResultCode.Success;
            });
            CommandArgs arg = new CommandArgs("domain", domain.Name);
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_SUBDOMAINS", "", arg), this.Account.WebSession));
            return result;
        }

        ActionResultBase ISubDomainGet.Get(WebPanelItemCollection saveCollection)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            WebPanelItemCollection AdditionDomains = new WebPanelItemCollection(typeof(DomainItem));
            result = (DirectAdmin_ActionResult)((IWebPanelObjectActions.IDomainActions.IDomainGet)this).Get(AdditionDomains);
            if (result)
            {
                foreach (DomainItem domain in AdditionDomains)
                {
                    if (!string.IsNullOrEmpty(domain.ExtViewData["subdomain"]) &&
                        domain.ExtViewData["subdomain"] != "0")
                    {
                        GetAllAdditionalDomains(domain, saveCollection);
                    }
                } 
            }
            return result;
        }

        ActionResultBase ISubDomainGet.Exist(SubDomainItem SubDomain2Check)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            result.DataTextProccessor = new DirectAdmin_ActionResult.DataTextHandler((InputText) =>
            {
                foreach (KeyValuePair<string, string> domainNow in StrHelpClass.ToKeyValueURLString(InputText, true))
                {
                    if (SubDomain2Check.SubDomainName.Equals(domainNow.Value))
                        return ActionResultCode.Success;
                }
                return ActionResultCode.Error_ItemNotFound;
            });
            CommandArgs arg = new CommandArgs("domain", SubDomain2Check.RootDomain);
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_SUBDOMAINS", "", arg), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IRemoveSubDomain >>

        ActionResultBase ISubDomainRemove.RemoveOject(SubDomainItem SubDomain2Remove)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            CommandArgs[] commands = new CommandArgs[]
            {
                new CommandArgs("domain", SubDomain2Remove.RootDomain),
                new CommandArgs("select0", SubDomain2Remove.SubDomainName),
                new CommandArgs("contents", "yes")
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_SUBDOMAINS", "delete", commands), this.Account.WebSession));
            return result;
        }

        #endregion
 
    }
}
