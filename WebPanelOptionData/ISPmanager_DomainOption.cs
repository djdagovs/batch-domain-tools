using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BatchDomainTools.WebPanelCommons.EnumViewHelp;
using BatchDomainTools.WebPanelCommons;

namespace BatchDomainTools.WebPanelOptionData
{
    public class ISPmanager_DomainOption : BatchDomainTools.WebPanelOptionData.IOptionData
    {
        #region << Поля и свойства >>

        [Category("Параметры доменов")]
        [DisplayName("Параметры PHP")]
        [Description("Эта опция определяет режим использования PHP для домена.")]
        public PHPStatus PHP
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("IP адреса")]
        [Description("Вы можете указать здесь список IP адресов, на которых будут располагаться WWW домены.\r\nЕсли указать более одного IP-адреса, то для каждого домена будет выбираться случайный IP адрес из этого списка.\r\nЕсли оставить это поле пустым то будет ипользован первый IP адрес из списка доступных.\r\nВАЖНО:ВСЕ IP АДРЕСА, УКАЗАНЫЕ ЗДЕСЬ ДОЛЖНЫ УЖЕ БЫТЬ ЗАКРЕПЛЕНЫ В ПАНЕЛИ УПРАВЛЕНИЯ ISPmanager")]
        public string[] IPAddrs 
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Псевдонимы")]
        [Description("Вы можете указать здесь список псевдонимов для сайтов.\r\nВсе вхождения макроса ${DomainName} в данном поле, будут заменены на имя домена.\r\n")]
        public string[] Alias
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Индексная(-ы) страница(-ы)")]
        [Description("Вы можете указать здесь индексные страницы для дирикторий.")]
        public string[] IndexPages
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Корневая папка")]
        [Description("Папка, в которой будут находиться документы сайтов.\r\nВсе вхождения макроса ${DomainName} в данном поле, будут заменены на имя добавляемого домена.\r\nЕсли не указывать макрос ${DomainName}, то для всех добавляемых доменов будет указанна одна общая дириктория!\r\nЕсли оставить это поле пустым или указать \"auto\" будут использованы параметры по умолчания для ISPmanager.")]
        public string DocRoot 
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Авто поддомены")]
        [Description("Вы можете указать здесь параметры авто поддоменов, подробней про авто поддомен вы можете прочитать в документации к ISPmanager.\r\nПри активации это опции также необходимо добавить в \"Псевдонимы\" значения *.${DomainName}")]
        public AutoSubDomain SubDomain
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Владелец")]
        [Description("Владелец добавляемых доменов.\r\nЭто поле стоит указывать только если Вы обладаете админ права в ISPmanager, иначе оно будет проигнорировано.")]
        public string Owner
        {
            get;
            set;
        }

        [Category("Параметры доменов")]
        [DisplayName("Кодировка")]
        [Description("Кодировка по умолчанию для страниц WWW домена")]
        public string Charset
        {
            get;
            set;
        }

        #endregion

        #region << ctor >>
        public ISPmanager_DomainOption() 
        {
            this.Alias = new string[] { "www.${DomainName}" };
            this.DocRoot = "auto";
        }
        #endregion

        #region << Члены IOptionData >>
        BatchDomainTools.WebPanelCommons.CommandArgs[] BatchDomainTools.WebPanelOptionData.IOptionData.ToCommandArgs(params string[] addArg)
        {
            List<CommandArgs> cArg = new List<CommandArgs>();
            cArg.Add(new CommandArgs("autosubdomain", this.SubDomain.ToString()));
            cArg.Add(new CommandArgs("php", this.PHP.ToString()));
            cArg.Add(new CommandArgs("charset", string.IsNullOrEmpty(this.Charset) ? "" : this.Charset));
            cArg.Add(new CommandArgs("docroot", string.IsNullOrEmpty(this.DocRoot.Trim()) ? "auto" : this.DocRoot));
            if (!string.IsNullOrEmpty(this.Owner)) 
            {
                cArg.Add(new CommandArgs("owner", this.Owner));
            }
            if (this.Alias != null && this.Alias.Length > 0) 
            {
                cArg.Add(new CommandArgs("alias", string.Join("%20", this.Alias.Select(x => x.Replace("${DomainName}", addArg[0])).ToArray())));
                cArg.Add(new CommandArgs("alias_list", string.Join("%0D%0A", this.Alias.Select(x => x.Replace("${DomainName}", addArg[0])).ToArray())));
            }
            if (this.IndexPages != null && this.IndexPages.Length > 0)
            {
                cArg.Add(new CommandArgs("index", string.Join("%20", this.IndexPages)));
            }
            if (this.IPAddrs != null && this.IPAddrs.Length > 0)
            {
                cArg.Add(new CommandArgs("ip", xRandom.GetRandomString(this.IPAddrs)));
            }
            return cArg.ToArray(); 
        }
        #endregion

        #region << Члены ICloneable >>
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        [TypeConverter(typeof(EnumTypeConverter))]
        public enum PHPStatus 
        {
            [Description("Нет поддержки PHP")]
            phpnone,
            [Description("PHP как модуль Apache")]
            phpmod,
            [Description("PHP как CGI")]
            phpcgi,
            [Description("PHP как FastCGI")] 
            phpfcgi 
        }

        [TypeConverter(typeof(EnumTypeConverter))]
        public enum AutoSubDomain 
        {
            [Description("Отключены")]
            asdnone,
            [Description("В отдельной директории")]
            asddir, 
            [Description("В поддиректории WWW домена")]
            asdsubdir 
        }
    }
}
