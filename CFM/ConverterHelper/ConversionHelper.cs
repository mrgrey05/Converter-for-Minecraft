using CFM.Properties;
using System;
using System.Windows.Forms;

namespace CFM.ConverterHelper
{
    public static class ConversionHelper
    {
        /// <summary>
        /// Общий метод конвертации
        /// </summary>
        /// <param name="form">Окно</param>
        /// <param name="textBox">Текстовое поле</param>
        /// <param name="checkBoxStack16Checked">Элемент CheckBox</param>
        public static void PerformConversion(Form form, TextBox textBox, bool checkBoxStack16Checked)
        {
            ComboBox fromComboBox = null;
            ComboBox toComboBox = null;
            TextBox otherTextBox = null;
            Label remainderLabel = null;

            if (form is FormMain)
            {
                FormMain mainForm = (FormMain)form;
                fromComboBox = (textBox == mainForm.textBoxConvert1) ? mainForm.comboBoxConvert1 : mainForm.comboBoxConvert2;
                toComboBox = (textBox == mainForm.textBoxConvert1) ? mainForm.comboBoxConvert2 : mainForm.comboBoxConvert1;
                otherTextBox = (textBox == mainForm.textBoxConvert1) ? mainForm.textBoxConvert2 : mainForm.textBoxConvert1;
                remainderLabel = mainForm.remainderLabel;
            }
            else if (form is FormSmallWindow)
            {
                FormSmallWindow smallWindowForm = (FormSmallWindow)form;
                fromComboBox = (textBox == smallWindowForm.textBoxConvert1) ? smallWindowForm.comboBoxConvert1 : smallWindowForm.comboBoxConvert2;
                toComboBox = (textBox == smallWindowForm.textBoxConvert1) ? smallWindowForm.comboBoxConvert2 : smallWindowForm.comboBoxConvert1;
                otherTextBox = (textBox == smallWindowForm.textBoxConvert1) ? smallWindowForm.textBoxConvert2 : smallWindowForm.textBoxConvert1;
                remainderLabel = smallWindowForm.remainderLabel;
            }
            else
            {
                MessageBox.Show("Неподдерживаемый тип формы.");
                return;
            }

            if (fromComboBox == null || toComboBox == null || otherTextBox == null || remainderLabel == null)
            {
                MessageBox.Show("Не удалось определить элементы управления.  Убедитесь, что все необходимые элементы присутствуют на форме.");
                return;
            }

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
                double convertedValue = Converter.ConvertValue(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString(), checkBoxStack16Checked);
                string remainder = Converter.GetRemainder(value, fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString(), checkBoxStack16Checked, Properties.Settings.Default.IsOtherRemainder);
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
        /// Обработка нажатий кнопок цифр и плавающей запятой
        /// </summary>
        /// <param name="buttonText">Цифра</param>
        /// <param name="lastFocusedTextBox">Последнее сфокусированное текст. поле</param>
        /// <param name="shouldResetOnNextInput">Булевое значение, необходимое для сброса при следующем вводе</param>
        /// <param name="isContentSelected">Булевое значение, необходимо для понимания, выделено ли число</param>
        public static void HandleButtonClick(string buttonText, TextBox lastFocusedTextBox, ref bool shouldResetOnNextInput, ref bool isContentSelected)
        {
            if (lastFocusedTextBox == null)
            {
                return;
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
        /// <param name="e"></param>
        /// <param name="textBox">Текстовое поле</param>
        public static void HandleKeyPress(KeyPressEventArgs e, TextBox textBox)
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

        /// <summary>
        /// Отмечает за нажатие функциональных клавиш на сфокусированном поле
        /// </summary>
        /// <param name="e"></param>
        /// <param name="textBox">Текстовое поле</param>
        public static void HandleTextBoxKeyDown(KeyEventArgs e, TextBox textBox)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                string valueCopy = textBox.SelectedText;
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
                    textBox.Text = "";
                    int selectionTextBox = textBox.SelectionStart;
                    textBox.Text = textBox.Text.Insert(selectionTextBox, valueClipboard);
                    textBox.SelectionStart = selectionTextBox + valueClipboard.Length;
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
                textBox.SelectAll();
            }
        }

        /// <summary>
        /// Отвечает за ввод плавающей запятой в разных региональных настройках
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        /// <param name="isConverting">Момент конвертации</param>
        /// <param name="shouldResetOnNextInput">Булевое значение, необходимое для сброса при следующем вводе</param>
        /// <param name="isContentSelected">Булевое значение, необходимо для понимания, выделено ли число</param>
        public static void HandleTextBoxTextChanged(TextBox textBox, ref bool isConverting, ref bool shouldResetOnNextInput, ref bool isContentSelected)
        {
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
                    isConverting = false;
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
        }
    }
}

