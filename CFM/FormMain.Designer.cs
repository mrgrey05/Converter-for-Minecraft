namespace CFM
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.миниокноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поверхОстальныхОконToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.checkBoxStack16 = new System.Windows.Forms.CheckBox();
            this.remainderLabel = new System.Windows.Forms.Label();
            this.textBoxConvert1 = new System.Windows.Forms.TextBox();
            this.comboBoxConvert1 = new System.Windows.Forms.ComboBox();
            this.comboBoxConvert2 = new System.Windows.Forms.ComboBox();
            this.textBoxConvert2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ClearAllResults = new CFM.Custom.CustomButton();
            this.Clear = new CFM.Custom.CustomButton();
            this.Seven = new CFM.Custom.CustomButton();
            this.Eight = new CFM.Custom.CustomButton();
            this.Nine = new CFM.Custom.CustomButton();
            this.Four = new CFM.Custom.CustomButton();
            this.Five = new CFM.Custom.CustomButton();
            this.Six = new CFM.Custom.CustomButton();
            this.One = new CFM.Custom.CustomButton();
            this.Two = new CFM.Custom.CustomButton();
            this.Three = new CFM.Custom.CustomButton();
            this.Zero = new CFM.Custom.CustomButton();
            this.Comma = new CFM.Custom.CustomButton();
            this.buttonShowOrHidePanelButtons = new CFM.Custom.CustomButton();
            this.menuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.файлToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.миниокноToolStripMenuItem,
            this.поверхОстальныхОконToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // миниокноToolStripMenuItem
            // 
            this.миниокноToolStripMenuItem.Name = "миниокноToolStripMenuItem";
            this.миниокноToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.миниокноToolStripMenuItem.Text = "Мини-окно           F5";
            this.миниокноToolStripMenuItem.Click += new System.EventHandler(this.миниокноToolStripMenuItem_Click);
            // 
            // поверхОстальныхОконToolStripMenuItem
            // 
            this.поверхОстальныхОконToolStripMenuItem.CheckOnClick = true;
            this.поверхОстальныхОконToolStripMenuItem.Name = "поверхОстальныхОконToolStripMenuItem";
            this.поверхОстальныхОконToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.поверхОстальныхОконToolStripMenuItem.Text = "Поверх остальных окон";
            this.поверхОстальныхОконToolStripMenuItem.Click += new System.EventHandler(this.поверхОстальныхОконToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.выходToolStripMenuItem.Text = "Выход                  Esc";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.cправкаToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.buttonShowOrHidePanelButtons);
            this.panelMain.Controls.Add(this.checkBoxStack16);
            this.panelMain.Controls.Add(this.remainderLabel);
            this.panelMain.Controls.Add(this.textBoxConvert1);
            this.panelMain.Controls.Add(this.comboBoxConvert1);
            this.panelMain.Controls.Add(this.comboBoxConvert2);
            this.panelMain.Controls.Add(this.textBoxConvert2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(284, 253);
            this.panelMain.TabIndex = 8;
            // 
            // checkBoxStack16
            // 
            this.checkBoxStack16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxStack16.AutoSize = true;
            this.checkBoxStack16.Location = new System.Drawing.Point(265, 7);
            this.checkBoxStack16.Name = "checkBoxStack16";
            this.checkBoxStack16.Size = new System.Drawing.Size(15, 14);
            this.checkBoxStack16.TabIndex = 6;
            this.checkBoxStack16.UseVisualStyleBackColor = true;
            this.checkBoxStack16.CheckedChanged += new System.EventHandler(this.checkBoxStack16_CheckedChanged);
            this.checkBoxStack16.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // remainderLabel
            // 
            this.remainderLabel.AutoSize = true;
            this.remainderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.remainderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.remainderLabel.Location = new System.Drawing.Point(17, 209);
            this.remainderLabel.Name = "remainderLabel";
            this.remainderLabel.Size = new System.Drawing.Size(59, 15);
            this.remainderLabel.TabIndex = 4;
            this.remainderLabel.Text = "Остаток:";
            // 
            // textBoxConvert1
            // 
            this.textBoxConvert1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConvert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxConvert1.Location = new System.Drawing.Point(18, 30);
            this.textBoxConvert1.Name = "textBoxConvert1";
            this.textBoxConvert1.Size = new System.Drawing.Size(231, 38);
            this.textBoxConvert1.TabIndex = 0;
            this.textBoxConvert1.Tag = "";
            this.textBoxConvert1.Text = "0";
            this.textBoxConvert1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxConvert1.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxConvert1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxConvert1_KeyDown);
            this.textBoxConvert1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConvert1_KeyPress);
            this.textBoxConvert1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // comboBoxConvert1
            // 
            this.comboBoxConvert1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxConvert1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConvert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.comboBoxConvert1.FormattingEnabled = true;
            this.comboBoxConvert1.Items.AddRange(new object[] {
            "Блок",
            "Стак",
            "Шалкер"});
            this.comboBoxConvert1.Location = new System.Drawing.Point(19, 74);
            this.comboBoxConvert1.Name = "comboBoxConvert1";
            this.comboBoxConvert1.Size = new System.Drawing.Size(181, 33);
            this.comboBoxConvert1.TabIndex = 1;
            this.comboBoxConvert1.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            this.comboBoxConvert1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // comboBoxConvert2
            // 
            this.comboBoxConvert2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConvert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.comboBoxConvert2.FormattingEnabled = true;
            this.comboBoxConvert2.Items.AddRange(new object[] {
            "Блок",
            "Стак",
            "Шалкер"});
            this.comboBoxConvert2.Location = new System.Drawing.Point(18, 173);
            this.comboBoxConvert2.Name = "comboBoxConvert2";
            this.comboBoxConvert2.Size = new System.Drawing.Size(181, 33);
            this.comboBoxConvert2.TabIndex = 3;
            this.comboBoxConvert2.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            this.comboBoxConvert2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // textBoxConvert2
            // 
            this.textBoxConvert2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConvert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxConvert2.Location = new System.Drawing.Point(18, 129);
            this.textBoxConvert2.Name = "textBoxConvert2";
            this.textBoxConvert2.Size = new System.Drawing.Size(231, 38);
            this.textBoxConvert2.TabIndex = 2;
            this.textBoxConvert2.Text = "0";
            this.textBoxConvert2.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxConvert2.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxConvert2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxConvert2_KeyDown);
            this.textBoxConvert2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConvert2_KeyPress);
            this.textBoxConvert2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelButtons.ColumnCount = 3;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelButtons.Controls.Add(this.ClearAllResults, 1, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.Clear, 2, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.Seven, 0, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Eight, 1, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Nine, 2, 1);
            this.tableLayoutPanelButtons.Controls.Add(this.Four, 0, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.Five, 1, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.Six, 2, 2);
            this.tableLayoutPanelButtons.Controls.Add(this.One, 0, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.Two, 1, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.Three, 2, 3);
            this.tableLayoutPanelButtons.Controls.Add(this.Zero, 1, 4);
            this.tableLayoutPanelButtons.Controls.Add(this.Comma, 2, 4);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 278);
            this.tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 5;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(284, 233);
            this.tableLayoutPanelButtons.TabIndex = 18;
            // 
            // ClearAllResults
            // 
            this.ClearAllResults.BackColor = System.Drawing.Color.White;
            this.ClearAllResults.BaseColor = System.Drawing.Color.White;
            this.ClearAllResults.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClearAllResults.CornerRadius = 5;
            this.ClearAllResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllResults.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClearAllResults.FlatAppearance.BorderSize = 0;
            this.ClearAllResults.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.ClearAllResults.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ClearAllResults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ClearAllResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearAllResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearAllResults.ForeColor = System.Drawing.Color.Maroon;
            this.ClearAllResults.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ClearAllResults.Location = new System.Drawing.Point(96, 2);
            this.ClearAllResults.Margin = new System.Windows.Forms.Padding(2);
            this.ClearAllResults.Name = "ClearAllResults";
            this.ClearAllResults.Size = new System.Drawing.Size(90, 42);
            this.ClearAllResults.TabIndex = 0;
            this.ClearAllResults.Text = "C";
            this.ClearAllResults.UseVisualStyleBackColor = false;
            this.ClearAllResults.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.ClearAllResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.White;
            this.Clear.BaseColor = System.Drawing.Color.White;
            this.Clear.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Clear.CornerRadius = 5;
            this.Clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.ForeColor = System.Drawing.Color.Black;
            this.Clear.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Clear.Location = new System.Drawing.Point(190, 2);
            this.Clear.Margin = new System.Windows.Forms.Padding(2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(92, 42);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "<";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Clear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Seven
            // 
            this.Seven.BackColor = System.Drawing.Color.White;
            this.Seven.BaseColor = System.Drawing.Color.White;
            this.Seven.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Seven.CornerRadius = 5;
            this.Seven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Seven.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Seven.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Seven.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Seven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Seven.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Seven.ForeColor = System.Drawing.Color.Black;
            this.Seven.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Seven.Location = new System.Drawing.Point(2, 48);
            this.Seven.Margin = new System.Windows.Forms.Padding(2);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(90, 42);
            this.Seven.TabIndex = 2;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = false;
            this.Seven.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Seven.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Eight
            // 
            this.Eight.BackColor = System.Drawing.Color.White;
            this.Eight.BaseColor = System.Drawing.Color.White;
            this.Eight.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Eight.CornerRadius = 5;
            this.Eight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Eight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Eight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Eight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Eight.ForeColor = System.Drawing.Color.Black;
            this.Eight.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Eight.Location = new System.Drawing.Point(96, 48);
            this.Eight.Margin = new System.Windows.Forms.Padding(2);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(90, 42);
            this.Eight.TabIndex = 3;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = false;
            this.Eight.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Eight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Nine
            // 
            this.Nine.BackColor = System.Drawing.Color.White;
            this.Nine.BaseColor = System.Drawing.Color.White;
            this.Nine.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Nine.CornerRadius = 5;
            this.Nine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Nine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Nine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Nine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Nine.ForeColor = System.Drawing.Color.Black;
            this.Nine.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Nine.Location = new System.Drawing.Point(190, 48);
            this.Nine.Margin = new System.Windows.Forms.Padding(2);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(92, 42);
            this.Nine.TabIndex = 4;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = false;
            this.Nine.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Nine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Four
            // 
            this.Four.BackColor = System.Drawing.Color.White;
            this.Four.BaseColor = System.Drawing.Color.White;
            this.Four.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Four.CornerRadius = 5;
            this.Four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Four.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Four.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Four.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Four.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Four.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Four.ForeColor = System.Drawing.Color.Black;
            this.Four.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Four.Location = new System.Drawing.Point(2, 94);
            this.Four.Margin = new System.Windows.Forms.Padding(2);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(90, 42);
            this.Four.TabIndex = 5;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = false;
            this.Four.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Four.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Five
            // 
            this.Five.BackColor = System.Drawing.Color.White;
            this.Five.BaseColor = System.Drawing.Color.White;
            this.Five.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Five.CornerRadius = 5;
            this.Five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Five.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Five.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Five.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Five.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Five.ForeColor = System.Drawing.Color.Black;
            this.Five.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Five.Location = new System.Drawing.Point(96, 94);
            this.Five.Margin = new System.Windows.Forms.Padding(2);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(90, 42);
            this.Five.TabIndex = 6;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = false;
            this.Five.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Five.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Six
            // 
            this.Six.BackColor = System.Drawing.Color.White;
            this.Six.BaseColor = System.Drawing.Color.White;
            this.Six.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Six.CornerRadius = 5;
            this.Six.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Six.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Six.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Six.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Six.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Six.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Six.ForeColor = System.Drawing.Color.Black;
            this.Six.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Six.Location = new System.Drawing.Point(190, 94);
            this.Six.Margin = new System.Windows.Forms.Padding(2);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(92, 42);
            this.Six.TabIndex = 7;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = false;
            this.Six.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Six.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // One
            // 
            this.One.BackColor = System.Drawing.Color.White;
            this.One.BaseColor = System.Drawing.Color.White;
            this.One.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.One.CornerRadius = 5;
            this.One.Dock = System.Windows.Forms.DockStyle.Fill;
            this.One.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.One.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.One.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.One.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.One.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.One.ForeColor = System.Drawing.Color.Black;
            this.One.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.One.Location = new System.Drawing.Point(2, 140);
            this.One.Margin = new System.Windows.Forms.Padding(2);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(90, 42);
            this.One.TabIndex = 8;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = false;
            this.One.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.One.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Two
            // 
            this.Two.BackColor = System.Drawing.Color.White;
            this.Two.BaseColor = System.Drawing.Color.White;
            this.Two.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Two.CornerRadius = 5;
            this.Two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Two.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Two.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Two.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Two.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Two.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Two.ForeColor = System.Drawing.Color.Black;
            this.Two.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Two.Location = new System.Drawing.Point(96, 140);
            this.Two.Margin = new System.Windows.Forms.Padding(2);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(90, 42);
            this.Two.TabIndex = 9;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = false;
            this.Two.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Two.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Three
            // 
            this.Three.BackColor = System.Drawing.Color.White;
            this.Three.BaseColor = System.Drawing.Color.White;
            this.Three.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Three.CornerRadius = 5;
            this.Three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Three.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Three.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Three.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Three.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Three.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Three.ForeColor = System.Drawing.Color.Black;
            this.Three.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Three.Location = new System.Drawing.Point(190, 140);
            this.Three.Margin = new System.Windows.Forms.Padding(2);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(92, 42);
            this.Three.TabIndex = 10;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = false;
            this.Three.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Three.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Zero
            // 
            this.Zero.BackColor = System.Drawing.Color.White;
            this.Zero.BaseColor = System.Drawing.Color.White;
            this.Zero.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Zero.CornerRadius = 5;
            this.Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zero.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Zero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Zero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Zero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zero.ForeColor = System.Drawing.Color.Black;
            this.Zero.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Zero.Location = new System.Drawing.Point(96, 186);
            this.Zero.Margin = new System.Windows.Forms.Padding(2);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(90, 45);
            this.Zero.TabIndex = 11;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = false;
            this.Zero.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Zero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // Comma
            // 
            this.Comma.BackColor = System.Drawing.Color.White;
            this.Comma.BaseColor = System.Drawing.Color.White;
            this.Comma.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Comma.CornerRadius = 5;
            this.Comma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Comma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Comma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Comma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Comma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Comma.ForeColor = System.Drawing.Color.Black;
            this.Comma.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Comma.Location = new System.Drawing.Point(190, 186);
            this.Comma.Margin = new System.Windows.Forms.Padding(2);
            this.Comma.Name = "Comma";
            this.Comma.Size = new System.Drawing.Size(92, 45);
            this.Comma.TabIndex = 12;
            this.Comma.Text = ",";
            this.Comma.UseVisualStyleBackColor = false;
            this.Comma.Click += new System.EventHandler(this.ButtonPanelButtons_Click);
            this.Comma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // buttonShowOrHidePanelButtons
            // 
            this.buttonShowOrHidePanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowOrHidePanelButtons.BackColor = System.Drawing.Color.White;
            this.buttonShowOrHidePanelButtons.BaseColor = System.Drawing.Color.White;
            this.buttonShowOrHidePanelButtons.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.buttonShowOrHidePanelButtons.CornerRadius = 5;
            this.buttonShowOrHidePanelButtons.FlatAppearance.BorderSize = 0;
            this.buttonShowOrHidePanelButtons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonShowOrHidePanelButtons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonShowOrHidePanelButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowOrHidePanelButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowOrHidePanelButtons.ForeColor = System.Drawing.Color.Black;
            this.buttonShowOrHidePanelButtons.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.buttonShowOrHidePanelButtons.Location = new System.Drawing.Point(245, 217);
            this.buttonShowOrHidePanelButtons.Name = "buttonShowOrHidePanelButtons";
            this.buttonShowOrHidePanelButtons.Size = new System.Drawing.Size(35, 35);
            this.buttonShowOrHidePanelButtons.TabIndex = 7;
            this.buttonShowOrHidePanelButtons.Text = "⮝";
            this.buttonShowOrHidePanelButtons.UseVisualStyleBackColor = false;
            this.buttonShowOrHidePanelButtons.Click += new System.EventHandler(this.buttonShowOrHidePanelButtons_Click);
            this.buttonShowOrHidePanelButtons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionalKeys_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(284, 511);
            this.Controls.Add(this.tableLayoutPanelButtons);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(300, 550);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem миниокноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem поверхОстальныхОконToolStripMenuItem;
        public System.Windows.Forms.Label remainderLabel;
        public System.Windows.Forms.TextBox textBoxConvert1;
        public System.Windows.Forms.ComboBox comboBoxConvert1;
        public System.Windows.Forms.ComboBox comboBoxConvert2;
        public System.Windows.Forms.TextBox textBoxConvert2;
        public System.Windows.Forms.CheckBox checkBoxStack16;
        public Custom.CustomButton buttonShowOrHidePanelButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private Custom.CustomButton ClearAllResults;
        private Custom.CustomButton Clear;
        private Custom.CustomButton Seven;
        private Custom.CustomButton Eight;
        private Custom.CustomButton Nine;
        private Custom.CustomButton Four;
        private Custom.CustomButton Five;
        private Custom.CustomButton Six;
        private Custom.CustomButton One;
        private Custom.CustomButton Two;
        private Custom.CustomButton Three;
        private Custom.CustomButton Zero;
        private Custom.CustomButton Comma;
    }
}

