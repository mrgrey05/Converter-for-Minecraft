using CFM.ConverterHelper;
using CFM.Custom;
using CFM.Properties;
using CFM.SettingsHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CFM
{
    public partial class FormSmallWindow : Form
    {
        #region ## Общие переменные ##

        private bool isConverting = false; // Режим конвертации
        public TextBox lastFocusedTextBox = null; // Последний сфокусированный TextBox
        public bool shouldResetOnNextInput = false; // Нужно ли стирать при следующем вводе
        public bool isContentSelected = false; // Выделен ли текст
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        #endregion

        public FormSmallWindow(FormMain main)
        {
            InitializeComponent();
        }

        #region ## Вспомогательные обработчики событий ##

        /// <summary>
        /// Проверка на нажатие функциональных клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckFunctionalKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Back_Click(sender, e);
            }
        }

        #endregion

        #region ## Обработчики событий панели конвертации ##

        /// <summary>
        /// Отвечает за вывод и конвертацию чисел с фокусированным текстовым полем
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            TextBox textBox = (TextBox)sender;
            ConversionHelper.HandleTextBoxTextChanged(this, textBox, isConverting, shouldResetOnNextInput, isContentSelected, checkBoxStack16.Checked);

            isConverting = false;
        }

        /// <summary>
        /// Фокус на текстовое поле при нажатии
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            SetFlag.SetTextBoxFocus(this, (TextBox)sender);
        }

        /// <summary>
        /// Фокус на текстовое поле при активации
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            SetFlag.SetTextBoxFocus(this, (TextBox)sender);
        }

        /// <summary>
        /// Выбор пользователем конвертируемой единицы
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            if (lastFocusedTextBox == textBoxConvert1)
            {
                ConversionHelper.PerformConversion(this, textBoxConvert1, checkBoxStack16.Checked);
            }
            else
            {
                ConversionHelper.PerformConversion(this, textBoxConvert2, checkBoxStack16.Checked);
            }
            isConverting = false;
        }

        /// <summary>
        /// Нажатие клавиши в первом текстовом поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ConversionHelper.HandleKeyPress(e, textBox);
        }

        /// <summary>
        /// Нажатие клавиши во втором текстовом поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ConversionHelper.HandleKeyPress(e, textBox);
        }

        /// <summary>
        /// Отвечает за нажатие кнопок с цифрами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPanelButtons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ConversionHelper.HandleButtonClick(button.Text, lastFocusedTextBox, ref shouldResetOnNextInput, ref isContentSelected);
        }

        /// <summary>
        /// Нажатие кнопки на первое текстовое поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert1_KeyDown(object sender, KeyEventArgs e)
        {
            ConversionHelper.HandleTextBoxKeyDown(e, (TextBox)sender);
            CheckFunctionalKeys(sender, e);
        }

        /// <summary>
        /// Нажатие кнопки на второе текстовое поле
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void textBoxConvert2_KeyDown(object sender, KeyEventArgs e)
        {
            ConversionHelper.HandleTextBoxKeyDown(e, (TextBox)sender);
            CheckFunctionalKeys(sender, e);
        }

        #endregion

        #region ## Обработчики событий элементов управления на мини-окне ##

        /// <summary>
        /// Проверка состояния элемента "Стак (x16)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxStack16_CheckedChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            if (lastFocusedTextBox == textBoxConvert1)
            {
                ConversionHelper.PerformConversion(this, textBoxConvert1, checkBoxStack16.Checked);
            }
            else
            {
                ConversionHelper.PerformConversion(this, textBoxConvert2, checkBoxStack16.Checked);
            }
            isConverting = false;
        }

        /// <summary>
        /// Скрытие и показ клавиш цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowOrHidePanelButtons_Click(object sender, EventArgs e)
        {
            if (buttonShowOrHidePanelButtons.Text == "⮜")
            {
                tableLayoutPanelButtons.Visible = false;
                buttonShowOrHidePanelButtons.Text = "⮞";
                tableLayoutPanelMain.ColumnStyles[0].Width = 100F;
                tableLayoutPanelMain.ColumnStyles[1].Width = 0F;
                this.MinimumSize = new Size(250, 270);
                this.Size = new Size(250, 270);
            }
            else
            {
                tableLayoutPanelButtons.Visible = true;
                buttonShowOrHidePanelButtons.Text = "⮜";
                this.MinimumSize = new Size(400, 270);
                this.Size = new Size(400, 270);
                tableLayoutPanelMain.ColumnStyles[0].Width = 50F;
                tableLayoutPanelMain.ColumnStyles[1].Width = 50F;
            }
        }

        /// <summary>
        /// Нажатие функциональной клавиши 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionalKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Back_Click(sender, e);
            }
        }

        /// <summary>
        /// Возвращает в главное окно программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region ## Обработчики событий мини-окна ##

        /// <summary>
        /// Загрузка мини-окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallWindow_Load(object sender, EventArgs e)
        {
            textBoxConvert1.Font = new Font(textBoxConvert1.Font, FontStyle.Bold);
            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";
            this.ControlBox = false;

            Theme.ApplyTheme(this, panelLeft, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
            BigFontSize.ApplyBigFontSize(this, panelLeft);
            Language.LoadLanguage();
            Language.ApplyConverterdWords(comboBoxConvert1, comboBoxConvert2);
            ApplyLabels();

        }

        #endregion

        #region ## Обработчики событий, отвечающие за передвижение окна мышью ##

        /// <summary>
        /// Активирует режим перетаскивания окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        /// <summary>
        /// Переносит окно согласно расположению мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                // Вычисление новой позиции окна
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        /// <summary>
        /// Фиксирует положение окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        #region ## Настройки приложения ##

        /// <summary>
        /// Индивидуальные строки для загрузки языка
        /// </summary>
        private void ApplyLabels()
        {
            вернутьсяToolStripMenuItem.Text = Resources.SmallWindowBack;
            Comma.Text = Resources.PointDigit;
        }

        #endregion
    }
}
