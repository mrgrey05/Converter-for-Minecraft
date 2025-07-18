namespace CFM
{
    partial class FormSettings
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonOK = new CFM.Custom.CustomButton();
            this.buttonCancel = new CFM.Custom.CustomButton();
            this.labelOtherRemainder = new System.Windows.Forms.Label();
            this.checkBoxOtherRemainder = new System.Windows.Forms.CheckBox();
            this.checkBoxBigSizeFont = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxTheme = new System.Windows.Forms.ComboBox();
            this.colorDialogChoiceThemeColors = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanelItems = new System.Windows.Forms.TableLayoutPanel();
            this.labelBigSizeFont = new System.Windows.Forms.Label();
            this.panelButtons.SuspendLayout();
            this.tableLayoutPanelItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 148);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(324, 33);
            this.panelButtons.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonOK.Location = new System.Drawing.Point(150, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(81, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonCancel.Location = new System.Drawing.Point(237, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelOtherRemainder
            // 
            this.labelOtherRemainder.AutoSize = true;
            this.labelOtherRemainder.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelOtherRemainder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelOtherRemainder.Location = new System.Drawing.Point(31, 100);
            this.labelOtherRemainder.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelOtherRemainder.Name = "labelOtherRemainder";
            this.labelOtherRemainder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelOtherRemainder.Size = new System.Drawing.Size(118, 30);
            this.labelOtherRemainder.TabIndex = 17;
            this.labelOtherRemainder.Text = "Остаток \"по-другому\"";
            this.labelOtherRemainder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxOtherRemainder
            // 
            this.checkBoxOtherRemainder.AutoSize = true;
            this.checkBoxOtherRemainder.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxOtherRemainder.Location = new System.Drawing.Point(162, 103);
            this.checkBoxOtherRemainder.Name = "checkBoxOtherRemainder";
            this.checkBoxOtherRemainder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxOtherRemainder.Size = new System.Drawing.Size(15, 24);
            this.checkBoxOtherRemainder.TabIndex = 4;
            this.checkBoxOtherRemainder.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxOtherRemainder.UseVisualStyleBackColor = true;
            // 
            // checkBoxBigSizeFont
            // 
            this.checkBoxBigSizeFont.AutoSize = true;
            this.checkBoxBigSizeFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxBigSizeFont.Location = new System.Drawing.Point(162, 73);
            this.checkBoxBigSizeFont.Name = "checkBoxBigSizeFont";
            this.checkBoxBigSizeFont.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxBigSizeFont.Size = new System.Drawing.Size(15, 24);
            this.checkBoxBigSizeFont.TabIndex = 3;
            this.checkBoxBigSizeFont.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxBigSizeFont.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "Русский",
            "Deutsch",
            "Українська"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(162, 48);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(139, 21);
            this.comboBoxLanguage.TabIndex = 2;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelLanguage.Location = new System.Drawing.Point(111, 45);
            this.labelLanguage.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(38, 25);
            this.labelLanguage.TabIndex = 14;
            this.labelLanguage.Text = "Язык:";
            this.labelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTheme.Location = new System.Drawing.Point(47, 20);
            this.labelTheme.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(102, 25);
            this.labelTheme.TabIndex = 11;
            this.labelTheme.Text = "Тема приложения:";
            this.labelTheme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxTheme
            // 
            this.comboBoxTheme.BackColor = System.Drawing.Color.Black;
            this.comboBoxTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTheme.ForeColor = System.Drawing.Color.Black;
            this.comboBoxTheme.FormattingEnabled = true;
            this.comboBoxTheme.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная",
            "<Custom...>"});
            this.comboBoxTheme.Location = new System.Drawing.Point(162, 23);
            this.comboBoxTheme.Name = "comboBoxTheme";
            this.comboBoxTheme.Size = new System.Drawing.Size(139, 21);
            this.comboBoxTheme.TabIndex = 1;
            this.comboBoxTheme.SelectedIndexChanged += new System.EventHandler(this.comboBoxTheme_SelectedIndexChanged);
            // 
            // tableLayoutPanelItems
            // 
            this.tableLayoutPanelItems.ColumnCount = 2;
            this.tableLayoutPanelItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.50502F));
            this.tableLayoutPanelItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.49498F));
            this.tableLayoutPanelItems.Controls.Add(this.labelOtherRemainder, 0, 3);
            this.tableLayoutPanelItems.Controls.Add(this.labelTheme, 0, 0);
            this.tableLayoutPanelItems.Controls.Add(this.checkBoxOtherRemainder, 1, 3);
            this.tableLayoutPanelItems.Controls.Add(this.comboBoxTheme, 1, 0);
            this.tableLayoutPanelItems.Controls.Add(this.checkBoxBigSizeFont, 1, 2);
            this.tableLayoutPanelItems.Controls.Add(this.labelLanguage, 0, 1);
            this.tableLayoutPanelItems.Controls.Add(this.comboBoxLanguage, 1, 1);
            this.tableLayoutPanelItems.Controls.Add(this.labelBigSizeFont, 0, 2);
            this.tableLayoutPanelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelItems.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelItems.Name = "tableLayoutPanelItems";
            this.tableLayoutPanelItems.Padding = new System.Windows.Forms.Padding(5, 20, 20, 5);
            this.tableLayoutPanelItems.RowCount = 5;
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelItems.Size = new System.Drawing.Size(324, 148);
            this.tableLayoutPanelItems.TabIndex = 3;
            // 
            // labelBigSizeFont
            // 
            this.labelBigSizeFont.AutoSize = true;
            this.labelBigSizeFont.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelBigSizeFont.Location = new System.Drawing.Point(33, 70);
            this.labelBigSizeFont.Name = "labelBigSizeFont";
            this.labelBigSizeFont.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.labelBigSizeFont.Size = new System.Drawing.Size(123, 30);
            this.labelBigSizeFont.TabIndex = 18;
            this.labelBigSizeFont.Text = "Увеличенный шрифт:";
            this.labelBigSizeFont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(324, 181);
            this.Controls.Add(this.tableLayoutPanelItems);
            this.Controls.Add(this.panelButtons);
            this.MaximumSize = new System.Drawing.Size(340, 220);
            this.MinimumSize = new System.Drawing.Size(340, 220);
            this.Name = "FormSettings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panelButtons.ResumeLayout(false);
            this.tableLayoutPanelItems.ResumeLayout(false);
            this.tableLayoutPanelItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Custom.CustomButton buttonOK;
        private Custom.CustomButton buttonCancel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.CheckBox checkBoxBigSizeFont;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.ComboBox comboBoxTheme;
        private System.Windows.Forms.CheckBox checkBoxOtherRemainder;
        private System.Windows.Forms.Label labelOtherRemainder;
        private System.Windows.Forms.ColorDialog colorDialogChoiceThemeColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItems;
        private System.Windows.Forms.Label labelBigSizeFont;
    }
}