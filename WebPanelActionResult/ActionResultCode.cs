using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelActionResult
{
    public enum ActionResultCode
    {
        Success,
        Error_ItemNotFound,
        Error_WebConnection,
        Error_EmptyServerAnswer,
        Error_InvalidServerAnswer,
        Error_ItemAlreadyExist,
        Error_UknowMethod,
        Error_UknowError,
        Error_WrongPanelPath,
        Error_InternalProgramError,
        Error_AuthError,
        Error_ServerTimeout
    }
}
