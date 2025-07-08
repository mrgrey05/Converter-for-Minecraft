using CFM.Custom;
using CFM.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class Settings : Form
    {
        #region [Общие переменные]

        private const string ThemeLight = "ThemeLangLight"; 
        private const string ThemeDark = "ThemeLangDark";   
        private const string ThemeCustom = "ThemeLangCustom";
        private bool ignoreSelectedIndexChanged = false;

        #endregion

        public Settings()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка настроек
        /// </summary>
        private void LoadSettings()
        {
            checkBoxOtherRemainder.Checked = Properties.Settings.Default.IsOtherRemainder;
            checkBoxBigSizeFont.Checked = Properties.Settings.Default.IsBigSizeFont;
            string savedTheme = Properties.Settings.Default.IsColorForm;
            string savedLanguage = Properties.Settings.Default.Language;

            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            SetLanguageComboBox(savedLanguage);
            SetThemeComboBox(savedTheme);

            ApplyLabels();
        }

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

            Properties.Settings.Default.IsColorForm = selectedTheme;  
            Properties.Settings.Default.IsBigSizeFont = checkBoxBigSizeFont.Checked;
            Properties.Settings.Default.IsOtherRemainder = checkBoxOtherRemainder.Checked;

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


        #region [Обработчики событий]

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ApplyTheme();
            ApplyBigFontSize();
            ApplyThemeLang();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            ApplyLabels();
            ApplyTheme();
            ApplyBigFontSize();
            this.DialogResult = DialogResult.OK;
            this.Close();

            Properties.Settings.Default.Save();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Настройки приложения

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
            this.BackColor = Color.FromArgb(32, 34, 36);
            this.ForeColor = Color.White;
            labelTheme.ForeColor = Color.White;
            comboBoxTheme.BackColor = Color.FromArgb(32, 34, 36);
            comboBoxTheme.ForeColor = Color.White;
            panelButtons.BackColor = Color.FromArgb(32, 34, 36);
            tableLayoutPanelItems.BackColor = Color.FromArgb(32, 34, 36);

            foreach (CustomButton control in panelButtons.Controls)
            {
                control.BackColor = Color.FromArgb(32, 34, 36);
                control.ForeColor = Color.White;
                control.BaseColor = Color.FromArgb(255, 48, 51, 53);
                control.HoverColor = Color.FromArgb(255, 54, 59, 61);
                control.ClickColor = Color.FromArgb(255, 59, 62, 65);
            }
        }

        private void SetLightThemeColors()
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            labelTheme.ForeColor = SystemColors.ControlText;
            comboBoxTheme.BackColor = SystemColors.Control;
            comboBoxTheme.ForeColor = Color.Black;
            buttonOK.BackColor = SystemColors.Control;
            buttonOK.ForeColor = SystemColors.ControlText;
            buttonCancel.BackColor = SystemColors.Control;
            buttonCancel.ForeColor = SystemColors.ControlText;
        }
        private void SetCustomThemeColors()
        {
            this.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            this.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            labelTheme.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            comboBoxTheme.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            comboBoxTheme.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            panelButtons.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            tableLayoutPanelItems.BackColor = Properties.Settings.Default.ThemeCustomBackColor;

            foreach (CustomButton control in panelButtons.Controls)
            {
                control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                control.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
                control.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
                control.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
            }
        }

        private void ApplyBigFontSize()
        {
            Font newFont = Properties.Settings.Default.IsBigSizeFont ? new Font("Microsoft Sans Serif", 12) : new Font("Microsoft Sans Serif", 8.25F);

            ApplyFontRecursive(this, newFont);
        }
        private void ApplyFontRecursive(Control parent, Font font)
        {
            parent.Font = font;
            foreach (Control control in parent.Controls)
            {
                ApplyFontRecursive(control, font);
            }
        }
        private void ApplyLabels()
        {
            this.Text = Resources.SettingsFormTitle;
            labelTheme.Text = Resources.SettingsLabelTheme;
            labelBigSizeFont.Text = Resources.SettingsLabelBigSizeFont;
            labelLanguage.Text = Resources.SettingsLabelLanguage;
            buttonCancel.Text = Resources.SettingsBtnCancel;
            labelOtherRemainder.Text = Resources.SettingsOtherRemainder;

            string currentLanguage = Properties.Settings.Default.Language;
            SetLanguageComboBox(currentLanguage);

        }
        private void ApplyThemeLang()
        {
            comboBoxTheme.Items.Clear();
            comboBoxTheme.Items.Add(Resources.ThemeLangLight);
            comboBoxTheme.Items.Add(Resources.ThemeLangDark);
            comboBoxTheme.Items.Add(Resources.ThemeLangCustom);

            string savedTheme = Properties.Settings.Default.IsColorForm;
            SetThemeComboBox(savedTheme);
        }

        #endregion

        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreSelectedIndexChanged) return;

            if (comboBoxTheme.SelectedIndex == 2)
            {
                ThemeCustom themeCustom = new ThemeCustom();

                if (themeCustom.ShowDialog() == DialogResult.OK)
                {
                    
                }
                else
                {
                    string lastTheme = Properties.Settings.Default.IsColorForm;
                    SetThemeComboBox(lastTheme);
                }
            }
        }  
    }
}
