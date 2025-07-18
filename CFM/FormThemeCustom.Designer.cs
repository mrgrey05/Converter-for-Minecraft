namespace CFM
{
    partial class FormThemeCustom
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lText = new System.Windows.Forms.TextBox();
            this.labelColorHash = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.colorPickerControl = new CFM.Custom.ColorPickerControl();
            this.colorShadeSlider = new CFM.Custom.ColorShadeSlider();
            this.cButton = new CFM.Custom.CustomButton();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(216, 476);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(297, 476);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // lText
            // 
            this.lText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lText.Location = new System.Drawing.Point(227, 428);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(145, 32);
            this.lText.TabIndex = 19;
            this.lText.Text = "Текст";
            this.lText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelColorHash
            // 
            this.labelColorHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColorHash.AutoSize = true;
            this.labelColorHash.Location = new System.Drawing.Point(12, 486);
            this.labelColorHash.Name = "labelColorHash";
            this.labelColorHash.Size = new System.Drawing.Size(50, 13);
            this.labelColorHash.TabIndex = 23;
            this.labelColorHash.Text = "#FFFFFF";
            this.labelColorHash.Click += new System.EventHandler(this.labelColorHash_Click);
            // 
            // timer
            // 
            this.timer.Interval = 750;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // colorPickerControl
            // 
            this.colorPickerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorPickerControl.Location = new System.Drawing.Point(0, 0);
            this.colorPickerControl.Margin = new System.Windows.Forms.Padding(0);
            this.colorPickerControl.Name = "colorPickerControl";
            this.colorPickerControl.SelectedColor = System.Drawing.Color.Red;
            this.colorPickerControl.Size = new System.Drawing.Size(384, 400);
            this.colorPickerControl.TabIndex = 26;
            this.colorPickerControl.SelectedColorChanged += new System.EventHandler(this.colorPicker_SelectedColorChanged);
            this.colorPickerControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPickerControl_MouseDown);
            this.colorPickerControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPickerControl_MouseUp);
            // 
            // colorShadeSlider
            // 
            this.colorShadeSlider.BaseColor = System.Drawing.Color.Red;
            this.colorShadeSlider.Location = new System.Drawing.Point(0, 403);
            this.colorShadeSlider.Name = "colorShadeSlider";
            this.colorShadeSlider.ShadeValue = 50;
            this.colorShadeSlider.Size = new System.Drawing.Size(384, 16);
            this.colorShadeSlider.TabIndex = 25;
            this.colorShadeSlider.ShadeValueChanged += new System.EventHandler(this.colorShadeSlider_ShadeValueChanged);
            // 
            // cButton
            // 
            this.cButton.BackColor = System.Drawing.Color.White;
            this.cButton.BaseColor = System.Drawing.Color.White;
            this.cButton.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.cButton.CornerRadius = 5;
            this.cButton.FlatAppearance.BorderSize = 3;
            this.cButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.cButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.cButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cButton.ForeColor = System.Drawing.Color.Black;
            this.cButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.cButton.Location = new System.Drawing.Point(15, 425);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(150, 40);
            this.cButton.TabIndex = 15;
            this.cButton.Text = "Кнопка";
            this.cButton.UseVisualStyleBackColor = false;
            // 
            // FormThemeCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 511);
            this.Controls.Add(this.colorPickerControl);
            this.Controls.Add(this.colorShadeSlider);
            this.Controls.Add(this.labelColorHash);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximumSize = new System.Drawing.Size(400, 550);
            this.MinimumSize = new System.Drawing.Size(400, 550);
            this.Name = "FormThemeCustom";
            this.Text = "Выбор цвета";
            this.Load += new System.EventHandler(this.ThemeCustom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private Custom.CustomButton cButton;
        private System.Windows.Forms.TextBox lText;
        private System.Windows.Forms.Label labelColorHash;
        private Custom.ColorShadeSlider colorShadeSlider;
        private System.Windows.Forms.Timer timer;
        public Custom.ColorPickerControl colorPickerControl;
    }
}