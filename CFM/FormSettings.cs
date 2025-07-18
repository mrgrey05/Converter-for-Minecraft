using CFM.Properties;
using CFM.SettingsHelper;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class FormSettings : Form
    {
        #region ## Общие переменные ##

        private bool ignoreSelectedIndexChanged = false;

        #endregion

        public FormSettings()
        {
            InitializeComponent();
        }

        #region ## Вспомогательные методы ##

        /// <summary>
        /// Загрузка настроек
        /// </summary>
        private void LoadSettings()
        {
            checkBoxOtherRemainder.Checked = Settings.Default.IsOtherRemainder;
            checkBoxBigSizeFont.Checked = Settings.Default.IsBigSizeFont;
            string savedTheme = Settings.Default.IsColorForm;
            string savedLanguage = Settings.Default.Language;

            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            SetLanguageComboBox(savedLanguage);
            SetThemeComboBox(savedTheme);

            ApplyLabels();
        }

        /// <summary>
        /// Установка языка для списка, для выбора темы
        /// </summary>
        /// <param name="themeName"></param>
        private void SetThemeComboBox(string themeName)
        {
            ignoreSelectedIndexChanged = true;
            string lightThemeName = Resources.ThemeLangLight;
            string darkThemeName = Resources.ThemeLangDark;
            string customThemeName = Resources.ThemeLangCustom;
            switch (themeName)
            {
                case "Dark":
                    comboBoxTheme.SelectedIndex = 1;
                    break;
                case "Custom":
                    comboBoxTheme.SelectedIndex = 2;
                    break;
                default:
                    comboBoxTheme.SelectedIndex = 0;
                    break;
            }
            ignoreSelectedIndexChanged = false;
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        private void SaveSettings()
        {
            string selectedTheme;

            switch (comboBoxTheme.SelectedIndex)
            {
                case 1:
                    selectedTheme = "Dark";
                    break;
                case 2:
                    selectedTheme = "Custom";
                    break;
                default:
                    selectedTheme = "Light";
                    break;
            }

            Settings.Default.IsColorForm = selectedTheme;
            Settings.Default.IsBigSizeFont = checkBoxBigSizeFont.Checked;
            Settings.Default.IsOtherRemainder = checkBoxOtherRemainder.Checked;

            string selectedLanguage = comboBoxLanguage.SelectedItem.ToString();

            CultureInfo ci;
            string cultureName;
            switch (selectedLanguage)
            {
                case "English":
                    {
                        ci = new CultureInfo("en-US");
                        cultureName = "en-US";
                        break;
                    }
                case "Русский":
                    {
                        ci = new CultureInfo("ru-RU");
                        cultureName = "ru-RU";
                        break;
                    }
                case "Deutsch":
                    {
                        ci = new CultureInfo("de-DE");
                        cultureName = "de-DE";
                        break;
                    }
                case "Українська":
                    {
                        ci = new CultureInfo("uk-UA");
                        cultureName = "uk-UA";
                        break;
                    }
                default:
                    {
                        ci = CultureInfo.InvariantCulture;
                        cultureName = CultureInfo.InvariantCulture.Name;
                        break;
                    }
            }
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Properties.Settings.Default.Language = cultureName;
        }

        /// <summary>
        /// Выставляет язык региона
        /// </summary>
        /// <param name="languageCode">Язык региона</param>
        private void SetLanguageComboBox(string languageCode)
        {
            for (int i = 0; i < comboBoxLanguage.Items.Count; i++)
            {
                string itemText = comboBoxLanguage.Items[i].ToString();
                switch (languageCode)
                {
                    case "ru-RU":
                        {
                            languageCode = "Русский";
                            break;
                        }
                    case "en-US":
                        {
                            languageCode = "English";
                            break;
                        }
                    case "de-DE":
                        {
                            languageCode = "Deutsch";
                            break;
                        }
                    case "uk-UA":
                        {
                            languageCode = "Українська";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (itemText == languageCode)
                {
                    comboBoxLanguage.SelectedIndex = i;
                    break;
                }
            }
        }

        #endregion

        #region ## Обработчики событий ##

        /// <summary>
        /// Выбор темы пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreSelectedIndexChanged) return;

            if (comboBoxTheme.SelectedIndex == 2)
            {
                FormThemeCustom themeCustom = new FormThemeCustom();

                if (themeCustom.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    string lastTheme = Settings.Default.IsColorForm;
                    SetThemeComboBox(lastTheme);
                }
            }
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            Theme.ApplyThemeSettings(this, labelTheme, comboBoxTheme, panelButtons, tableLayoutPanelItems);
            ApplyThemeLang();
        }

        /// <summary>
        /// Подтверждение действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            ApplyLabels();
            Theme.ApplyThemeSettings(this, labelTheme, comboBoxTheme, panelButtons, tableLayoutPanelItems);

            this.DialogResult = DialogResult.OK;
            this.Close();

            Settings.Default.Save();
        }

        /// <summary>
        /// Отмена действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region ## Настройки приложения ##

        /// <summary>
        /// Индивидуальные строки для загрузки языка
        /// </summary>
        private void ApplyLabels()
        {
            this.Text = Resources.SettingsFormTitle;
            labelTheme.Text = Resources.SettingsLabelTheme;
            labelBigSizeFont.Text = Resources.SettingsLabelBigSizeFont;
            labelLanguage.Text = Resources.SettingsLabelLanguage;
            buttonCancel.Text = Resources.SettingsBtnCancel;
            labelOtherRemainder.Text = Resources.SettingsOtherRemainder;

            string currentLanguage = Settings.Default.Language;
            SetLanguageComboBox(currentLanguage);

        }

        /// <summary>
        /// Загрузка списка с регионом языка
        /// </summary>
        private void ApplyThemeLang()
        {
            comboBoxTheme.Items.Clear();
            comboBoxTheme.Items.Add(Resources.ThemeLangLight);
            comboBoxTheme.Items.Add(Resources.ThemeLangDark);
            comboBoxTheme.Items.Add(Resources.ThemeLangCustom);

            string savedTheme = Settings.Default.IsColorForm;
            SetThemeComboBox(savedTheme);
        }

        #endregion
    }
}
