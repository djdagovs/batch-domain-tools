using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BatchDomainTools
{
    static class Program
    {
        static System.Threading.EventWaitHandle InstantRunEvent;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool InstantExist;
            InstantRunEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset, "BatchDomainTools#MutexXKFNDHBEUF93JFBSWSX", out InstantExist);
            if (!InstantExist)
            {
                try
                {
                    IntPtr hWnd = BatchDomainTools.WebPanelCommons.NativeMethods.FindWindow(null, "Batch Domain Tools");
                    if (0L != hWnd.ToInt64())
                    {
                        BatchDomainTools.WebPanelCommons.NativeMethods.SendMessage(hWnd, 0x0112, (IntPtr)0xF120, IntPtr.Zero);
                        BatchDomainTools.WebPanelCommons.NativeMethods.SetForegroundWindow(hWnd);
                    }
                }
                catch (Exception e) 
                {
                    System.Diagnostics.Debug.Write(e, "Exception");
                }
                Application.Exit();
                return;
            }
            Setting.LoadSetting();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*if (System.IO.File.Exists(Setting.ConfigFileName))
                Setting.LoadSetting(); */
            Application.Run(new MainForm());
        } 
    }
}
