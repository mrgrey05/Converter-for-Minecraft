using System.Drawing;
using System.Windows.Forms;

namespace CFM.SettingsHelper
{
    public static class BigFontSize
    {
        /// <summary>
        /// Настройка шрифта (Главное окно)
        /// </summary>
        /// <param name="main">Главное окно</param>
        /// <param name="panel">Панель с полями и списками</param>
        public static void ApplyBigFontSize(FormMain main, Panel panel)
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                main.Font = new Font("Microsoft Sans Serif", 12);
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 28);
                    }
                    if (control is ComboBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 20);
                    }
                    if (control is Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 12);
                    }
                }
            }
            else
            {
                main.Font = new Font("Microsoft Sans Serif", 8.25F);
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 20);
                    }
                    if (control is ComboBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 16);
                    }
                    if (control is Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 8.25F);
                    }
                }
            }
        }

        /// <summary>
        /// Настройка шрифта (Маленькое окно)
        /// </summary>
        /// <param name="smallwindow">Маленькое окно</param>
        /// <param name="panel">Панель с полями и списками</param>
        public static void ApplyBigFontSize(FormSmallWindow smallwindow, Panel panel)
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                smallwindow.Font = new Font("Microsoft Sans Serif", 12);
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 28);
                    }
                    if (control is ComboBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 20);
                    }
                    if (control is Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 12);
                    }
                }
            }
            else
            {
                smallwindow.Font = new Font("Microsoft Sans Serif", 8.25F);
                foreach (Control control in smallwindow.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 20);
                    }
                }
            }
        }

        /// <summary>
        /// Настройка шрифта (Справка)
        /// </summary>
        /// <param name="reference">Окно справки</param>
        /// <param name="groupBox">Элемент управления GroupBox</param>
        public static void ApplyBigFontSize(FormReference reference, GroupBox groupBox)
        {
            if (Properties.Settings.Default.IsBigSizeFont)
            {
                reference.Font = new Font("Microsoft Sans Serif", 12);
                foreach (Control control in groupBox.Controls)
                {
                    if (control is System.Windows.Forms.Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 12);
                    }
                }
            }
            else
            {
                reference.Font = new Font("Microsoft Sans Serif", 8.25F);
                foreach (Control control in groupBox.Controls)
                {
                    if (control is System.Windows.Forms.Label)
                    {
                        control.Font = new Font("Microsoft Sans Serif", 8.25F);
                    }
                }
            }
        }

        /// <summary>
        /// Настройка шрифта (Настройки)
        /// </summary>
        /// <param name="settings">Окно настроек</param>
        public static void ApplyBigFontSize(FormSettings settings)
        {
            Font newFont = Properties.Settings.Default.IsBigSizeFont ? new Font("Microsoft Sans Serif", 12) : new Font("Microsoft Sans Serif", 8.25F);

            ApplyFontRecursive(settings, newFont);
        }
        public static void ApplyFontRecursive(Control parent, Font font)
        {
            parent.Font = font;
            foreach (Control control in parent.Controls)
            {
                ApplyFontRecursive(control, font);
            }
        }
    }
}
