using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
using System.Xml;

namespace BatchDomainTools.WebPanelModules.ISPmanager
{
    public class ISPmanager_ActionResult : ActionResultBase
    {
        public DataNodeHandler DataNodeProccessor { get; set; }
        protected static readonly Dictionary<ActionResultCode, string> knowError = new Dictionary<ActionResultCode, string>() 
        {
           { ActionResultCode.Error_AuthError, "access deny" },
           { ActionResultCode.Error_UknowMethod, "Invalid action" }
        }; 

        protected override void ProcessXmlResult(System.Xml.XmlDocument _xmlDocument)
        {
            this.ActionCode = ActionResultCode.Error_UknowError;
            XmlNode errorNode = _xmlDocument.SelectSingleNode("/doc/error");
            if (errorNode != null)
            {
                this.ActionCode = ActionResultCode.Error_UknowError;
                this.ErrorMessage = errorNode.InnerText;
                XmlAttribute attrCode = errorNode.Attributes["code"];
                foreach (KeyValuePair<ActionResultCode, string> errorSelector in knowError)
                {
                    if (this.ErrorMessage.Contains(errorSelector.Value))
                        this.ActionCode = errorSelector.Key;
                }
                if (attrCode.Value.StartsWith("4")) 
                {
                    this.ErrorMessage = String.Format("Отсутствует параметр запроса:{0}", errorNode.Attributes["val"].Value);
                }
                else if (attrCode.Value.StartsWith("3"))
                {
                    this.ErrorMessage = String.Format("Объект({0}), к которому вы обращаетесь, не существует.", errorNode.Attributes["obj"].Value);
                    this.ActionCode = ActionResultCode.Error_ItemNotFound;
                }
                else if (attrCode.Value.StartsWith("2"))
                {
                    this.ErrorMessage = String.Format("Объект({0}), который вы пытаетесь создать, уже существует.", errorNode.Attributes["obj"].Value);
                    this.ActionCode = ActionResultCode.Error_ItemAlreadyExist;
                }
                else if (string.IsNullOrEmpty(this.ErrorMessage)) 
                {
                    this.ErrorMessage = _xmlDocument.OuterXml;
                }
            }
            else if (DataNodeProccessor != null)
            {
                this.ActionCode = DataNodeProccessor(_xmlDocument.SelectNodes("//elem"));
            }
            else
            {
                if (_xmlDocument.SelectSingleNode("/doc/ok") != null)
                    this.ActionCode = ActionResultCode.Success;
                else
                    this.ActionCode = ActionResultCode.Error_UknowError;
            }
            if(this.ActionCode == ActionResultCode.Error_InvalidServerAnswer || this.ActionCode == ActionResultCode.Error_UknowError)
                this.ErrorMessage = _xmlDocument.OuterXml;
        }

        public override ActionResultType ReturnType
        {
            get { return ActionResultType.Xml; }
        }
    }
}
