namespace BatchDomainTools
{
    partial class AccountViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SaveButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.PanelTypeCBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PanelAddressTBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PanelLoginTBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PanelPassTBox = new System.Windows.Forms.TextBox();
            this.ErrorBlurPBox = new System.Windows.Forms.PictureBox();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBlurPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 305);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(215, 305);
            this._CancelButton.Name = "CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 5;
            this._CancelButton.Text = "Отмена";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PanelTypeCBox
            // 
            this.PanelTypeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PanelTypeCBox.FormattingEnabled = true;
            this.PanelTypeCBox.Location = new System.Drawing.Point(9, 18);
            this.PanelTypeCBox.Name = "PanelTypeCBox";
            this.PanelTypeCBox.Size = new System.Drawing.Size(262, 24);
            this.PanelTypeCBox.TabIndex = 5;
            this.PanelTypeCBox.SelectedIndexChanged += new System.EventHandler(this.PanelTypeBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.PanelTypeCBox);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип панели";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.PanelAddressTBox);
            this.groupBox2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 1, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(278, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Адрес панели";
            // 
            // PanelAddressTBox
            // 
            this.PanelAddressTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAddressTBox.Location = new System.Drawing.Point(8, 18);
            this.PanelAddressTBox.Name = "PanelAddressTBox";
            this.PanelAddressTBox.Size = new System.Drawing.Size(262, 24);
            this.PanelAddressTBox.TabIndex = 0;
            this.PanelAddressTBox.TextChanged += new System.EventHandler(this.PanelTBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.PanelLoginTBox);
            this.groupBox3.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 1, 8, 8);
            this.groupBox3.Size = new System.Drawing.Size(278, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Логин";
            // 
            // PanelLoginTBox
            // 
            this.PanelLoginTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLoginTBox.Location = new System.Drawing.Point(8, 18);
            this.PanelLoginTBox.Name = "PanelLoginTBox";
            this.PanelLoginTBox.Size = new System.Drawing.Size(262, 24);
            this.PanelLoginTBox.TabIndex = 1;
            this.PanelLoginTBox.TextChanged += new System.EventHandler(this.PanelTBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.PanelPassTBox);
            this.groupBox4.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8, 1, 8, 8);
            this.groupBox4.Size = new System.Drawing.Size(278, 50);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Пароль";
            // 
            // PanelPassTBox
            // 
            this.PanelPassTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPassTBox.Location = new System.Drawing.Point(8, 18);
            this.PanelPassTBox.Name = "PanelPassTBox";
            this.PanelPassTBox.Size = new System.Drawing.Size(262, 24);
            this.PanelPassTBox.TabIndex = 2;
            this.PanelPassTBox.TextChanged += new System.EventHandler(this.PanelTBox_TextChanged);
            // 
            // ErrorBlurPBox
            // 
            this.ErrorBlurPBox.BackColor = System.Drawing.Color.Transparent;
            this.ErrorBlurPBox.Image = global::BatchDomainTools.Properties.Resources.exclamation;
            this.ErrorBlurPBox.Location = new System.Drawing.Point(135, 305);
            this.ErrorBlurPBox.Name = "ErrorBlurPBox";
            this.ErrorBlurPBox.Size = new System.Drawing.Size(16, 16);
            this.ErrorBlurPBox.TabIndex = 1;
            this.ErrorBlurPBox.TabStop = false;
            this.ErrorBlurPBox.Visible = false;
            // 
            // ErrorToolTip
            // 
            this.ErrorToolTip.IsBalloon = true;
            this.ErrorToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.ErrorToolTip.ToolTipTitle = "Не верно указанные данные";
            this.ErrorToolTip.UseAnimation = false;
            this.ErrorToolTip.UseFading = false;
            // 
            // AccountViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 338);
            this.Controls.Add(this.ErrorBlurPBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(302, 338);
            this.MinimumSize = new System.Drawing.Size(302, 338);
            this.Name = "AccountViewForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBlurPBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ComboBox PanelTypeCBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PanelAddressTBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PanelLoginTBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox PanelPassTBox;
        private System.Windows.Forms.PictureBox ErrorBlurPBox;
        private System.Windows.Forms.ToolTip ErrorToolTip;


    }
}