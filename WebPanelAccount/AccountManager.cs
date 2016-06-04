using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Specialized;

namespace BatchDomainTools.WebPanelAccount
{
    [Serializable]
    public sealed class AccountManager : ObservableCollection<Account>
    {
        #region << Поля и свойства >>
        /// <summary>
        /// 
        /// </summary>
        public static AccountManager ManagerInstance 
        {
            get 
            {
                return manager_instance;
            }
        }
        private static AccountManager manager_instance;
        /// <summary>
        /// Возвращает выбранный аккаунт или null если коллекция пуста
        /// </summary>
        public static Account SelectAccount 
        {
            get
            {
                if (ManagerInstance.Count == 0)
                    return null;
                return ManagerInstance[ManagerInstance.selectIndex];
            }
        }
        /// <summary>
        /// Выбранный аккаунта на данный момент
        /// </summary>
        private int selectIndex = 0;

        #endregion
        
        #region << События >>

        [field: NonSerialized]
        public event EventHandler<BatchDomainTools.WebPanelCommons.AccountSelectEventArgs> AccountChangeEvent;

        #endregion

        #region << Ctor >>

        AccountManager() { }

        static AccountManager() 
        {
          manager_instance = new AccountManager();
        /*  manager_instance.Add(new Account(BatchDomainTools.WebPanelModules.WebPanelType.ISPmanager)
          {
                 PanelAddr = new Uri("https://isp4.it-mcp.ru:1500/"),
                 PanelAccountLogin = "hostgidn",
                 PanelAccountPass = "pF7P4zbt33",
          });

          manager_instance.Add(new Account(BatchDomainTools.WebPanelModules.WebPanelType.DirectAdmin)
          {
              PanelAddr = new Uri("http://46.165.222.169:2222"),
              PanelAccountLogin = "zujul154",
              PanelAccountPass = "RVet5uz3",
          });

          manager_instance.Add(new Account(BatchDomainTools.WebPanelModules.WebPanelType.cPanel)
          {
              PanelAddr = new Uri("https://46.165.222.170:2083/"),
              PanelAccountLogin = "diven131",
              PanelAccountPass = "pnGazoV0",
          });*/
        }

        #endregion

        #region << Методы >>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldStartingIndex == this.selectIndex) 
                {
                    SelectAccountByAt(0);
                }
                else if (e.OldStartingIndex < this.selectIndex) 
                {
                    SelectAccountByAt(this.selectIndex - 1);
                }
            }
        }
        /// <summary>
        /// Метод делает аккаунт по указанному индексу активным
        /// </summary>
        public void SelectAccountByAt(int index) 
        {
            OnAccountChangeEvent(BatchDomainTools.WebPanelCommons.SelectStatus.start);
            if (index < this.Count && index >= 0)
            {
                this.selectIndex = index;
            }
            OnAccountChangeEvent(BatchDomainTools.WebPanelCommons.SelectStatus.end);
        }
        /// <summary>
        /// Метод загружает аккаунты в текушию контекст
        /// </summary>
        /// <param name="AccountFilePath"></param>
        /// <returns></returns>
        public static void LoadAccounts(string AccountsFilePath) 
        {
            if (!File.Exists(AccountsFilePath)) {

                return;
            }
           
            try
            {
                using (FileStream fsCompressed = new FileStream(AccountsFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (GZipStream compress = new GZipStream(fsCompressed, CompressionMode.Decompress, false))
                    {
                        using (StreamReader reader = new StreamReader(compress))
                        {
                            BinaryFormatter bformatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File));
                            AccountManager tempmanager = ((AccountManager)bformatter.Deserialize(reader.BaseStream));
                            if (tempmanager.Count > 0)
                            {
                                foreach (Account account in tempmanager)
                                {
                                    manager_instance.Add(account);
                                }
                            }
                            manager_instance.SelectAccountByAt(tempmanager.selectIndex);
                        }
                    }
                }
            }
            catch (Exception se)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось загрузить файл с аккаунтами: " + se.Message);
            }
        }
        /// <summary>
        /// Метод сохраняет текушию контекст с аккаунтами в указаный файл 
        /// </summary>
        /// <param name="AccountFilePath"></param>
        /// <returns></returns>
        public static void SaveAccounts(string AccountsFilePath)
        {
            try
            {
                using (FileStream fsCompressed = new FileStream(AccountsFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream compress = new GZipStream(fsCompressed, CompressionMode.Compress, false))
                    {
                        using (StreamWriter sWriter = new StreamWriter(compress))
                        {
                            BinaryFormatter bformatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File));
                            bformatter.Serialize(sWriter.BaseStream, manager_instance);
                        }
                    }
                }
            }
            catch (Exception se)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось сохранить файл с аккаунтами: " + se.Message);
            }
        }

        private void OnAccountChangeEvent(BatchDomainTools.WebPanelCommons.SelectStatus status) 
        {
            if (AccountChangeEvent != null) 
            {
                var arg = new WebPanelCommons.AccountSelectEventArgs(status);
                if(status!= BatchDomainTools.WebPanelCommons.SelectStatus.start && this.Count>0 )
                {
                   arg.SelectIndex = this.selectIndex;
                   arg.SelectAccount = this[this.selectIndex];
                }
                AccountChangeEvent(this, arg);
            }
        }

        #endregion

 
    }
}
