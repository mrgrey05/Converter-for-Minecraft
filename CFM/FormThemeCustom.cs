using CFM.Custom;
using CFM.Properties;
using CFM.SettingsHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CFM
{
    public partial class FormThemeCustom : Form
    {
        #region ## Общие переменные ##

        private Color backColor;
        private Color foreColor;
        private Point selectedColorPickerPosition;
        private bool isMouseDown = false;

        #endregion

        public FormThemeCustom()
        {
            InitializeComponent();
        }

        #region ## Вспомогательные методы ##

        /// <summary>
        /// Обновление цвета элементов управления
        /// </summary>
        /// <param name="shadeColor">Цвет</param>
        private void UpdateElementsColor(Color shadeColor)
        {
            cButton.BackColor = ThemeCustomization.ColorDarker(shadeColor);
            cButton.BaseColor = ThemeCustomization.ColorDarkerBase(shadeColor);
            cButton.HoverColor = ThemeCustomization.ColorDarkerHover(shadeColor);
            cButton.ClickColor = ThemeCustomization.ColorDarkerClick(shadeColor);

            lText.BackColor = shadeColor;

            string hexColor = ColorTranslator.ToHtml(shadeColor);
            labelColorHash.Text = hexColor;

            if (colorShadeSlider.ShadeValue >= 80)
            {
                cButton.ForeColor = Color.Black;
                lText.ForeColor = Color.Black;
                foreColor = Color.Black;
            }
            else
            {
                cButton.ForeColor = Color.White;
                lText.ForeColor = Color.White;
                foreColor = Color.White;
            }
        }

        /// <summary>
        /// Загрузка настроек пользовательской темы
        /// </summary>
        private void LoadSettings()
        {
            backColor = Properties.Settings.Default.ThemeCustomBackColor;
            foreColor = Properties.Settings.Default.ThemeCustomForeColor;
            selectedColorPickerPosition = Properties.Settings.Default.ColorPickerPosition; 

            if (selectedColorPickerPosition != Point.Empty && colorPickerControl.ColorBitmap != null &&
                selectedColorPickerPosition.X >= 0 && selectedColorPickerPosition.X < colorPickerControl.Width &&
                selectedColorPickerPosition.Y >= 0 && selectedColorPickerPosition.Y < colorPickerControl.Height)
            {
                colorPickerControl.SelectedColor = colorPickerControl.ColorBitmap.GetPixel(selectedColorPickerPosition.X, selectedColorPickerPosition.Y);
            }
            else
            {
                colorPickerControl.SelectedColor = backColor; 
            }
        }

        /// <summary>
        /// Сохранение настроек цвета
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.ThemeCustomBackColor = backColor;
            Properties.Settings.Default.ThemeCustomForeColor = foreColor;
            Properties.Settings.Default.ColorPickerPosition = selectedColorPickerPosition; 
            Properties.Settings.Default.Save();
        }

        #endregion

        #region ## Обработчики событий окна ##

        /// <summary>
        /// Подтверджение действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if ((colorShadeSlider.ShadeValue >= 45 && colorShadeSlider.ShadeValue <= 65) || colorShadeSlider.ShadeValue >= 92)
            {
                DialogResult result = MessageBox.Show(
                    "Этот цвет может быть сложным при прочтении.\nДля сохранения читабельности выберите другой оттенок",
                    "Предупреждение!",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation
                );

                if (result == DialogResult.OK)
                {
                    SaveSettings();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                SaveSettings();
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Отмена действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Загрузка окна и настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemeCustom_Load(object sender, EventArgs e)
        {
            this.Text = Resources.ThemeCustomFormText;
            cButton.Text = Resources.ThemeCustomButtonText;
            lText.Text = Resources.ThemeCustomText;
            buttonCancel.Text = Resources.SettingsBtnCancel;

            Language.LoadLanguage();
            LoadSettings();
        }

        /// <summary>
        /// Нажатие на строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelColorHash_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelColorHash.Text);
            labelColorHash.Text = "Код цвета скопирован!";
            timer.Start();
        }

        /// <summary>
        /// Таймер для отображения хэш-кода цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            UpdateElementsColor(colorShadeSlider.GetShadeColor());
        }

        #endregion

        #region ## Обработчики событий для выбора цвета ##

        /// <summary>
        /// Выбор цвета мышью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPicker_SelectedColorChanged(object sender, EventArgs e)
        {
            colorShadeSlider.BaseColor = colorPickerControl.SelectedColor;

            UpdateElementsColor(colorShadeSlider.GetShadeColor());
            backColor = colorShadeSlider.GetShadeColor();

        }

        /// <summary>
        /// Передвижение мышью ползунка тёмных оттенков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorShadeSlider_ShadeValueChanged(object sender, EventArgs e)
        {
            UpdateElementsColor(colorShadeSlider.GetShadeColor());
            backColor = colorShadeSlider.GetShadeColor();
        }

        /// <summary>
        /// Отвечает за нажатие мышью и выбор цвета на элементе ColorPickerControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPickerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
            {
                selectedColorPickerPosition = new Point(e.X, e.Y);
                isMouseDown = true;
            }
        }

        /// <summary>
        /// Отвечает за отжатие мышью и выбор цвета на элементе ColorPickerControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorPickerControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                selectedColorPickerPosition = new Point(e.X, e.Y);
                isMouseDown = false;
            }
        }

        #endregion
    }
}
