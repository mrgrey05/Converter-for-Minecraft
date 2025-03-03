using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace CFM
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            ApplyTheme();
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
                this.BackColor = Color.FromArgb(64, 64, 64);
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
    }
}
