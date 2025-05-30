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
        }

        private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.gmail.com";

            try
            {
                Process.Start(url); //  Process.Start() автоматически определит браузер по умолчанию
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии браузера: {ex.Message}");
            }
        }
        private void ApplyTheme()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                this.BackColor = Color.FromArgb(32, 34, 36);
                this.ForeColor = Color.White;
                labelMail.ForeColor = Color.White;
                labelVersion.ForeColor = Color.White;
                labelVersion2.ForeColor = Color.White;
                linkLabelMail.LinkColor = Color.FromArgb(0, 128, 132, 209);
                gInfo.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                labelMail.ForeColor = Color.Black;
                labelVersion.ForeColor = Color.Black;
                labelVersion2.ForeColor = Color.Black;
                gInfo.ForeColor = Color.Black;
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
            if (savedLanguage == "en-US")
            {
                labelMail.Location = new Point(27, 44);
                labelVersion.Location = new Point(45, 66);
            }
            else 
            {
                labelMail.Location = new Point(53, 44);
                labelVersion.Location = new Point(35, 66);
            }
            labelMail.Text = Resources.ReferenceEmail;
            labelVersion.Text = Resources.ReferenceVersion;

        }
    }
}
