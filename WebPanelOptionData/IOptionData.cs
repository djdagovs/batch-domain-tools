using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelOptionData
{
    public interface IOptionData : ICloneable
    {
        /// <summary>
        /// Преобразовывает элементы в строку, которую можно использовать в качестве url query  
        /// </summary>
        /// <returns></returns>
        BatchDomainTools.WebPanelCommons.CommandArgs[] ToCommandArgs(params string[] addArg);
    }
}
