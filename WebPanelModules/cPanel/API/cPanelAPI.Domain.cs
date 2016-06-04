using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.IWebPanelObjectActions.IDomainActions;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelOptionData;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebNet;
using BatchDomainTools.WebPanelModules.cPanel.Items;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.cPanel.API
{
    public partial class cPanelAPI : IDomainAdd, IDomainRemove, IDomainEdit, IDomainGet
    {
        #region << Члены IAddDomain >>

        ActionResultBase IDomainAdd.Add(DomainItem Domain, IOptionData properties)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    string status = nodeList[0]["reason"].InnerText;
                    if (status.Contains("already exists") || status.Contains("Deleted domain: "))
                    {
                        return ActionResultCode.Error_ItemAlreadyExist;
                    }
                    //you are not allowed to add any more than
                    if (!status.Contains("was successfully parked"))
                    {
                        return ActionResultCode.Error_UknowError;
                    }
                }
                return ActionResultCode.Success;
            });

            CommandArgs[] commands = new CommandArgs[]
             {
                properties.ToCommandArgs(Domain.Name)[0],
                new CommandArgs("newdomain", Domain.Name),
                new CommandArgs("subdomain", Domain.Name.Replace(".",""))
             };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("AddonDomain", "addaddondomain", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IRemoveDomain >>

        ActionResultBase IDomainRemove.RemoveOject(DomainItem DomainToRemove)
        {
            cPanel_Domain cpDomain = DomainToRemove as cPanel_Domain;
            if (cpDomain == null)
            {
                throw new ArgumentException("Wrong type of argument, the expected cPanel_Domain type.", "Domain");
            }
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    string status = nodeList[0]["reason"].InnerText;
                    if (status.Contains("Deleted domain:") || status.Contains("Bind reloading"))
                    {
                       return ActionResultCode.Success;
                    }
                }
                return ActionResultCode.Error_UknowError;
            });
            CommandArgs[] commands = new CommandArgs[]
            {
                new CommandArgs("domain", cpDomain.Name),
                new CommandArgs("subdomain",  cpDomain.ExtViewData["domainkey"]),
                new CommandArgs("user", cpDomain.ExtViewData["subdomain"])
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("AddonDomain", "deladdondomain", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IEditDomain >>

        ActionResultBase IDomainEdit.Edit(DomainItem DomainToEdit, IOptionData properties)
        {
            cPanel_Domain cpDomain = DomainToEdit as cPanel_Domain;
            if (cpDomain == null)
            {
                throw new ArgumentException("Wrong type of argument, the expected cPanel_Domain type.", "Domain");
            }
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    return ActionResultCode.Success;
                }
                return ActionResultCode.Error_UknowError;
            });
            CommandArgs[] commands = new CommandArgs[]
            {
                new CommandArgs("rootdomain", cpDomain.ExtViewData["rootdomain"]),
                new CommandArgs("subdomain",  cpDomain.ExtViewData["subdomain"]),
                properties.ToCommandArgs(cpDomain.Name)[0]
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "changedocroot", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IGetDomain >>

        ActionResultBase IDomainGet.Get(WebPanelItemCollection saveCollection)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        saveCollection.Add(new cPanel_Domain(node));
                    }
                }
                return ActionResultCode.Success;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("AddonDomain", "listaddondomains"), this.Account.WebSession));
            return result;
        }

        ActionResultBase IDomainGet.Exist(DomainItem Domain2Check)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    foreach (XmlNode dNode in nodeList)
                    {
                        string domain = dNode["domain"].InnerText;
                        if (domain.Equals(Domain2Check.Name, StringComparison.InvariantCultureIgnoreCase))
                            return ActionResultCode.Success;
                    }
                }
                return ActionResultCode.Error_EmptyServerAnswer;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("DomainLookup", "getbasedomains"), this.Account.WebSession));
            return result;
        }

        #endregion
    }
}
