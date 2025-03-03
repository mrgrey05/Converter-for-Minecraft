using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFM
{
    public partial class SmallWindow : Form
    {
        private bool isConverting = false;
        private TextBox lastFocusedTextBox = null;
        private bool shouldResetOnNextInput = false;
        private bool isContentSelected = false;
        private Main main;
        private Point _offset;
        public SmallWindow(Main main)
        {
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
            this.main = main;
            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";
            this.ControlBox = false;

            ApplySettings();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                _offset = new Point(e.X, e.Y);
                this.Capture = true; // Захватываем мышь
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.Capture)
            {
                Point newLocation = this.Location;
                newLocation.Offset(e.X - _offset.X, e.Y - _offset.Y);
                this.Location = newLocation;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false; // Отпускаем мышь
            }
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

        private void Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ApplySettings()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Flat;
                comboBoxConvert2.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.ForeColor = Color.White;
                panelLeft.BackColor = Color.FromArgb(64, 64, 64);
                panelLeft.ForeColor = Color.White;
                panelTop.BackColor = Color.FromArgb(64, 64, 64);
                panelTop.ForeColor = Color.White;
                tableLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
                tableLayoutPanel1.ForeColor = Color.White;
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

                foreach (Control control in panelLeft.Controls)
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

                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = Color.FromArgb(64, 64, 64);
                        control.ForeColor = Color.White;
                    }
                }
                Back.ForeColor = Color.Black;
                ClearAllResults.ForeColor = Color.FromArgb(212, 73, 49);
            }
            else
            {
                comboBoxConvert1.FlatStyle = FlatStyle.Standard;
                comboBoxConvert2.FlatStyle = FlatStyle.Standard;
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                panelLeft.BackColor = SystemColors.Control;
                panelLeft.ForeColor = SystemColors.ControlText;
                panelTop.BackColor = SystemColors.Control;
                panelTop.ForeColor = SystemColors.ControlText;
                tableLayoutPanel1.BackColor = SystemColors.Control;
                tableLayoutPanel1.ForeColor = SystemColors.ControlText;
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

                foreach (Control control in tableLayoutPanel1.Controls)
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
    }
}
