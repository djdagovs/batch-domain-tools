using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BatchDomainTools.WebPanelCommons;

namespace BatchDomainTools.WebPanelOptionData
{
    public class cPanel_DomainOption : IOptionData
    {
        [CharValidateAttribute("?%*:|\"<>", "Пути к каталогам не могут содержать следующие символы: ? % * : | \" < >", true)]
        [Category("Параметры доменов")]
        [DisplayName("Каталог документов")]
        [Description("Каталог, в котором будут храниться документы Web-сайта.\r\nВсе вхождения макроса ${DomainName} в данном поле, при добавлении доменов, будут заменены на имя добавляемого домена.\r\nЕсли не указывать макрос ${DomainName} то для всех добавляемых доменов будет указанна одна общая дириктория!\r\nЕсли оставить это поле пустым, то будет использован путь по умолчанию используемый в соответствующей панели.")]
        public  string RootDirPath
        {
            get;
            set;
        }
        
        public cPanel_DomainOption() 
        {
            this.RootDirPath = "public_html/${DomainName}";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public BatchDomainTools.WebPanelCommons.CommandArgs[] ToCommandArgs(params string[] addArg)
        {
            string value = (string.IsNullOrEmpty(this.RootDirPath) ? "public_html/${DomainName}" : this.RootDirPath);
            if (addArg != null && addArg.Length > 0)
                value = value.Replace("${DomainName}", addArg[0]);
            return new BatchDomainTools.WebPanelCommons.CommandArgs[] 
            { 
                new BatchDomainTools.WebPanelCommons.CommandArgs("dir",value)
            };
        }

        public object Clone()
        {
            return new cPanel_DomainOption() 
            {
              RootDirPath = this.RootDirPath
            };
        }
 
    }
}
