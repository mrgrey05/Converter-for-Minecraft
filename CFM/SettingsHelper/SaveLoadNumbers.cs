using System;
using System.Windows.Forms;

namespace CFM.SettingsHelper
{
    public static class SaveLoadNumbers
    {
        /// <summary>
        /// Сохранение чисел и конвертируемых единиц при смене настроек
        /// </summary>
        /// <param name="textBox1">Первое число</param>
        /// <param name="comboBox1">Первая конв. единица</param>
        /// <param name="textBox2">Второе число</param>
        /// <param name="comboBox2">Вторая конв. единица</param>
        public static void SaveNumbers(string textBox1, int comboBox1, string textBox2, int comboBox2)
        {
            Properties.Settings.Default.SavedTextBoxConvert1 = Convert.ToDouble(textBox1);
            Properties.Settings.Default.SavedComboBoxIndex1 = comboBox1;
            Properties.Settings.Default.SavedTextBoxConvert2 = Convert.ToDouble(textBox2);
            Properties.Settings.Default.SavedComboBoxIndex2 = comboBox2;
        }

        /// <summary>
        /// Загрузка чисел и конвертируемых единиц при смене настроек
        /// </summary>
        /// <param name="textBox1">Первое число</param>
        /// <param name="comboBox1">Первая конв. единица</param>
        /// <param name="textBox2">Второе число</param>
        /// <param name="comboBox2">Вторая конв. единица</param>
        /// <param name="lastFocusedTextBox">Последное сфокусированное поле</param>
        public static void LoadNumbers(TextBox textBox1, ComboBox comboBox1, TextBox textBox2, ComboBox comboBox2, TextBox lastFocusedTextBox)
        {
            if (lastFocusedTextBox == textBox1)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Text = Properties.Settings.Default.SavedTextBoxConvert1.ToString();
                comboBox1.SelectedIndex = Properties.Settings.Default.SavedComboBoxIndex1;
                comboBox2.SelectedIndex = Properties.Settings.Default.SavedComboBoxIndex2;
            }
            else
            {
                textBox2.Clear();
                textBox1.Clear();
                textBox2.Text = Properties.Settings.Default.SavedTextBoxConvert2.ToString();
                comboBox1.SelectedIndex = Properties.Settings.Default.SavedComboBoxIndex1;
                comboBox2.SelectedIndex = Properties.Settings.Default.SavedComboBoxIndex2;
            }
        }
    }
}
