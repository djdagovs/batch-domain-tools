using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchDomainTools.WebPanelCommons;
using System.ComponentModel;

namespace BatchDomainTools.WebPanelOptionData
{
    public class DirectAdmin_DomainOption : IOptionData
    {
        #region << Поля и свойства >>
        [Category("Параметры доменов")]
        [DisplayName("PHP Доступ")]
        [TypeConverter(typeof(BatchDomainTools.WebPanelMisc.BooleanTypeConverter))]
        [Description("Включить или выключить для доменов модуль PHP.\r\n")]
        public bool OnPHP
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("Безопасный SSL")]
        [TypeConverter(typeof(BatchDomainTools.WebPanelMisc.BooleanTypeConverter))]
        [Description("Включить или выключить для доменов доступ по ssl(https).\r\n")]
        public bool OnSSL
        {
            get;
            set;
        }
        [Category("Параметры доменов")]
        [DisplayName("CGI Доступ")]
        [TypeConverter(typeof(BatchDomainTools.WebPanelMisc.BooleanTypeConverter))]
        [Description("Включить или выключить для доменов доступ по cgi скриптов.\r\n")]
        public bool OnCGI
        {
            get;
            set;
        }
        public DirectAdmin_DomainOption() 
        {
            this.OnPHP = this.OnPHP = true;
            this.OnCGI = false;
        }
        #endregion

        public BatchDomainTools.WebPanelCommons.CommandArgs[] ToCommandArgs(params string[] addArg)
        {
            List<BatchDomainTools.WebPanelCommons.CommandArgs> CommandArgs = new List<CommandArgs>();
            if(this.OnSSL)
                CommandArgs.Add(new BatchDomainTools.WebPanelCommons.CommandArgs("ssl","ON"));
            if (this.OnCGI)
                CommandArgs.Add(new BatchDomainTools.WebPanelCommons.CommandArgs("cgi", "ON"));
            if (this.OnPHP)
                CommandArgs.Add(new BatchDomainTools.WebPanelCommons.CommandArgs("php", "ON"));
            return CommandArgs.ToArray();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
