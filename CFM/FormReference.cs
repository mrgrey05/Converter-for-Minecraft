using CFM.Custom;
using CFM.Properties;
using CFM.SettingsHelper;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CFM
{
    public partial class FormReference : Form
    {
        public FormReference()
        {
            InitializeComponent();
        }

        #region ## Обработчики событий элементов управления ##

        /// <summary>
        /// Нажатие по строке-ссылке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Загрузка окна и настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormReference_Load(object sender, System.EventArgs e)
        {
            Theme.ApplyThemeReference(this, labelMail, labelVersion, labelVersion2, gInfo, linkLabelMail);
            Language.LoadLanguage();
            ApplyLabels();
            BigFontSize.ApplyBigFontSize(this, gInfo);
        }

        #endregion

        #region ## Настройки приложения ##

        /// <summary>
        /// Индивидуальные строки для загрузки языка
        /// </summary>
        private void ApplyLabels()
        {
            this.Text = Resources.MainFormReference;
            gInfo.Text = Resources.ReferenceAboutUs;
            labelMail.Text = Resources.ReferenceEmail;
            labelVersion.Text = Resources.ReferenceVersion;
            labelVersion2.Text = Properties.Settings.Default.Version;
        }

        #endregion
        
    }
}
