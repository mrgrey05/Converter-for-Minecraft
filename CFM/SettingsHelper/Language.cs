using CFM.Properties;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CFM.SettingsHelper
{
    public static class Language
    {
        /// <summary>
        /// Загрузка языка региона
        /// </summary>
        public static void LoadLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;

            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        /// <summary>
        /// Вспомогательный метод для загрузки языка, для списков
        /// </summary>
        public static void ApplyConverterdWords(ComboBox comboBox1, ComboBox comboBox2)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Add(Resources.ConverterBlock);
            comboBox1.Items.Add(Resources.ConverterStack);
            comboBox1.Items.Add(Resources.ConverterShulker);
            comboBox2.Items.Add(Resources.ConverterBlock);
            comboBox2.Items.Add(Resources.ConverterStack);
            comboBox2.Items.Add(Resources.ConverterShulker);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }
    }
}
