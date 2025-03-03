using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFM
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                comboBoxTheme.SelectedIndex = 1; 
            }
            else
            {
                comboBoxTheme.SelectedIndex = 0; 
            }
            ApplyTheme();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsDarkTheme = (comboBoxTheme.SelectedIndex == 1);
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void ApplyTheme()
        {
            if (Properties.Settings.Default.IsDarkTheme)
            {
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                tabPage1.BackColor = Color.FromArgb(64, 64, 64);
                comboBoxTheme.BackColor = Color.FromArgb(64, 64, 64);
                comboBoxTheme.ForeColor = Color.Black;
                buttonOK.BackColor = Color.FromArgb(64, 64, 64);
                buttonOK.ForeColor = Color.White;
                buttonCancel.BackColor = Color.FromArgb(64, 64, 64);
                buttonCancel.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                label1.ForeColor = SystemColors.ControlText;
                comboBoxTheme.BackColor = SystemColors.Window;
                comboBoxTheme.ForeColor = SystemColors.ControlText;
                buttonOK.BackColor = SystemColors.Control;
                buttonOK.ForeColor = SystemColors.ControlText;
                buttonCancel.BackColor = SystemColors.Control;
                buttonCancel.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
