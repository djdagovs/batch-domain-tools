using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.IWebPanelObjectActions.IDomainActions;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebNet;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebPanelMisc;
using BatchDomainTools.WebPanelModules.DirectAdmin.Items;

namespace BatchDomainTools.WebPanelModules.DirectAdmin.API
{
    public partial class DirectAdminAPI : IDomainGet, IDomainAdd, IDomainRemove, IDomainEdit
    {
        #region << Члены IGetDomain >>

        ActionResultBase IDomainGet.Get(WebPanelItemCollection saveCollection)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            result.DataTextProccessor = new DirectAdmin_ActionResult.DataTextHandler((InputText) =>
            {
                foreach (KeyValuePair<string,string> domainNow  in StrHelpClass.ToKeyValueURLString(InputText, true))
                {
                    saveCollection.Add(new DirectAdmin_Domain(domainNow.Key, StrHelpClass.ToNameValueURLString(domainNow.Value)));
                }
                return ActionResultCode.Success;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_ADDITIONAL_DOMAINS", ""), this.Account.WebSession));
            return result;
        }

        ActionResultBase IDomainGet.Exist(DomainItem Domain2Check)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            result.DataTextProccessor = new DirectAdmin_ActionResult.DataTextHandler((InputText) =>
            {
                foreach (KeyValuePair<string, string> domainNow in StrHelpClass.ToKeyValueURLString(InputText, true))
                {
                   if(domainNow.Key.Equals(Domain2Check.Name))
                      return ActionResultCode.Success;
                }
                return ActionResultCode.Error_ItemNotFound;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_ADDITIONAL_DOMAINS", ""), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IAddDomain >>

        ActionResultBase IDomainAdd.Add(DomainItem Domain2Add, BatchDomainTools.WebPanelOptionData.IOptionData properties)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            List<CommandArgs> commands = new List<CommandArgs>(properties.ToCommandArgs())
            {
                new CommandArgs("domain", Domain2Add.Name),
         
                new CommandArgs("ubandwidth", "unlimited"),
                new CommandArgs("uquota", "unlimited")
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_DOMAIN", "create", commands.ToArray()), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IRemoveDomain >>

        ActionResultBase IDomainRemove.RemoveOject(DomainItem DomainToRemove)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            CommandArgs[] commands = new CommandArgs[]
            {
                new CommandArgs("confirmed","anything"),
                new CommandArgs("delete","anything"),
                new CommandArgs("select0", DomainToRemove.Name),
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_DOMAIN", "", commands.ToArray()), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IEditDomain >>

        ActionResultBase IDomainEdit.Edit(DomainItem Domain2Edit, BatchDomainTools.WebPanelOptionData.IOptionData properties)
        {
            DirectAdmin_ActionResult result = new DirectAdmin_ActionResult();
            List<CommandArgs> commands = new List<CommandArgs>(properties.ToCommandArgs())
            {
                new CommandArgs("domain", Domain2Edit.Name),
                new CommandArgs("ubandwidth", "unlimited"),
                new CommandArgs("uquota", "unlimited"),
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("CMD_API_DOMAIN", "modify", commands.ToArray()), this.Account.WebSession));
            return result;
        }

        #endregion
    }
}
