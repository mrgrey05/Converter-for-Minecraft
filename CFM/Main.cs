using CFM.Custom;
using CFM.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class Main : Form
    {
        #region [Общие переменные]

        private bool isConverting = false;
        private TextBox lastFocusedTextBox = null;
        private bool shouldResetOnNextInput = false;
        private bool isContentSelected = false;
        private SmallWindow smallWindow;

        #endregion

        public Main()
        {
            InitializeComponent();

            textBoxConvert1.Font = new Font(textBoxConvert1.Font, FontStyle.Bold);

            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";

            ApplyTheme();
            ApplyBigFontSize();
            LoadLanguage();
            ApplyLabels();
        }

        #region [Вспомогательные настройки для обработчиков событий]

        /// <summary>
        /// Фокус текстового поля
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        private void SetTextBoxFocus(TextBox textBox)
        {
            SetResetFlag(textBox);
            SetTextBoxFont(textBox);
            textBox.SelectAll();
            isContentSelected = true;
            lastFocusedTextBox = textBox;
        }
        /// <summary>
        /// Отвечает за последнее сфокусированное текстовое поле
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        private void SetResetFlag(TextBox textBox)
        {
            if (lastFocusedTextBox != null && lastFocusedTextBox != textBox)
            {
                shouldResetOnNextInput = true;
            }
            lastFocusedTextBox = textBox;
        }
        /// <summary>
        /// В зависимости от сфокусированного текстового поля выставляет жирный текст
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        private void SetTextBoxFont(TextBox textBox)
        {
            textBoxConvert1.Font = (textBox == textBoxConvert1) ? new Font(textBoxConvert1.Font, FontStyle.Bold) : new Font(textBoxConvert1.Font, FontStyle.Regular);
            textBoxConvert2.Font = (textBox == textBoxConvert2) ? new Font(textBoxConvert2.Font, FontStyle.Bold) : new Font(textBoxConvert2.Font, FontStyle.Regular);
        }
        /// <summary>
        /// Главный метод, отвечающий за конвертацию
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        private void PerformConversion(TextBox textBox)
        {
            ComboBox fromComboBox = (textBox == textBoxConvert1) ? comboBoxConvert1 : comboBoxConvert2;
            ComboBox toComboBox = (textBox == textBoxConvert1) ? comboBoxConvert2 : comboBoxConvert1;

            if (fromComboBox.SelectedIndex == -1 || toComboBox.SelectedIndex == -1)
            {
                textBox.Text = "0";
                return;
            }

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                return;
            }

            try
            {
                double value = double.Parse(textBox.Text);
                double convertedValue = Converter.ConvertValue(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString(), checkBoxStack16.Checked);
                string remainder = Converter.GetRemainder(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString(), checkBoxStack16.Checked, Properties.Settings.Default.IsOtherRemainder);
                string otherTextBoxName = (textBox == textBoxConvert1) ? textBoxConvert2.Name : textBoxConvert1.Name;
                TextBox otherTextBox = (TextBox)this.Controls.Find(otherTextBoxName, true)[0];
                otherTextBox.Text = convertedValue.ToString();
                remainderLabel.Text = $"{Resources.MainFormRemainder}: {remainder}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        /// <summary>
        /// Отвечает за кнопки цифр и стирания с фокусированного текстового поля
        /// </summary>
        /// <param name="buttonText">Текст или его свойство у элемента управления</param>
        private void HandleButtonClick(string buttonText)
        {
            if (lastFocusedTextBox == null)
            {
                lastFocusedTextBox = textBoxConvert1;
                SetTextBoxFocus(lastFocusedTextBox);
            }

            string currentText = lastFocusedTextBox.Text;

            switch (buttonText)
            {
                case ",":
                    if (!currentText.Contains(","))
                    {
                        lastFocusedTextBox.Text = currentText + ",";
                        lastFocusedTextBox.SelectionStart = lastFocusedTextBox.Text.Length;
                    }
                    break;
                case ".":
                    if (!currentText.Contains("."))
                    {
                        lastFocusedTextBox.Text = currentText + ".";
                        lastFocusedTextBox.SelectionStart = lastFocusedTextBox.Text.Length;
                    }
                    break;
                case "<":
                    if (currentText.Length > 0)
                    {
                        lastFocusedTextBox.Text = currentText.Substring(0, currentText.Length - 1);
                        if (string.IsNullOrEmpty(lastFocusedTextBox.Text))
                        {
                            lastFocusedTextBox.Text = "0";
                        }
                        lastFocusedTextBox.SelectionStart = lastFocusedTextBox.Text.Length;
                    }
                    break;
                case "C":
                    lastFocusedTextBox.Text = "0";
                    lastFocusedTextBox.SelectionStart = lastFocusedTextBox.Text.Length;
                    break;
                default:
                    if (shouldResetOnNextInput)
                    {
                        lastFocusedTextBox.Text = buttonText;
                        shouldResetOnNextInput = false;
                        isContentSelected = false;
                    }
                    else
                    {
                        if (currentText == "0")
                        {
                            lastFocusedTextBox.Text = buttonText;
                        }
                        else
                        {
                            lastFocusedTextBox.Text = currentText + buttonText;
                        }
                    }
                    lastFocusedTextBox.SelectionStart = lastFocusedTextBox.Text.Length;
                    break;
            }
        }
        /// <summary>
        /// Помогает в записи чисел с плавающей запятой
        /// </summary>
        /// <param name="e">Нажатие кнопки</param>
        /// <param name="textBox">Текстовое поле</param>
        private void HandleKeyPress(KeyPressEventArgs e, TextBox textBox)
        {
            if (Properties.Settings.Default.Language == "en-US")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == '.' && textBox.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == ',' && textBox.Text.Contains(","))
                    {
                        e.Handled = true;
                    }
                }
            }
            
        }

        #endregion

        #region [Обработчики событий]

        /// <summary>
        /// Фокус на текстовое поле при нажатии
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
        }
        /// <summary>
        /// Фокус на текстовое поле при активации
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
        }
        /// <summary>
        /// Отвечает за вывод и конвертацию чисел с фокусированным текстовым полем
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            if (Properties.Settings.Default.Language == "en-US")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "0.";
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            else
            {
                if (textBox.Text == ",")
                {
                    textBox.Text = "0,";
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            
            if (shouldResetOnNextInput && isContentSelected)
            {
                if (text.Length > 0 && char.IsDigit(text[0]))
                {
                    textBox.Text = text;
                    textBox.SelectionStart = text.Length;

                    shouldResetOnNextInput = false;
                    isContentSelected = false;
                }
                else
                {
                    isConverting = false;
                    shouldResetOnNextInput = false;
                    isContentSelected = false;
                    return;
                }
            }
            if (Properties.Settings.Default.Language == "en-US")
            {
                if (text.Length > 1 && text.StartsWith("0") && text[1] != '.')
                {
                    textBox.Text = text.Substring(1);
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            else
            {
                if (text.Length > 1 && text.StartsWith("0") && text[1] != ',')
                {
                    textBox.Text = text.Substring(1);
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }

            PerformConversion(textBox);
            isConverting = false;
        }
        /// <summary>
        /// Выбор пользователем конвертируемой единицы
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            if (lastFocusedTextBox == textBoxConvert1)
            {
                PerformConversion(textBoxConvert1);
            }
            else
            {
                PerformConversion(textBoxConvert2);
            }
            isConverting = false;
        }
        /// <summary>
        /// Нажатие клавиши в первом текстовом поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HandleKeyPress(e, textBox);
        }
        /// <summary>
        /// Нажатие клавиши во втором текстовом поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HandleKeyPress(e, textBox);
        }
        /// <summary>
        /// Отвечает за нажатие кнопок с цифрами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPanelButtons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            HandleButtonClick(button.Text);
        }
        /// <summary>
        /// Выход из приложения.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Открывает окно "Настройки"
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                ApplyTheme();
                ApplyBigFontSize();
                LoadLanguage();
                ApplyLabels();
                ApplyConverterdWords();
            }
        }
        /// <summary>
        /// Открывает мини-окно.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void миниокноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (smallWindow == null)
            {
                smallWindow = new SmallWindow(this);
                smallWindow.FormClosing += SmallWindow_FormClosing;
                smallWindow.Show();
                this.Hide();
            }
        }
        /// <summary>
        /// Открывает "Справку".
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void cправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reference about = new Reference();
            about.Show();
        }
        /// <summary>
        /// Закрывает мини-окно (при любом методе закрытии)
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void SmallWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            smallWindow = null;
        }
        /// <summary>
        /// Отвечает за размер кнопок при увеличении или уменьшении окна.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void Main_Resize(object sender, EventArgs e)
        {
            float fontSize = (float)(this.Height / 36.0);
            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                control.Font = new Font(control.Font.FontFamily, fontSize, control.Font.Style);
            }
        }
        /// <summary>
        /// Первоначальная загрузка окна.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = Resources.MainFormTitle;
            файлToolStripMenuItem.Text = Resources.MainFormFile;
            миниокноToolStripMenuItem.Text = Resources.MainFormMiniWindow;
            выходToolStripMenuItem.Text = Resources.MainExit;
            настройкиToolStripMenuItem.Text = Resources.SettingsFormTitle;
            справкаToolStripMenuItem.Text = Resources.MainFormReference;
            ApplyConverterdWords();
        }
        /// <summary>
        /// Нажатие кнопки на первое текстовое поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                string valueCopy = textBoxConvert1.SelectedText;
                if (double.TryParse(valueCopy, out double value))
                {
                    Clipboard.SetText(valueCopy);
                }
                else
                {
                    MessageBox.Show("Выделите только числовое значение для копирования.");
                }
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                var valueClipboard = Clipboard.GetText();

                if (double.TryParse(valueClipboard, out double value))
                {
                    textBoxConvert1.Text = "";
                    int selectionTextBox = textBoxConvert1.SelectionStart;
                    textBoxConvert1.Text = textBoxConvert1.Text.Insert(selectionTextBox, valueClipboard);
                    textBoxConvert1.SelectionStart = selectionTextBox + valueClipboard.Length;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    MessageBox.Show("Вставьте только числовое значение.");
                    e.SuppressKeyPress = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxConvert1.SelectAll();
            }
            if (e.KeyCode == Keys.F5)
            {
                миниокноToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                настройкиToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                cправкаToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                выходToolStripMenuItem_Click(sender, e);
            }
        }
        /// <summary>
        /// Нажатие кнопки на второе текстовое поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                string valueCopy = textBoxConvert2.SelectedText;
                if (double.TryParse(valueCopy, out double value))
                {
                    Clipboard.SetText(valueCopy);
                }
                else
                {
                    MessageBox.Show("Выделите только числовое значение для копирования.");
                }
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                var valueClipboard = Clipboard.GetText();

                if (double.TryParse(valueClipboard, out double value))
                {
                    textBoxConvert2.Text = "";
                    int selectionTextBox = textBoxConvert2.SelectionStart;
                    textBoxConvert2.Text = textBoxConvert2.Text.Insert(selectionTextBox, valueClipboard);
                    textBoxConvert2.SelectionStart = selectionTextBox + valueClipboard.Length;
                    e.SuppressKeyPress = true;

                }
                else
                {
                    MessageBox.Show("Вставьте только числовое значение.");
                    e.SuppressKeyPress = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxConvert2.SelectAll();
            }
            if (e.KeyCode == Keys.F5)
            {
                миниокноToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                настройкиToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                cправкаToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                выходToolStripMenuItem_Click(sender, e);
            }
        }
        /// <summary>
        /// Отображение окон при помощи функциональных клавиш.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void FunctionalKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                миниокноToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                настройкиToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                cправкаToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                выходToolStripMenuItem_Click(sender, e);
            }
        }
        private void поверхОстальныхОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = поверхОстальныхОконToolStripMenuItem.Checked;
        }
        private void buttonShowOrHidePanelButtons_Click(object sender, EventArgs e)
        {
            if (buttonShowOrHidePanelButtons.Text == "⮝")
            {
                tableLayoutPanelButtons.Visible = false;
                buttonShowOrHidePanelButtons.Text = "⮟";
                this.MinimumSize = new Size(300, 350);
                this.Size = new Size(this.Width, 350);
                panelMain.Dock = DockStyle.Fill;
            }
            else
            {
                tableLayoutPanelButtons.Visible = true;
                buttonShowOrHidePanelButtons.Text = "⮝";
                this.MinimumSize = new Size(300, 650);
                this.Size = new Size(this.Width, 650);
                panelMain.Dock = DockStyle.Top;
            }
        }
        private void checkBoxStack16_CheckedChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            if (lastFocusedTextBox == textBoxConvert1)
            {
                PerformConversion(textBoxConvert1);
            }
            else
            {
                PerformConversion(textBoxConvert2);
            }
            isConverting = false;
        }
        #endregion

        #region [Настройки приложения]

        /// <summary>
        /// Смена темы
        /// </summary>
        private void ApplyTheme()
        {
            string currentTheme = Properties.Settings.Default.IsColorForm;

            switch (currentTheme)
            {
                case "Dark":
                    SetDarkThemeColors();
                    break;
                case "Custom":
                    SetCustomThemeColors();
                    break;
                default: 
                    SetLightThemeColors();
                    break;
            }
        }

        private void SetDarkThemeColors()
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Flat;
            comboBoxConvert2.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.FromArgb(32, 34, 36);
            this.ForeColor = Color.White;
            menuStrip.BackColor = Color.FromArgb(38, 41, 43);
            menuStrip.ForeColor = Color.White;
            panelMain.BackColor = Color.FromArgb(32, 34, 36);
            panelMain.ForeColor = Color.White;
            tableLayoutPanelButtons.BackColor = Color.FromArgb(32, 34, 36);
            tableLayoutPanelButtons.ForeColor = Color.White;
            textBoxConvert1.BorderStyle = BorderStyle.None;
            textBoxConvert2.BorderStyle = BorderStyle.None;
            buttonShowOrHidePanelButtons.BaseColor = Color.FromArgb(255, 48, 51, 53);
            buttonShowOrHidePanelButtons.HoverColor = Color.FromArgb(255, 54, 59, 61);
            buttonShowOrHidePanelButtons.ClickColor = Color.FromArgb(255, 59, 62, 65);
            buttonShowOrHidePanelButtons.ForeColor = Color.White;

            foreach (CustomButton button in tableLayoutPanelButtons.Controls)
            {
                if (button is CustomButton)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = Color.FromArgb(255, 48, 51, 53);
                    button.HoverColor = Color.FromArgb(255, 54, 59, 61);
                    button.ClickColor = Color.FromArgb(255, 59, 62, 65);
                }
            }

            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = Color.FromArgb(255, 42, 45, 49);
                    control.ForeColor = Color.White;
                }
                if (control is ComboBox)
                {
                    control.BackColor = Color.FromArgb(255, 42, 45, 49);
                    control.ForeColor = Color.White;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Color.FromArgb(32, 34, 36);
                    control.ForeColor = Color.FromArgb(255, 232, 232, 232);
                }
            }
            ClearAllResults.ForeColor = Color.FromArgb(255, 143, 46, 29);
        }

        private void SetLightThemeColors()
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Standard;
            comboBoxConvert2.FlatStyle = FlatStyle.Standard;
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            menuStrip.BackColor = Color.White;
            menuStrip.ForeColor = SystemColors.ControlText;
            panelMain.BackColor = SystemColors.Control;
            panelMain.ForeColor = SystemColors.ControlText;
            tableLayoutPanelButtons.BackColor = SystemColors.Control;
            tableLayoutPanelButtons.ForeColor = SystemColors.ControlText;
            textBoxConvert1.BorderStyle = BorderStyle.Fixed3D;
            textBoxConvert2.BorderStyle = BorderStyle.Fixed3D;
            buttonShowOrHidePanelButtons.BaseColor = Color.White;
            buttonShowOrHidePanelButtons.HoverColor = Color.FromArgb(255, 231, 231, 231);
            buttonShowOrHidePanelButtons.ClickColor = Color.FromArgb(255, 225, 225, 225);
            buttonShowOrHidePanelButtons.ForeColor = Color.Black;

            foreach (CustomButton button in tableLayoutPanelButtons.Controls)
            {
                if (button is CustomButton)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = Color.White;
                    button.HoverColor = Color.FromArgb(255, 231, 231, 231);
                    button.ClickColor = Color.FromArgb(255, 225, 225, 225);
                }
            }
            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
                else if (control is ComboBox)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
            }
            ClearAllResults.ForeColor = Color.Maroon;
        }

        private void SetCustomThemeColors()
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Flat;
            comboBoxConvert2.FlatStyle = FlatStyle.Flat;
            this.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            this.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            menuStrip.BackColor = ThemeCustomization.ColorDarkerMenu(Properties.Settings.Default.ThemeCustomBackColor);
            menuStrip.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            panelMain.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            panelMain.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            tableLayoutPanelButtons.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            tableLayoutPanelButtons.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            textBoxConvert1.BorderStyle = BorderStyle.None;
            textBoxConvert2.BorderStyle = BorderStyle.None;
            buttonShowOrHidePanelButtons.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;

            foreach (CustomButton button in tableLayoutPanelButtons.Controls)
            {
                if (button is CustomButton)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
                    button.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
                    button.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
                }
            }

            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
                if (control is ComboBox)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
            }

            ClearAllResults.ForeColor = Color.FromArgb(255, 143, 46, 29);
        }

        /// <summary>
        /// Настройка шрифта
        /// </summary>
        private void ApplyBigFontSize()
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                this.Font = new Font("Microsoft Sans Serif", 12);
                foreach (Control control in panelMain.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 28);
                    }
                    if (control is ComboBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 24);
                    }
                    if (control is Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 12);
                    }
                }
            }
            else
            {
                this.Font = new Font("Microsoft Sans Serif", 8.75F);
                foreach (Control control in panelMain.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 20);
                    }
                    if (control is ComboBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 16);
                    }
                    if (control is Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 8.75F);
                    }
                }
            }
        }
        private void ApplyLabels()
        {
            this.Text = Resources.MainFormTitle;
            миниокноToolStripMenuItem.Text = Resources.MainFormMiniWindow;
            файлToolStripMenuItem.Text = Resources.MainFormFile;
            выходToolStripMenuItem.Text = Resources.MainExit;
            настройкиToolStripMenuItem.Text = Resources.SettingsFormTitle;
            справкаToolStripMenuItem.Text = Resources.MainFormReference;
            remainderLabel.Text = Resources.MainFormRemainder;
            поверхОстальныхОконToolStripMenuItem.Text = Resources.MainFormTopMost;
            checkBoxStack16.Text = Resources.MainFormStackX16;
            Comma.Text = Resources.PointDigit;
        }
        /// <summary>
        /// Загрузка языка региона
        /// </summary>
        private void LoadLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;

            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        /// <summary>
        /// Вспомогательный метод для загрузки языка
        /// </summary>
        private void ApplyConverterdWords()
        {
            comboBoxConvert1.Items.Clear();
            comboBoxConvert2.Items.Clear();
            comboBoxConvert1.Items.Add(Resources.ConverterBlock);
            comboBoxConvert1.Items.Add(Resources.ConverterStack);
            comboBoxConvert1.Items.Add(Resources.ConverterShulker);
            comboBoxConvert2.Items.Add(Resources.ConverterBlock);
            comboBoxConvert2.Items.Add(Resources.ConverterStack);
            comboBoxConvert2.Items.Add(Resources.ConverterShulker);
            comboBoxConvert1.SelectedIndex = 0;
            comboBoxConvert2.SelectedIndex = 1;
        }
        #endregion
    }
}