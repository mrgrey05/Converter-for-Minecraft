using CFM.Custom;
using System.Drawing;
using System.Windows.Forms;

namespace CFM.SettingsHelper
{
    public static class Theme
    {
        #region Выбор темы в главном окне и мини-окне

        public static void ApplyTheme(Form form, Panel panelLeft, TableLayoutPanel tableLayoutPanelButtons, MenuStrip menuStrip, ComboBox comboBoxConvert1, ComboBox comboBoxConvert2, TextBox textBoxConvert1, TextBox textBoxConvert2, CustomButton buttonShowOrHidePanelButtons, CustomButton ClearAllResults)
        {
            string currentTheme = Properties.Settings.Default.IsColorForm;

            switch (currentTheme)
            {
                case "Dark":
                    SetDarkThemeColors(form, panelLeft, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
                    break;
                case "Custom":
                    SetCustomThemeColors(form, panelLeft, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
                    break;
                default:
                    SetLightThemeColors(form, panelLeft, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
                    break;
            }
        }
        private static void SetDarkThemeColors(Form form, Panel panelLeft, TableLayoutPanel tableLayoutPanelButtons, MenuStrip menuStrip, ComboBox comboBoxConvert1, ComboBox comboBoxConvert2, TextBox textBoxConvert1, TextBox textBoxConvert2, CustomButton buttonShowOrHidePanelButtons, CustomButton ClearAllResults)
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Flat;
            comboBoxConvert2.FlatStyle = FlatStyle.Flat;
            form.BackColor = Color.FromArgb(32, 34, 36);
            form.ForeColor = Color.White;
            menuStrip.BackColor = Color.FromArgb(38, 41, 43);
            menuStrip.ForeColor = Color.White;
            panelLeft.BackColor = Color.FromArgb(32, 34, 36);
            panelLeft.ForeColor = Color.White;
            tableLayoutPanelButtons.BackColor = Color.FromArgb(32, 34, 36);
            tableLayoutPanelButtons.ForeColor = Color.White;
            textBoxConvert1.BorderStyle = BorderStyle.None;
            textBoxConvert2.BorderStyle = BorderStyle.None;
            buttonShowOrHidePanelButtons.BaseColor = Color.FromArgb(255, 48, 51, 53);
            buttonShowOrHidePanelButtons.HoverColor = Color.FromArgb(255, 54, 59, 61);
            buttonShowOrHidePanelButtons.ClickColor = Color.FromArgb(255, 59, 62, 65);
            buttonShowOrHidePanelButtons.ForeColor = Color.White;

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is CustomButton button)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = Color.FromArgb(255, 48, 51, 53);
                    button.HoverColor = Color.FromArgb(255, 54, 59, 61);
                    button.ClickColor = Color.FromArgb(255, 59, 62, 65);
                }
            }

