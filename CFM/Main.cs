
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace CFM
{
    public partial class Main : Form
    {
        private bool isConverting = false; 
        private TextBox lastFocusedTextBox = null; 
        private bool shouldResetOnNextInput = false; 
        private bool isContentSelected = false;
        private SmallWindow smallWindow;
        public Main()
        {
            Debug.WriteLine("Main(): Конструктор формы");
            InitializeComponent();
            comboBoxConvert1.SelectedIndex = 0;
            comboBoxConvert2.SelectedIndex = 1;

            textBoxConvert1.TextChanged += TextBox_TextChanged;
            textBoxConvert2.TextChanged += TextBox_TextChanged;
            comboBoxConvert1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBoxConvert2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            textBoxConvert1.Enter += TextBox_Enter;
            textBoxConvert2.Enter += TextBox_Enter;
            textBoxConvert1.MouseUp += TextBox_MouseUp;
            textBoxConvert2.MouseUp += TextBox_MouseUp;

            textBoxConvert1.Font = new Font(textBoxConvert1.Font, FontStyle.Bold);

            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";

            ApplySettings();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.Width = 300;
            this.Height = 550;
        }

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            SetTextBoxFocus((TextBox)sender);
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
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            PerformConversion(textBoxConvert1);
            PerformConversion(textBoxConvert2);
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
                remainderLabel.Text = $"Остаток: {remainder}";
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
                case "CE":
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
        private void ApplySettings()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Flat;
                comboBoxConvert2.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.ForeColor = Color.White;
                menuStrip.BackColor = Color.FromArgb(73, 73, 73);
                menuStrip.ForeColor = Color.White;
                panel1.BackColor = Color.FromArgb(64, 64, 64);
                panel1.ForeColor = Color.White;
                tableLayoutPanelButtons.BackColor = Color.FromArgb(64, 64, 64);
                tableLayoutPanelButtons.ForeColor = Color.White;
                ClearAllResults.FlatStyle = FlatStyle.Flat;
                Clear.FlatStyle = FlatStyle.Flat;
                Nine.FlatStyle = FlatStyle.Flat;
                Eight.FlatStyle = FlatStyle.Flat;
                Seven.FlatStyle = FlatStyle.Flat;
                Six.FlatStyle = FlatStyle.Flat;
                Five.FlatStyle = FlatStyle.Flat;
                Four.FlatStyle = FlatStyle.Flat;
                Three.FlatStyle = FlatStyle.Flat;
                Two.FlatStyle = FlatStyle.Flat;
                One.FlatStyle = FlatStyle.Flat;
                Zero.FlatStyle = FlatStyle.Flat;
                Comma.FlatStyle = FlatStyle.Flat;

                foreach (Control control in panel1.Controls)
                {
                    if (control is TextBox)
                    {
                        control.BackColor = Color.FromArgb(64, 64, 64);
                        control.ForeColor = Color.White;
                    }
                    if (control is ComboBox)
                    {
                        control.BackColor = Color.FromArgb(64, 64, 64);
                        control.ForeColor = Color.White;
                    }
                }

                foreach (Control control in tableLayoutPanelButtons.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = Color.FromArgb(64, 64, 64);
                        control.ForeColor = Color.White;
                    }
                }

                ClearAllResults.ForeColor = Color.FromArgb(212, 73, 49);
            }
            else
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Standard;
                comboBoxConvert2.FlatStyle = FlatStyle.Standard;
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                menuStrip.BackColor = SystemColors.Control;
                menuStrip.ForeColor = SystemColors.ControlText;
                panel1.BackColor = SystemColors.Control;
                panel1.ForeColor = SystemColors.ControlText;
                tableLayoutPanelButtons.BackColor = SystemColors.Control;
                tableLayoutPanelButtons.ForeColor = SystemColors.ControlText;
                ClearAllResults.FlatStyle = FlatStyle.Standard;
                Clear.FlatStyle = FlatStyle.Standard;
                Nine.FlatStyle = FlatStyle.Standard;
                Eight.FlatStyle = FlatStyle.Standard;
                Seven.FlatStyle = FlatStyle.Standard;
                Six.FlatStyle = FlatStyle.Standard;
                Five.FlatStyle = FlatStyle.Standard;
                Four.FlatStyle = FlatStyle.Standard;
                Three.FlatStyle = FlatStyle.Standard;
                Two.FlatStyle = FlatStyle.Standard;
                One.FlatStyle = FlatStyle.Standard;
                Zero.FlatStyle = FlatStyle.Standard;
                Comma.FlatStyle = FlatStyle.Standard;

                foreach (Control control in panel1.Controls)
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
                ClearAllResults.ForeColor = Color.FromArgb(186, 30, 2);
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                ApplySettings();
            }
        }
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

        private void cправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
        private void SmallWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            smallWindow = null;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            float fontSize = (float)(this.Height / 32.0);
            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                control.Font = new Font(control.Font.FontFamily, fontSize, control.Font.Style);
            }
        }
    }
}
