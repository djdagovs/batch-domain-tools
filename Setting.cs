using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BatchDomainTools
{
    [Serializable()]
    public sealed class Setting
    {
        #region << Поля и свойства >>
        public static Setting SettingInstance 
        {
            get
            {
                return instance;
            }
        }
        private static Setting instance = new Setting();
        /// <summary>
        /// Основные настройки веб-панелей
        /// </summary>
        [EditorBrowsableAttribute( EditorBrowsableState.Never)]
        public static Dictionary<WebPanelModules.WebPanelType, WebPanelOptionData.IOptionData> WebPanelAPIoptions
        {
               get 
               {
                   return instance.m_WebPanelAPIoptions;
               }
               set 
               {
                   instance.m_WebPanelAPIoptions = value;
               }
        }
        Dictionary<WebPanelModules.WebPanelType, WebPanelOptionData.IOptionData> m_WebPanelAPIoptions = new Dictionary<BatchDomainTools.WebPanelModules.WebPanelType, BatchDomainTools.WebPanelOptionData.IOptionData>() 
        {
           { WebPanelModules.WebPanelType.cPanel, new WebPanelOptionData.cPanel_DomainOption() },
           { WebPanelModules.WebPanelType.DirectAdmin, new WebPanelOptionData.DirectAdmin_DomainOption() },
           { WebPanelModules.WebPanelType.ISPmanager, new WebPanelOptionData.ISPmanager_DomainOption() }
        };
        /// <summary>
        /// Таймаут ожидания от сервера
        /// </summary>
        [DisplayName("Таймаут ожидания")]
        [Description("Таймаут ожидания при операциях чтения и записи")]
        public int HttpReadWriteTimeout
        {
            get;
            set;
        }
        /// <summary>
        /// Пауза между запроса
        /// </summary>
        [DisplayName("Пауза")]
        [Description("Пауза между запроса")]
        public int QueryPause
        {
            get;
            set;
        }
        /// <summary>
        /// Прокси сервер для выполнения запросов с веб-панелью
        /// </summary>
        [DisplayName("Прокси-сервер")]
        [Description("Прокси-сервер для выполнения запросов с веб-панелью")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public System.Net.WebProxy Proxy
        {
            get;
            set;
        }
        /// <summary>
        /// Возвращает полный путь к файлу с настройками
        /// </summary>
        public static string ConfigFileName 
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"\Config.bin";
            }
        }
        /// <summary>
        /// Возвращает полный путь к файлу с аккаунтами
        /// </summary>
        public static string AccountFileName 
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"\Accounts.db";
            }
        }
        /// <summary>
        /// Возвращает полный путь к файлу с лицензией
        /// </summary>
        public static string LicenceFile
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"\license.lic";
            }
        }

        #endregion

        #region << ctor >>

        private Setting() 
        {
            this.Proxy = null;// new System.Net.WebProxy("127.0.0.1", 8888);
            this.HttpReadWriteTimeout = 60000;
            this.QueryPause = 0;
        }

        #endregion

        #region << Методы >>

        /// <summary>
        /// Сохраняем основные настройки
        /// </summary>
        internal static void SaveSetting()
        {
            try
            {
                using (FileStream fsCompressed = new FileStream(ConfigFileName, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream compress = new GZipStream(fsCompressed, CompressionMode.Compress, false))
                    {
                        using (StreamWriter sWriter = new StreamWriter(compress))
                        {
                            BinaryFormatter bformatter = new BinaryFormatter(null,
                                         new StreamingContext(StreamingContextStates.File));
                            bformatter.Serialize(sWriter.BaseStream, instance);
                        }
                    }
                }
            }
            catch (Exception se)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось сохранить файл с настройками: " + se.Message);
            }
        }

        /// <summary>
        /// Загружаем настройки
        /// </summary>
        internal static void LoadSetting()
        {
            /*
            if (!File.Exists(ConfigFileName)) return;
            try
            {
                using (FileStream fsCompressed = new FileStream(ConfigFileName, FileMode.Open, FileAccess.Read))
                {
                    using (GZipStream compress = new GZipStream(fsCompressed, CompressionMode.Decompress, false))
                    {
                        using (StreamReader reader = new StreamReader(compress))
                        {
                            BinaryFormatter bformatter = new BinaryFormatter(null,
                                         new StreamingContext(StreamingContextStates.File));
                            instance = (Setting)bformatter.Deserialize(reader.BaseStream);
                        }
                    }
                }
            }
            catch (Exception se)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось загрузить файл с настройками: " + se.Message);
            }*/
        }

        #endregion
    }
}
