using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CharValidateAttribute : Attribute
    {
        private readonly char[] BadChars = null;
        public string ErrorMessage { get; private set; }
        private readonly bool AllowEmptyValue;

        public CharValidateAttribute(string _badChars, string _errorMessage, bool _allowEmptyValue) 
        {
            this.BadChars = _badChars.ToCharArray();
            this.ErrorMessage = _errorMessage;
            this.AllowEmptyValue = _allowEmptyValue;
        }

        public bool IsHasBadChars(object inputObject) 
        {
            string data = inputObject as string;
            if (!string.IsNullOrEmpty(data)) 
            {
                foreach (char c in this.BadChars) 
                {
                    if (data.Contains(c))
                        return false;
                }
                return true;
            }
            return AllowEmptyValue;
        }
    }
}
