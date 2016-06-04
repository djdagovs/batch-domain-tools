using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BatchDomainTools.WebPanelModules;

namespace BatchDomainTools
{
    public partial class AccountViewForm : Form
    {
        public event EventHandler<EventArgs> AccountEditComplited;
        private readonly Dictionary<WebPanelType, Bitmap> ImageTypeResolver = new Dictionary<WebPanelType, Bitmap>()
        {
            { WebPanelType.cPanel, global::BatchDomainTools.Properties.Resources.cPanelPanel },
            { WebPanelType.ISPmanager, global::BatchDomainTools.Properties.Resources.ISPmanagerPanel },
            { WebPanelType.DirectAdmin, global::BatchDomainTools.Properties.Resources.DirectAdminPanel },
        };
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }
        public AccountViewForm(WebPanelAccount.Account account)
        {
            InitializeComponent();
            Array aa = System.Enum.GetValues(typeof(WebPanelType));
            this.PanelTypeCBox.DataSource = aa;
            this.PanelTypeCBox.ValueMember = "";
            if (account != null)
            {
                this.PanelTypeCBox.Enabled = false;
                this.PanelTypeCBox.SelectedIndex = (int)account.PanelType;
                this.PanelAddressTBox.Text = account.PanelAddr.ToString();
                this.PanelLoginTBox.Text = account.PanelAccountLogin;
                this.PanelPassTBox.Text = account.PanelAccountPass;
            }
        }
        private void PanelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.BackgroundImage = ImageTypeResolver[(WebPanelType) PanelTypeCBox.SelectedValue];
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.AccountEditComplited = null;
            this.Close();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.PanelAddressTBox.Text = this.PanelAddressTBox.Text.Trim();
            this.PanelLoginTBox.Text = this.PanelLoginTBox.Text.Trim();
            this.PanelPassTBox.Text = this.PanelPassTBox.Text.Trim();
            try
            {
                System.Net.WebRequest.Create(new Uri(this.PanelAddressTBox.Text));
            }
            catch
            {
                ErrorSplash(this.PanelAddressTBox, "Адрес панели имеет не правильный формат!");
                return;
            }
            if (string.IsNullOrEmpty(this.PanelLoginTBox.Text))
                ErrorSplash(this.PanelLoginTBox,"Логин не может быть пустым!");
            else if (string.IsNullOrEmpty(this.PanelPassTBox.Text))
                ErrorSplash(this.PanelPassTBox,"Пароль не может быть пустым!");
            else
            {
                if (this.AccountEditComplited != null)
                {
                    WebPanelAccount.Account account = new BatchDomainTools.WebPanelAccount.Account((WebPanelType)PanelTypeCBox.SelectedValue);
                    account.PanelAddr = new Uri(this.PanelAddressTBox.Text);
                    account.PanelAccountLogin = this.PanelLoginTBox.Text;
                    account.PanelAccountPass = this.PanelPassTBox.Text;
                    AccountEditComplited(account, null);
                }
                this.AccountEditComplited = null;
                this.Close();
            }
        }
        private void ErrorSplash(TextBox text, string message) 
        {
            text.Focus();
            ErrorToolTip.Hide(text);
            ErrorToolTip.Show("", text);
            ErrorToolTip.Show(message, text);
        }
        private void PanelTBox_TextChanged(object sender, EventArgs e)
        {
            ErrorToolTip.Hide(this);
        }
 
    }
}