            foreach (Control control in panelLeft.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = Color.FromArgb(255, 42, 45, 49);
                    control.ForeColor = Color.White;
                }
                if (control is ComboBox)
                {
                    control.BackColor = Color.FromArgb(255, 42, 45, 49);
                    control.ForeColor = Color.White;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Color.FromArgb(32, 34, 36);
                    control.ForeColor = Color.White;
                }
            }
            ClearAllResults.ForeColor = Color.FromArgb(255, 143, 46, 29);
        }

        private static void SetLightThemeColors(Form form, Panel panelLeft, TableLayoutPanel tableLayoutPanelButtons, MenuStrip menuStrip, ComboBox comboBoxConvert1, ComboBox comboBoxConvert2, TextBox textBoxConvert1, TextBox textBoxConvert2, CustomButton buttonShowOrHidePanelButtons, CustomButton ClearAllResults)
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Standard;
            comboBoxConvert2.FlatStyle = FlatStyle.Standard;
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;
            menuStrip.BackColor = Color.White;
            menuStrip.ForeColor = SystemColors.ControlText;
            panelLeft.BackColor = SystemColors.Control;
            panelLeft.ForeColor = SystemColors.ControlText;
            tableLayoutPanelButtons.BackColor = SystemColors.Control;
            tableLayoutPanelButtons.ForeColor = SystemColors.ControlText;
            textBoxConvert1.BorderStyle = BorderStyle.Fixed3D;
            textBoxConvert2.BorderStyle = BorderStyle.Fixed3D;
            buttonShowOrHidePanelButtons.BaseColor = Color.White;
            buttonShowOrHidePanelButtons.HoverColor = Color.FromArgb(255, 231, 231, 231);
            buttonShowOrHidePanelButtons.ClickColor = Color.FromArgb(255, 225, 225, 225);
            buttonShowOrHidePanelButtons.ForeColor = Color.Black;

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is CustomButton button)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = Color.White;
                    button.HoverColor = Color.FromArgb(255, 231, 231, 231);
                    button.ClickColor = Color.FromArgb(255, 225, 225, 225);
                }
            }

            foreach (Control control in panelLeft.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
                else if (control is ComboBox)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                }
            }
            ClearAllResults.ForeColor = Color.Maroon;
        }

        private static void SetCustomThemeColors(Form form, Panel panelLeft, TableLayoutPanel tableLayoutPanelButtons, MenuStrip menuStrip, ComboBox comboBoxConvert1, ComboBox comboBoxConvert2, TextBox textBoxConvert1, TextBox textBoxConvert2, CustomButton buttonShowOrHidePanelButtons, CustomButton ClearAllResults)
        {
            comboBoxConvert1.FlatStyle = FlatStyle.Flat;
            comboBoxConvert2.FlatStyle = FlatStyle.Flat;
            form.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            form.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            menuStrip.BackColor = ThemeCustomization.ColorDarkerMenu(Properties.Settings.Default.ThemeCustomBackColor);
            menuStrip.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            panelLeft.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            panelLeft.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            tableLayoutPanelButtons.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            tableLayoutPanelButtons.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            textBoxConvert1.BorderStyle = BorderStyle.None;
            textBoxConvert2.BorderStyle = BorderStyle.None;
            buttonShowOrHidePanelButtons.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
            buttonShowOrHidePanelButtons.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is CustomButton button)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
                    button.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
                    button.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
                }
            }

            foreach (Control control in panelLeft.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
                if (control is ComboBox)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
            }

            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    control.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                }
            }

            ClearAllResults.ForeColor = Color.FromArgb(255, 143, 46, 29);
        }

        #endregion

        #region Выбор темы в "Справке"

        public static void ApplyThemeReference(FormReference form, Label labelMail, Label labelVersion, Label labelVersion2, GroupBox gInfo, LinkLabel linkLabelMail)
        {
            string currentTheme = Properties.Settings.Default.IsColorForm;

            switch (currentTheme)
            {
                case "Dark":
                    SetDarkThemeColorsReference(form, labelMail, labelVersion, labelVersion2, gInfo, linkLabelMail);
                    break;
                case "Custom":
                    SetCustomThemeColorsReference(form, labelMail, labelVersion, labelVersion2, gInfo, linkLabelMail);
                    break;
                default:
                    SetLightThemeColorsReference(form, labelMail, labelVersion, labelVersion2, gInfo, linkLabelMail);
                    break;
            }
        }

        private static void SetDarkThemeColorsReference(FormReference form, Label labelMail, Label labelVersion, Label labelVersion2, GroupBox gInfo, LinkLabel linkLabelMail)
        {
            form.BackColor = Color.FromArgb(32, 34, 36);
            form.ForeColor = Color.White;
            labelMail.ForeColor = Color.White;
            labelVersion.ForeColor = Color.White;
            labelVersion2.ForeColor = Color.White;
            linkLabelMail.LinkColor = Color.FromArgb(0, 128, 132, 209);
            gInfo.ForeColor = Color.White;
        }

        private static void SetLightThemeColorsReference(FormReference form, Label labelMail, Label labelVersion, Label labelVersion2, GroupBox gInfo, LinkLabel linkLabelMail)
        {
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;
            labelMail.ForeColor = Color.Black;
            labelVersion.ForeColor = Color.Black;
            labelVersion2.ForeColor = Color.Black;
            gInfo.ForeColor = Color.Black;
            linkLabelMail.LinkColor = SystemColors.HotTrack;
        }

        private static void SetCustomThemeColorsReference(FormReference form, Label labelMail, Label labelVersion, Label labelVersion2, GroupBox gInfo, LinkLabel linkLabelMail)
        {
            form.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
            form.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelMail.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelVersion.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            labelVersion2.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            gInfo.ForeColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomForeColor);
            linkLabelMail.LinkColor = SystemColors.HotTrack;
        }

        #endregion

        #region Выбор темы в "Настройках"

        public static void ApplyThemeSettings(FormSettings form, Label labelTheme, ComboBox comboBoxTheme, Panel panelButtons, TableLayoutPanel tableLayoutPanelItems)
        {
            string currentTheme = Properties.Settings.Default.IsColorForm;

            switch (currentTheme)
            {
                case "Dark":
                    SetDarkThemeColorsSettings(form, labelTheme, comboBoxTheme, panelButtons, tableLayoutPanelItems);
                    break;
                case "Custom":
                    SetCustomThemeColorsSettings(form, labelTheme, comboBoxTheme, panelButtons, tableLayoutPanelItems);
                    break;
                default:
                    SetLightThemeColorsSettings(form, labelTheme, comboBoxTheme, panelButtons, tableLayoutPanelItems);
                    break;
            }
        }

        private static void SetDarkThemeColorsSettings(FormSettings form, Label labelTheme, ComboBox comboBoxTheme, Panel panelButtons, TableLayoutPanel tableLayoutPanelItems)
        {
            form.BackColor = Color.FromArgb(32, 34, 36);
            form.ForeColor = Color.White;
            labelTheme.ForeColor = Color.White;
            comboBoxTheme.BackColor = Color.FromArgb(32, 34, 36);
            comboBoxTheme.ForeColor = Color.White;
            panelButtons.BackColor = Color.FromArgb(32, 34, 36);
            tableLayoutPanelItems.BackColor = Color.FromArgb(32, 34, 36);

            foreach (Control control in panelButtons.Controls)
            {
                if (control is CustomButton button)
                {
                    button.BackColor = Color.FromArgb(32, 34, 36);
                    button.ForeColor = Color.White;
                    button.BaseColor = Color.FromArgb(255, 48, 51, 53);
                    button.HoverColor = Color.FromArgb(255, 54, 59, 61);
                    button.ClickColor = Color.FromArgb(255, 59, 62, 65);
                }
            }
        }

        private static void SetLightThemeColorsSettings(FormSettings form, Label labelTheme, ComboBox comboBoxTheme, Panel panelButtons, TableLayoutPanel tableLayoutPanelItems)
        {
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;
            labelTheme.ForeColor = SystemColors.ControlText;
            comboBoxTheme.BackColor = SystemColors.Control;
            comboBoxTheme.ForeColor = Color.Black;
        }

        private static void SetCustomThemeColorsSettings(FormSettings form, Label labelTheme, ComboBox comboBoxTheme, Panel panelButtons, TableLayoutPanel tableLayoutPanelItems)
        {
            form.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            form.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            labelTheme.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            comboBoxTheme.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            comboBoxTheme.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
            panelButtons.BackColor = Properties.Settings.Default.ThemeCustomBackColor;
            tableLayoutPanelItems.BackColor = Properties.Settings.Default.ThemeCustomBackColor;

            foreach (Control control in panelButtons.Controls)
            {
                if (control is CustomButton button)
                {
                    button.BackColor = ThemeCustomization.ColorDarker(Properties.Settings.Default.ThemeCustomBackColor);
                    button.ForeColor = Properties.Settings.Default.ThemeCustomForeColor;
                    button.BaseColor = ThemeCustomization.ColorDarkerBase(Properties.Settings.Default.ThemeCustomBackColor);
                    button.HoverColor = ThemeCustomization.ColorDarkerHover(Properties.Settings.Default.ThemeCustomBackColor);
                    button.ClickColor = ThemeCustomization.ColorDarkerClick(Properties.Settings.Default.ThemeCustomBackColor);
                }
            }
        }

        #endregion
    }
}
