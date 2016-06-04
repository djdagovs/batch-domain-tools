using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.cPanel
{
    public class cPanel_ActionResult : ActionResultBase
    {
        public delegate ActionResultCode DataNodeHandler(XmlNodeList dataNode);
        public DataNodeHandler DataNodeProccessor { get; set; }

        protected static readonly Dictionary<ActionResultCode,string> knowError = new Dictionary<ActionResultCode ,string>() 
        {
           { ActionResultCode.Error_AuthError, "Access denied" },
           { ActionResultCode.Error_UknowMethod, "Could not find function" },
           { ActionResultCode.Error_ItemAlreadyExist, "already exists" }
        }; 

        protected override void ProcessXmlResult(System.Xml.XmlDocument _xmlDocument)
        {
            this.ActionCode = ActionResultCode.Error_UknowError;
            XmlNode tempNode = _xmlDocument.SelectSingleNode("/cpanelresult/error");
            if (tempNode != null)
            {
                this.ActionCode = ActionResultCode.Error_UknowError;
                this.ErrorMessage = tempNode.InnerText;
                foreach (KeyValuePair<ActionResultCode, string> errorSelector in knowError)
                {
                    if (this.ErrorMessage.Contains(errorSelector.Value))
                        this.ActionCode = errorSelector.Key;
                }
            }
            else
            {
                if ((tempNode = _xmlDocument.SelectSingleNode("/cpanelresult/data/result")) != null)
                {
                    if (tempNode.InnerText == "0")
                    {
                        this.ErrorMessage = _xmlDocument.OuterXml;
                        return;
                    }
                    else if (tempNode.InnerText.Contains("Ignore any messages of success this can only result in failure!"))
                    {
                        this.ErrorMessage = tempNode.InnerText.Replace("Ignore any messages of success this can only result in failure!", string.Empty);
                        return;
                    }
                }
                if (DataNodeProccessor != null)
                {
                    if ((this.ActionCode = DataNodeProccessor(_xmlDocument.SelectNodes("//data"))) == ActionResultCode.Error_InvalidServerAnswer ||
                         this.ActionCode == ActionResultCode.Error_UknowError)
                    {
                        this.ErrorMessage = _xmlDocument.OuterXml;
                    }
                }
                else
                    this.ActionCode = ActionResultCode.Success;
            }
        }

        public override ActionResultType ReturnType 
        {
            get { return ActionResultType.Xml; }
        }

    }
}
