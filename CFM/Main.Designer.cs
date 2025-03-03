namespace CFM
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.миниокноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ClearAllResults = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Comma = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.remainderLabel = new System.Windows.Forms.Label();
            this.textBoxConvert1 = new System.Windows.Forms.TextBox();
            this.comboBoxConvert1 = new System.Windows.Forms.ComboBox();
            this.comboBoxConvert2 = new System.Windows.Forms.ComboBox();
            this.textBoxConvert2 = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.файлToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.миниокноToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            // 
            // миниокноToolStripMenuItem
            // 
            this.миниокноToolStripMenuItem.Name = "миниокноToolStripMenuItem";
            resources.ApplyResources(this.миниокноToolStripMenuItem, "миниокноToolStripMenuItem");
            this.миниокноToolStripMenuItem.Click += new System.EventHandler(this.миниокноToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            resources.ApplyResources(this.настройкиToolStripMenuItem, "настройкиToolStripMenuItem");
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            resources.ApplyResources(this.помощьToolStripMenuItem, "помощьToolStripMenuItem");
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.cправкаToolStripMenuItem_Click);
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tableLayoutPanelButtons, "tableLayoutPanelButtons");
            this.tableLayoutPanelButtons.Controls.Add(this.ClearAllResults, 1, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.Clear, 2, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.Seven, 0, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Nine, 2, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Six, 2, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.Five, 1, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.Four, 0, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.Three, 2, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.Two, 1, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.One, 0, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.Zero, 1, 4);
            this.tableLayoutPanelButtons.Controls.Add(this.Eight, 1, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Comma, 2, 4);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            // 
            // ClearAllResults
            // 
            resources.ApplyResources(this.ClearAllResults, "ClearAllResults");
            this.ClearAllResults.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClearAllResults.FlatAppearance.BorderSize = 2;
            this.ClearAllResults.ForeColor = System.Drawing.Color.Brown;
            this.ClearAllResults.Name = "ClearAllResults";
            this.ClearAllResults.TabStop = false;
            this.ClearAllResults.UseVisualStyleBackColor = true;
            this.ClearAllResults.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Clear
            // 
            resources.ApplyResources(this.Clear, "Clear");
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Clear.FlatAppearance.BorderSize = 2;
            this.Clear.Name = "Clear";
            this.Clear.TabStop = false;
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Seven
            // 
            resources.ApplyResources(this.Seven, "Seven");
            this.Seven.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Seven.FlatAppearance.BorderSize = 2;
            this.Seven.Name = "Seven";
            this.Seven.TabStop = false;
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Nine
            // 
            resources.ApplyResources(this.Nine, "Nine");
            this.Nine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Nine.FlatAppearance.BorderSize = 2;
            this.Nine.Name = "Nine";
            this.Nine.TabStop = false;
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Six
            // 
            resources.ApplyResources(this.Six, "Six");
            this.Six.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Six.FlatAppearance.BorderSize = 2;
            this.Six.Name = "Six";
            this.Six.TabStop = false;
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Five
            // 
            resources.ApplyResources(this.Five, "Five");
            this.Five.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Five.FlatAppearance.BorderSize = 2;
            this.Five.Name = "Five";
            this.Five.TabStop = false;
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Four
            // 
            resources.ApplyResources(this.Four, "Four");
            this.Four.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Four.FlatAppearance.BorderSize = 2;
            this.Four.Name = "Four";
            this.Four.TabStop = false;
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Three
            // 
            resources.ApplyResources(this.Three, "Three");
            this.Three.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Three.FlatAppearance.BorderSize = 2;
            this.Three.Name = "Three";
            this.Three.TabStop = false;
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Two
            // 
            resources.ApplyResources(this.Two, "Two");
            this.Two.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Two.FlatAppearance.BorderSize = 2;
            this.Two.Name = "Two";
            this.Two.TabStop = false;
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // One
            // 
            resources.ApplyResources(this.One, "One");
            this.One.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.One.FlatAppearance.BorderSize = 2;
            this.One.Name = "One";
            this.One.TabStop = false;
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Zero
            // 
            resources.ApplyResources(this.Zero, "Zero");
            this.Zero.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Zero.FlatAppearance.BorderSize = 2;
            this.Zero.Name = "Zero";
            this.Zero.TabStop = false;
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Eight
            // 
            resources.ApplyResources(this.Eight, "Eight");
            this.Eight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Eight.FlatAppearance.BorderSize = 2;
            this.Eight.Name = "Eight";
            this.Eight.TabStop = false;
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // Comma
            // 
            resources.ApplyResources(this.Comma, "Comma");
            this.Comma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Comma.FlatAppearance.BorderSize = 2;
            this.Comma.Name = "Comma";
            this.Comma.TabStop = false;
            this.Comma.UseVisualStyleBackColor = true;
            this.Comma.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.remainderLabel);
            this.panel1.Controls.Add(this.textBoxConvert1);
            this.panel1.Controls.Add(this.comboBoxConvert1);
            this.panel1.Controls.Add(this.comboBoxConvert2);
            this.panel1.Controls.Add(this.textBoxConvert2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // remainderLabel
            // 
            resources.ApplyResources(this.remainderLabel, "remainderLabel");
            this.remainderLabel.Name = "remainderLabel";
            // 
            // textBoxConvert1
            // 
            resources.ApplyResources(this.textBoxConvert1, "textBoxConvert1");
            this.textBoxConvert1.Name = "textBoxConvert1";
            this.textBoxConvert1.Tag = "";
            this.textBoxConvert1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxConvert1.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxConvert1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConvert1_KeyPress);
            this.textBoxConvert1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // comboBoxConvert1
            // 
            this.comboBoxConvert1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxConvert1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxConvert1, "comboBoxConvert1");
            this.comboBoxConvert1.FormattingEnabled = true;
            this.comboBoxConvert1.Items.AddRange(new object[] {
            resources.GetString("comboBoxConvert1.Items"),
            resources.GetString("comboBoxConvert1.Items1"),
            resources.GetString("comboBoxConvert1.Items2")});
            this.comboBoxConvert1.Name = "comboBoxConvert1";
            this.comboBoxConvert1.TabStop = false;
            this.comboBoxConvert1.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // comboBoxConvert2
            // 
            this.comboBoxConvert2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxConvert2, "comboBoxConvert2");
            this.comboBoxConvert2.FormattingEnabled = true;
            this.comboBoxConvert2.Items.AddRange(new object[] {
            resources.GetString("comboBoxConvert2.Items"),
            resources.GetString("comboBoxConvert2.Items1"),
            resources.GetString("comboBoxConvert2.Items2")});
            this.comboBoxConvert2.Name = "comboBoxConvert2";
            this.comboBoxConvert2.TabStop = false;
            this.comboBoxConvert2.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // textBoxConvert2
            // 
            resources.ApplyResources(this.textBoxConvert2, "textBoxConvert2");
            this.textBoxConvert2.Name = "textBoxConvert2";
            this.textBoxConvert2.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxConvert2.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxConvert2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConvert2_KeyPress);
            this.textBoxConvert2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.tableLayoutPanelButtons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem миниокноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Button ClearAllResults;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Comma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label remainderLabel;
        private System.Windows.Forms.TextBox textBoxConvert1;
        private System.Windows.Forms.ComboBox comboBoxConvert1;
        private System.Windows.Forms.ComboBox comboBoxConvert2;
        private System.Windows.Forms.TextBox textBoxConvert2;
    }
}

