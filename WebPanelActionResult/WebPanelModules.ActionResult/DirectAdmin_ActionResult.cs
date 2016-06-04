using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelActionResult;
 

namespace BatchDomainTools.WebPanelModules.DirectAdmin
{
    public class DirectAdmin_ActionResult : ActionResultBase
    {
        public DataTextHandler DataTextProccessor { get; set; }
        protected override void ProcessTextResult(string _string)
        {
            this.ActionCode = ActionResultCode.Success;
            if (this.ResponceHeaders["X-DirectAdmin"] != null && this.ResponceHeaders["X-DirectAdmin"].Trim().Equals("unauthorized"))
            {
                this.ActionCode = ActionResultCode.Error_AuthError;
            }
            else if (this.ResponceHeaders["Content-Type"].Trim() == "text/html")
            {
                if (_string.Contains(" action=\"/CMD_LOGIN\""))
                    this.ActionCode = ActionResultCode.Error_AuthError;
                else
                {
                    this.ActionCode = ActionResultCode.Error_UknowError;
                    this.ErrorMessage = _string;
                }
            }
            else if (_string.Contains("error=1"))
            {
                System.Collections.Specialized.NameValueCollection urlNameVaule = BatchDomainTools.WebPanelMisc.StrHelpClass.ToNameValueURLString(_string);
                this.ErrorMessage = string.Format("{0}:{1}", urlNameVaule["text"], urlNameVaule["details"]);
                this.ActionCode = ActionResultCode.Error_UknowError;
            }
            else if (DataTextProccessor != null) 
            {
                DataTextProccessor(_string);
            }
        }

        public override ActionResultType ReturnType
        {
            get { return ActionResultType.PlainText; }
        }

        
    }
}
