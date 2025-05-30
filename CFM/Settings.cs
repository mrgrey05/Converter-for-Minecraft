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
        public Settings()
        {
            InitializeComponent();
        }
        private void LoadSettings()
        {
            comboBoxTheme.SelectedIndex = Properties.Settings.Default.IsDarkTheme ? 1 : 0;
            checkBoxBigSizeFont.Checked = Properties.Settings.Default.IsBigSizeFont;
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.IsDarkTheme = (comboBoxTheme.SelectedIndex == 1);
            Properties.Settings.Default.IsBigSizeFont = checkBoxBigSizeFont.Checked;

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
        private void LoadSavedLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;

            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            SetLanguageComboBox(savedLanguage);

            ApplyLabels();
        }
        /// #######################################################
        /// #######################################################
        ///           Обработчики элементов управления
        /// #######################################################
        /// #######################################################
        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ApplyTheme();
            ApplyBigFontSize();
            LoadSavedLanguage();
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
            Application.Restart();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// #######################################################
        /// #######################################################
        ///                Настройки приложения
        /// #######################################################
        /// #######################################################
        private void ApplyTheme()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                this.BackColor = Color.FromArgb(32, 34, 36);
                this.ForeColor = Color.White;
                labelTheme.ForeColor = Color.White;
                tabPagesMain.BackColor = Color.FromArgb(32, 34, 36);
                comboBoxTheme.BackColor = Color.FromArgb(32, 34, 36);
                comboBoxTheme.ForeColor = Color.White;

                buttonOK.BackColor = Color.FromArgb(32, 34, 36);
                buttonOK.ForeColor = Color.White;
                buttonOK.BaseColor = Color.FromArgb(255, 48, 51, 53);
                buttonOK.HoverColor = Color.FromArgb(255, 54, 59, 61);
                buttonOK.ClickColor = Color.FromArgb(255, 59, 62, 65);

                buttonCancel.BackColor = Color.FromArgb(32, 34, 36);
                buttonCancel.ForeColor = Color.White;
                buttonCancel.BaseColor = Color.FromArgb(255, 48, 51, 53);
                buttonCancel.HoverColor = Color.FromArgb(255, 54, 59, 61);
                buttonCancel.ClickColor = Color.FromArgb(255, 59, 62, 65);

                groupBoxCustomization.ForeColor = Color.White;
                groupBoxOther.ForeColor = Color.White;
            }
            else
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
            tabPagesMain.Text = Resources.SettingsTabMain;
            groupBoxCustomization.Text = Resources.SettingsLabelDesign;
            labelTheme.Text = Resources.SettingsLabelTheme;

            string currentLanguage = Properties.Settings.Default.Language;
            SetLanguageComboBox(currentLanguage);

            if (CultureInfo.CurrentCulture.Name == "en-US")
            {
                labelTheme.Location = new Point(56, labelTheme.Location.Y);
                labelBigSizeFont.Location = new Point(53, labelBigSizeFont.Location.Y);
                labelLanguage.Location = new Point(78, labelLanguage.Location.Y);
            }
            else
            {
                labelTheme.Location = new Point(32, labelTheme.Location.Y);
                labelBigSizeFont.Location = new Point(19, labelBigSizeFont.Location.Y);
                labelLanguage.Location = new Point(96, labelLanguage.Location.Y);
            }
            labelBigSizeFont.Text = Resources.SettingsLabelBigSizeFont;
            groupBoxOther.Text = Resources.SettingsLabelOther;
            labelLanguage.Text = Resources.SettingsLabelLanguage;
            buttonCancel.Text = Resources.SettingsBtnCancel;
        }
        private void ApplyThemeLang()
        {
            comboBoxTheme.Items.Clear();
            comboBoxTheme.Items.Add(Resources.ThemeLangLight);
            comboBoxTheme.Items.Add(Resources.ThemeLangDark);
            if (Properties.Settings.Default.IsDarkTheme)
            {
                comboBoxTheme.SelectedIndex = 1;
            }
            else
            {
                comboBoxTheme.SelectedIndex = 0;
            }
        }
    }
}
