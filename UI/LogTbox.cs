using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BatchDomainTools.WebPanelCommons;
using BatchDomainTools.WebPanelMisc;

namespace BatchDomainTools.UI
{
    public class LogTbox : RichTextBox
    {
        public LogTbox() 
        {
            this.BackColor = System.Drawing.Color.Black;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReadOnly = true;
            this.ScrollBars = RichTextBoxScrollBars.Both;
            this.ForeColor = System.Drawing.Color.White;
        }

        public void WriteToLog(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            for (int pos = 0; pos < message.Length; pos++)
            {
                if (message[pos].Equals('[') && message.Substring(pos + 1, 7).Equals("MCOLOR:"))
                {
                    int closeTagPos = message.IndexOf("[/MCOLOR]", pos);
                    if (closeTagPos == -1)
                        closeTagPos = message.IndexOf("[MCOLOR:", pos + 8);
                    else
                        closeTagPos += 9;
                    if (closeTagPos == -1)
                        closeTagPos = message.Length - 1;
                    string ColorMessage = message.Substring(pos, closeTagPos - pos);
                    WriteToLog(StrHelpClass.GetSubstring(ColorMessage, "]", "["), StrHelpClass.GetSubstring(ColorMessage, ":", "]"));
                    pos += ColorMessage.Length - 1;
                }
                else
                    this.AppendText(message[pos].ToString());
            }
            if(!this.Text.EndsWith("\r\n"))
               this.AppendText("\r\n");
        }

        private void WriteToLog(string message, string colorName)
        {
            if (string.IsNullOrEmpty(message))
                return;
            int start = this.TextLength;
            this.AppendText(message);
            int end = this.TextLength;
            this.Select(start, message.Length);
            this.SelectionColor = string.IsNullOrEmpty(colorName) ? this.ForeColor : System.Drawing.Color.FromName(colorName);
            this.SelectionLength = 0;
            // could set box.SelectionBackColor, box.SelectionFont too.
        }
    }
}
