using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.IWebPanelObjectActions.IDomainActions;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelOptionData;
using System.Xml;
using BatchDomainTools.WebNet;
using BatchDomainTools.WebPanelModules.ISPmanager.Items;
using BatchDomainTools.WebPanelCommons;

namespace BatchDomainTools.WebPanelModules.ISPmanager.Api
{
    public partial class ISPmanagerAPI: IDomainAdd, IDomainGet, IDomainRemove, IDomainEdit
    {
        #region << Члены IAddDomain >>
   

        ActionResultBase IDomainAdd.Add(DomainItem Domain2Add, IOptionData properties)
        {
            ISPmanager.ISPmanager_ActionResult result = new ISPmanager_ActionResult();
            List<CommandArgs> commands = new List<CommandArgs>(properties.ToCommandArgs(Domain2Add.Name));
            commands.Add(new CommandArgs("domain", Domain2Add.Name));
            commands.Add(new CommandArgs("admin", "webmaster@" + Domain2Add.Name));
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("wwwdomain.edit",commands.ToArray()), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IGetDomain >>

        ActionResultBase IDomainGet.Get(WebPanelItemCollection saveCollection)
        {
            ISPmanager_ActionResult result = new ISPmanager_ActionResult();
            result.DataNodeProccessor = new ISPmanager_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        saveCollection.Add(new ISPmanager_Domain(node));
                    }
                }
                return ActionResultCode.Success;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("wwwdomain"), this.Account.WebSession));
            return result;
        }

        ActionResultBase IDomainGet.Exist(DomainItem Domain2Check)
        {
            ISPmanager_ActionResult result = new ISPmanager_ActionResult();
            CommandArgs[] commands = new CommandArgs[]
             {
                new CommandArgs("elid", Domain2Check.Name),
                new CommandArgs("admin", "admin@" + Domain2Check.Name)
             };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("wwwdomain", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region Члены IRemoveDomain

        ActionResultBase IDomainRemove.RemoveOject(DomainItem DomainToRemove)
        {
            ISPmanager_ActionResult result = new ISPmanager_ActionResult();
            CommandArgs[] commands = new CommandArgs[]
             {
                new CommandArgs("elid", DomainToRemove.Name),
                //new CommandArgs("admin", "admin@" + Domain2Check.Name)
             };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("wwwdomain.delete", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IEditDomain >>

        ActionResultBase IDomainEdit.Edit(DomainItem Domain2Edit, IOptionData properties)
        {
            ISPmanager_ActionResult result = new ISPmanager_ActionResult();
            List<CommandArgs> commands = new List<CommandArgs>(properties.ToCommandArgs(Domain2Edit.Name));
            commands.Add(new CommandArgs("elid", Domain2Edit.Name));
            commands.Add(new CommandArgs("admin", "admin@" + Domain2Edit.Name));
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("wwwdomain.edit", commands.ToArray()), this.Account.WebSession));
            return result;
        }

        #endregion

    }
}
