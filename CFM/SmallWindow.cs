using CFM.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class SmallWindow : Form
    {
        private bool isConverting = false;
        private TextBox lastFocusedTextBox = null;
        private bool shouldResetOnNextInput = false;
        private bool isContentSelected = false;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public SmallWindow(Main main)
        {
            InitializeComponent();

            textBoxConvert1.Font = new Font(textBoxConvert1.Font, FontStyle.Bold);
            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";
            this.ControlBox = false;

            ApplySettings();
            ApplyBigFontSize();
            LoadLanguage();
            ApplyConverterdWords();
        }
        private void SetTextBoxFocus(TextBox textBox)
        {
            SetResetFlag(textBox);
            SetTextBoxFont(textBox);
            textBox.SelectAll();
            isContentSelected = true;
            lastFocusedTextBox = textBox;
        }
        private void SetResetFlag(TextBox textBox)
        {
            if (lastFocusedTextBox != null && lastFocusedTextBox != textBox)
            {
                shouldResetOnNextInput = true;
            }
            lastFocusedTextBox = textBox;
        }
        private void SetTextBoxFont(TextBox textBox)
        {
            textBoxConvert1.Font = (textBox == textBoxConvert1) ? new Font(textBoxConvert1.Font, FontStyle.Bold) : new Font(textBoxConvert1.Font, FontStyle.Regular);
            textBoxConvert2.Font = (textBox == textBoxConvert2) ? new Font(textBoxConvert2.Font, FontStyle.Bold) : new Font(textBoxConvert2.Font, FontStyle.Regular);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;


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
            if (text.Length > 1 && text.StartsWith("0") && text[1] != ',')
            {
                textBox.Text = text.Substring(1);
                textBox.SelectionStart = textBox.Text.Length;
            }
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }

            PerformConversion(textBox);
            isConverting = false;
        }
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
                double convertedValue = Converter.ConvertValue(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString());
                string remainder = Converter.GetRemainder(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString());
                string otherTextBoxName = (textBox == textBoxConvert1) ? textBoxConvert2.Name : textBoxConvert1.Name;
                TextBox otherTextBox = (TextBox)this.Controls.Find(otherTextBoxName, true)[0];
                otherTextBox.Text = convertedValue.ToString();
                remainderLabel.Text = $"{Resources.MainFormRemainder}: {remainder}";
            }
            catch (ArgumentException ex)
            {
                Debug.Fail(ex.Message);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void HandleKeyPress(KeyPressEventArgs e, TextBox textBox)
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
        /// #######################################################
        /// #######################################################
        ///           Обработчики элементов управления
        /// #######################################################
        /// #######################################################
        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
        }
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
        private void textBoxConvert1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HandleKeyPress(e, textBox);
        }
        private void textBoxConvert2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HandleKeyPress(e, textBox);
        }
        private void ButtonPanelButtons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            HandleButtonClick(button.Text);
        }
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
        private void Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
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
        }
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
        }
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                // Вычисление новой позиции окна
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        /// #######################################################
        /// #######################################################
        ///                Настройки приложения
        /// #######################################################
        /// #######################################################
        private void ApplySettings()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Flat;
                comboBoxConvert2.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.FromArgb(32, 34, 36);
                this.ForeColor = Color.White;
                panelLeft.BackColor = Color.FromArgb(32, 34, 36);
                panelLeft.ForeColor = Color.White;
                tableLayoutPanelButtons.BackColor = Color.FromArgb(32, 34, 36);
                tableLayoutPanelButtons.ForeColor = Color.White;
                textBoxConvert1.BorderStyle = BorderStyle.None;
                textBoxConvert2.BorderStyle = BorderStyle.None;

                ClearAllResults.FlatStyle = FlatStyle.Standard;
                ClearAllResults.BaseColor = Color.FromArgb(255, 48, 51, 53);
                ClearAllResults.HoverColor = Color.FromArgb(255, 54, 59, 61);
                ClearAllResults.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Nine.FlatStyle = FlatStyle.Standard;
                Nine.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Nine.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Nine.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Eight.FlatStyle = FlatStyle.Standard;
                Eight.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Eight.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Eight.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Seven.FlatStyle = FlatStyle.Standard;
                Seven.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Seven.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Seven.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Six.FlatStyle = FlatStyle.Standard;
                Six.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Six.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Six.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Five.FlatStyle = FlatStyle.Standard;
                Five.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Five.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Five.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Four.FlatStyle = FlatStyle.Standard;
                Four.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Four.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Four.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Three.FlatStyle = FlatStyle.Standard;
                Three.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Three.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Three.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Two.FlatStyle = FlatStyle.Standard;
                Two.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Two.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Two.ClickColor = Color.FromArgb(255, 59, 62, 65);

                One.FlatStyle = FlatStyle.Standard;
                One.BaseColor = Color.FromArgb(255, 48, 51, 53);
                One.HoverColor = Color.FromArgb(255, 54, 59, 61);
                One.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Zero.FlatStyle = FlatStyle.Standard;
                Zero.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Zero.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Zero.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Comma.FlatStyle = FlatStyle.Standard;
                Comma.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Comma.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Comma.ClickColor = Color.FromArgb(255, 59, 62, 65);

                Clear.FlatStyle = FlatStyle.Standard;
                Clear.BaseColor = Color.FromArgb(255, 48, 51, 53);
                Clear.HoverColor = Color.FromArgb(255, 54, 59, 61);
                Clear.ClickColor = Color.FromArgb(255, 59, 62, 65);

                foreach (Control control in panelLeft.Controls)
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
                        control.ForeColor = Color.White;
                    }
                }
                menuStrip.BackColor = Color.FromArgb(38, 41, 43);
                вернутьсяToolStripMenuItem.ForeColor = Color.White;

                ClearAllResults.ForeColor = Color.FromArgb(255, 143, 46, 29);
            }
            else
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Standard;
                comboBoxConvert2.FlatStyle = FlatStyle.Standard;
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                panelLeft.BackColor = SystemColors.Control;
                panelLeft.ForeColor = SystemColors.ControlText;
                tableLayoutPanelButtons.BackColor = SystemColors.Control;
                tableLayoutPanelButtons.ForeColor = SystemColors.ControlText;
                textBoxConvert1.BorderStyle = BorderStyle.Fixed3D;
                textBoxConvert2.BorderStyle = BorderStyle.Fixed3D;

                ClearAllResults.FlatStyle = FlatStyle.Standard;
                ClearAllResults.BaseColor = Color.White;
                ClearAllResults.HoverColor = Color.FromArgb(255, 231, 231, 231);
                ClearAllResults.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Nine.FlatStyle = FlatStyle.Standard;
                Nine.BaseColor = Color.White;
                Nine.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Nine.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Eight.FlatStyle = FlatStyle.Standard;
                Eight.BaseColor = Color.White;
                Eight.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Eight.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Seven.FlatStyle = FlatStyle.Standard;
                Seven.BaseColor = Color.White;
                Seven.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Seven.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Six.FlatStyle = FlatStyle.Standard;
                Six.BaseColor = Color.White;
                Six.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Six.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Five.FlatStyle = FlatStyle.Standard;
                Five.BaseColor = Color.White;
                Five.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Five.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Four.FlatStyle = FlatStyle.Standard;
                Four.BaseColor = Color.White;
                Four.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Four.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Three.FlatStyle = FlatStyle.Standard;
                Three.BaseColor = Color.White;
                Three.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Three.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Two.FlatStyle = FlatStyle.Standard;
                Two.BaseColor = Color.White;
                Two.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Two.ClickColor = Color.FromArgb(255, 225, 225, 225);

                One.FlatStyle = FlatStyle.Standard;
                One.BaseColor = Color.White;
                One.HoverColor = Color.FromArgb(255, 231, 231, 231);
                One.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Zero.FlatStyle = FlatStyle.Standard;
                Zero.BaseColor = Color.White;
                Zero.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Zero.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Comma.FlatStyle = FlatStyle.Standard;
                Comma.BaseColor = Color.White;
                Comma.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Comma.ClickColor = Color.FromArgb(255, 225, 225, 225);

                Clear.FlatStyle = FlatStyle.Standard;
                Clear.BaseColor = Color.White;
                Clear.HoverColor = Color.FromArgb(255, 231, 231, 231);
                Clear.ClickColor = Color.FromArgb(255, 225, 225, 225);

                foreach (Control control in panelLeft.Controls)
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
                menuStrip.BackColor = Color.White;
                вернутьсяToolStripMenuItem.ForeColor = Color.Black;

                ClearAllResults.ForeColor = Color.Maroon;
            }
        }
        private void ApplyBigFontSize()
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                this.Font = new Font("Microsoft Sans Serif", 12);
            }
            else
            {
                this.Font = new Font("Microsoft Sans Serif", 8.25F);
            }
        }
        private void LoadLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;
            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            вернутьсяToolStripMenuItem.Text = Resources.SmallWindowBack;
        }
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
    }
}
