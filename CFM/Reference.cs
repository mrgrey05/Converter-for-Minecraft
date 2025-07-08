using CFM.Custom;
using CFM.Properties;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();
            ApplyTheme();
            LoadLanguage();
            ApplyBigFontSize();
        }

        private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.gmail.com";

            try
            {
                Process.Start(url);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии браузера: {ex.Message}");
            }
        }
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
            labelMail.ForeColor = Color.White;
            labelVersion.ForeColor = Color.White;
            labelVersion2.ForeColor = Color.White;
            linkLabelMail.LinkColor = Color.FromArgb(0, 128, 132, 209);
            gInfo.ForeColor = Color.White;
        }

        private void SetLightThemeColors()
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            labelMail.ForeColor = Color.Black;
            labelVersion.ForeColor = Color.Black;
            labelVersion2.ForeColor = Color.Black;
            gInfo.ForeColor = Color.Black;
            linkLabelMail.LinkColor = SystemColors.HotTrack;
        }

        private void SetCustomThemeColors()
        {
            this.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
            this.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelMail.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelVersion.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelVersion2.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            gInfo.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            linkLabelMail.LinkColor = SystemColors.HotTrack;
        }
        /// <summary>
        /// Настройка шрифта
        /// </summary>
        private void ApplyBigFontSize()
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                this.Font = new Font("Microsoft Sans Serif", 12);
                foreach (Control control in gInfo.Controls)
                {
                    if (control is System.Windows.Forms.Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 12);
                    }
                }
            }
            else
            {
                this.Font = new Font("Microsoft Sans Serif", 8.25F);
                foreach (Control control in gInfo.Controls)
                {
                    if (control is System.Windows.Forms.Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 8.25F);
                    }
                }
            }
        }
        private void LoadLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;
            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            this.Text = Resources.ReferenceFormTitle;
            gInfo.Text = Resources.ReferenceAboutUs;
            labelMail.Text = Resources.ReferenceEmail;
            labelVersion.Text = Resources.ReferenceVersion;
            labelVersion2.Text = Properties.Settings.Default.Version; 
        }
    }
}