using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons
{
    public struct CommandArgs
    {
        public string name;
        public string value;
        public CommandArgs(string _name, string _value) 
        {
            this.name = _name;
            this.value = _value;
        }
        public static implicit operator string(CommandArgs instance)
        {
            return instance.name + "=" + instance.value;
        }
    }
}
