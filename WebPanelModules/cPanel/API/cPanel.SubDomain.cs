using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelItems;
using BatchDomainTools.WebPanelActionResult;
using BatchDomainTools.WebNet;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebPanelModules.cPanel.Items;
using System.Xml;
using BatchDomainTools.IWebPanelObjectActions.ISubDomainActions;

namespace BatchDomainTools.WebPanelModules.cPanel.API
{
    partial class cPanelAPI : ISubDomainGet, ISubDomainAdd, ISubDomainRemove, ISubDomainEdit
    {
        /// <summary>
        /// Метод получает главный домен
        /// </summary>
        /// <returns></returns>
       /* DomainItem GetMainDomain()
        {
            DomainItem MainDomain = null;
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    string mainDomain = nodeList[0]["result"].InnerText;
                    if (!string.IsNullOrEmpty(mainDomain))
                    {
                        MainDomain = new DomainItem(mainDomain);
                        return ActionResultCode.Success;
                    }
                }
                return ActionResultCode.Error_EmptyServerAnswer;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("print", "", APIVersion.v1, new CommandArgs("arg-0", "$CPDATA{'DNS'}")), this.Account.WebSession));
            return MainDomain;
        }*/

        /// <summary>
        /// Метод получает главный домен альтернативным способ
        /// </summary>
        /// <returns></returns>
        DomainItem GetMainDomain()
        {
            DomainItem MainDomain = null;
            WebPanelItemCollection domainCollection = new WebPanelItemCollection(typeof(WebPanelItems.DomainItem));
            if (((IWebPanelObjectActions.IDomainActions.IDomainGet)this).Get(domainCollection) && domainCollection.Count>0) 
            {
                if (domainCollection[0] != null && domainCollection[0].ExtViewData != null && domainCollection[0].ExtViewData["rootdomain"]!=null) 
                {
                    MainDomain = new DomainItem(domainCollection[0].ExtViewData["rootdomain"]);
                }
            }
            return MainDomain;
        }

        #region << Члены IGetSubDomain >>

        ActionResultBase BatchDomainTools.IWebPanelObjectActions.ISubDomainActions.ISubDomainGet.Get(WebPanelItemCollection saveCollection)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            DomainItem mainDomain = GetMainDomain();
            //if(mainDomain==null)
              //  mainDomain = GetMainDomainAlternative();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        cPanel_SubDomain subDomain = new cPanel_SubDomain(node);
                        if (mainDomain != null && !subDomain.RootDomain.Equals(mainDomain.Name, StringComparison.InvariantCultureIgnoreCase) ||
                            mainDomain == null)
                            saveCollection.Add(subDomain);
                    }
                    return ActionResultCode.Success;
                }
                return ActionResultCode.Error_InvalidServerAnswer;
            });
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "listsubdomains"), this.Account.WebSession));
            return result;
        }

        public ActionResultBase Exist(SubDomainItem SubDomain2Check)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            DomainItem mainDomain = GetMainDomain();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    return ActionResultCode.Success;
                }
                return ActionResultCode.Error_EmptyServerAnswer;
            });
            CommandArgs[] commands = new CommandArgs[]
            {
               new CommandArgs("regex", SubDomain2Check.Name)
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "listsubdomains", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IAddSubDomain >>

        ActionResultBase ISubDomainAdd.Add(SubDomainItem SubDomain2Add, BatchDomainTools.WebPanelOptionData.IOptionData properties)
        {
            cPanel_ActionResult result = new cPanel_ActionResult();
            result.DataNodeProccessor = new cPanel_ActionResult.DataNodeHandler((nodeList) =>
            {
                if (nodeList != null)
                {
                    string status = nodeList[0]["result"].InnerText;
                    if (status.Contains("already exists") || status.Contains("Deleted domain: "))
                    {
                        return ActionResultCode.Error_ItemAlreadyExist;
                    }
                    if (status != "1")
                    {
                        return ActionResultCode.Error_UknowError;
                    }
                }
                return ActionResultCode.Success;
            });

            CommandArgs[] commands = new CommandArgs[]
             {
                properties.ToCommandArgs(SubDomain2Add.SubDomainName)[0],
                new CommandArgs("domain", SubDomain2Add.SubDomainName),
                new CommandArgs("rootdomain",SubDomain2Add.RootDomain)
             };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "addsubdomain", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IRemoveSubDomain >>

        ActionResultBase ISubDomainRemove.RemoveOject(SubDomainItem SubDomain2Remove)
        {
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
                new CommandArgs("domain",  SubDomain2Remove.Name)
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "delsubdomain", commands), this.Account.WebSession));
            return result;
        }

        #endregion

        #region << Члены IEditSubDomain >>

        ActionResultBase ISubDomainEdit.Edit(SubDomainItem SubDomain2Edit, BatchDomainTools.WebPanelOptionData.IOptionData properties)
        {
            cPanel_SubDomain cpDomain = SubDomain2Edit as cPanel_SubDomain;
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
                new CommandArgs("rootdomain", cpDomain.RootDomain),
                new CommandArgs("subdomain",  cpDomain.SubDomainName),
                properties.ToCommandArgs(cpDomain.Name)[0]
            };
            result.ExecuteQuery(WebNetCommunication.BuildGetRequest(BuildCommandQuery("SubDomain", "changedocroot", commands), this.Account.WebSession));
            return result;
        }

        #endregion

    }
}
