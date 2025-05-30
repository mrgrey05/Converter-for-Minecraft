namespace CFM
{
    partial class Settings
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagesMain = new System.Windows.Forms.TabPage();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.buttonOK = new CFM.Custom.CustomButton();
            this.buttonCancel = new CFM.Custom.CustomButton();
            this.groupBoxCustomization = new System.Windows.Forms.GroupBox();
            this.checkBoxBigSizeFont = new System.Windows.Forms.CheckBox();
            this.labelBigSizeFont = new System.Windows.Forms.Label();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxTheme = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPagesMain.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.groupBoxCustomization.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagesMain);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(464, 361);
            this.tabControl.TabIndex = 0;
            // 
            // tabPagesMain
            // 
            this.tabPagesMain.Controls.Add(this.groupBoxOther);
            this.tabPagesMain.Controls.Add(this.buttonOK);
            this.tabPagesMain.Controls.Add(this.buttonCancel);
            this.tabPagesMain.Controls.Add(this.groupBoxCustomization);
            this.tabPagesMain.Location = new System.Drawing.Point(4, 22);
            this.tabPagesMain.Name = "tabPagesMain";
            this.tabPagesMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagesMain.Size = new System.Drawing.Size(456, 335);
            this.tabPagesMain.TabIndex = 0;
            this.tabPagesMain.Text = "Общие";
            this.tabPagesMain.UseVisualStyleBackColor = true;
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.comboBoxLanguage);
            this.groupBoxOther.Controls.Add(this.labelLanguage);
            this.groupBoxOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxOther.Location = new System.Drawing.Point(3, 128);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(450, 100);
            this.groupBoxOther.TabIndex = 7;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "Другое";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(144, 35);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 5;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(96, 38);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(38, 13);
            this.labelLanguage.TabIndex = 4;
            this.labelLanguage.Text = "Язык:";
            this.labelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.White;
            this.buttonOK.BaseColor = System.Drawing.Color.White;
            this.buttonOK.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.buttonOK.CornerRadius = 2;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.ForeColor = System.Drawing.Color.Black;
            this.buttonOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.buttonOK.Location = new System.Drawing.Point(280, 304);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(81, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.BaseColor = System.Drawing.Color.White;
            this.buttonCancel.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.buttonCancel.CornerRadius = 2;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.buttonCancel.Location = new System.Drawing.Point(367, 304);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxCustomization
            // 
            this.groupBoxCustomization.Controls.Add(this.checkBoxBigSizeFont);
            this.groupBoxCustomization.Controls.Add(this.labelBigSizeFont);
            this.groupBoxCustomization.Controls.Add(this.labelTheme);
            this.groupBoxCustomization.Controls.Add(this.comboBoxTheme);
            this.groupBoxCustomization.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCustomization.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCustomization.Name = "groupBoxCustomization";
            this.groupBoxCustomization.Size = new System.Drawing.Size(450, 125);
            this.groupBoxCustomization.TabIndex = 4;
            this.groupBoxCustomization.TabStop = false;
            this.groupBoxCustomization.Text = "Дизайн";
            // 
            // checkBoxBigSizeFont
            // 
            this.checkBoxBigSizeFont.AutoSize = true;
            this.checkBoxBigSizeFont.Location = new System.Drawing.Point(144, 67);
            this.checkBoxBigSizeFont.Name = "checkBoxBigSizeFont";
            this.checkBoxBigSizeFont.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBigSizeFont.TabIndex = 3;
            this.checkBoxBigSizeFont.UseVisualStyleBackColor = true;
            // 
            // labelBigSizeFont
            // 
            this.labelBigSizeFont.AutoSize = true;
            this.labelBigSizeFont.Location = new System.Drawing.Point(19, 66);
            this.labelBigSizeFont.Name = "labelBigSizeFont";
            this.labelBigSizeFont.Size = new System.Drawing.Size(115, 13);
            this.labelBigSizeFont.TabIndex = 2;
            this.labelBigSizeFont.Text = "Увеличенный шрифт:";
            this.labelBigSizeFont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(32, 32);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(102, 13);
            this.labelTheme.TabIndex = 0;
            this.labelTheme.Text = "Тема приложения:";
            this.labelTheme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxTheme
            // 
            this.comboBoxTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTheme.BackColor = System.Drawing.Color.Black;
            this.comboBoxTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTheme.ForeColor = System.Drawing.Color.Black;
            this.comboBoxTheme.FormattingEnabled = true;
            this.comboBoxTheme.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная"});
            this.comboBoxTheme.Location = new System.Drawing.Point(144, 29);
            this.comboBoxTheme.Name = "comboBoxTheme";
            this.comboBoxTheme.Size = new System.Drawing.Size(224, 21);
            this.comboBoxTheme.TabIndex = 1;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.tabControl);
            this.MaximumSize = new System.Drawing.Size(480, 400);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPagesMain.ResumeLayout(false);
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
            this.groupBoxCustomization.ResumeLayout(false);
            this.groupBoxCustomization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagesMain;
        private System.Windows.Forms.ComboBox comboBoxTheme;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.GroupBox groupBoxCustomization;
        private Custom.CustomButton buttonOK;
        private Custom.CustomButton buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxBigSizeFont;
        private System.Windows.Forms.Label labelBigSizeFont;
        private System.Windows.Forms.GroupBox groupBoxOther;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
    }
}