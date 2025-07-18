using CFM.ConverterHelper;
using CFM.Custom;
using CFM.Properties;
using CFM.SettingsHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CFM
{
    public partial class FormMain : Form
    {
        #region ## Общие переменные ##

        private bool isConverting = false; // Режим конвертации
        public TextBox lastFocusedTextBox = null; // Последний сфокусированный TextBox
        public bool shouldResetOnNextInput = false; // Нужно ли стирать при следующем вводе
        public bool isContentSelected = false; // Выделен ли текст
        private FormSmallWindow smallWindow; // Малое окно

        #endregion

        public FormMain()
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
            if (e.KeyCode == Keys.F5)
            {
                миниокноToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                настройкиToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                cправкаToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                выходToolStripMenuItem_Click(sender, e);
            }
        }

        #endregion

        #region ## Обработчики событий панели конвертации ##

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
        /// Отвечает за вывод и конвертацию чисел с фокусированным текстовым полем
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isConverting) return;
            isConverting = true;

            TextBox textBox = (TextBox)sender;
            ConversionHelper.HandleTextBoxTextChanged(textBox, ref isConverting, ref shouldResetOnNextInput, ref isContentSelected);
            ConversionHelper.PerformConversion(this, textBox, checkBoxStack16.Checked);

            isConverting = false;
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

        #region ## Обработчики событий элементов управления на главном окне ##

        /// <summary>
        /// Переключение Стак (x16) в Стак (х64) и наоборот
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
            if (buttonShowOrHidePanelButtons.Text == "⮝")
            {
                tableLayoutPanelButtons.Visible = false;
                buttonShowOrHidePanelButtons.Text = "⮟";
                this.MinimumSize = new Size(300, 350);
                this.Size = new Size(this.Width, 350);
                panelMain.Dock = DockStyle.Fill;
            }
            else
            {
                tableLayoutPanelButtons.Visible = true;
                buttonShowOrHidePanelButtons.Text = "⮝";
                this.MinimumSize = new Size(300, 550);
                this.Size = new Size(this.Width, this.Height);
                panelMain.Dock = DockStyle.Top;
            }
        }
        /// <summary>
        /// Отображение окон при помощи функциональных клавиш.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void FunctionalKeys_KeyDown(object sender, KeyEventArgs e)
        {
            CheckFunctionalKeys(sender, e);
        }
        /// <summary>
        /// Закрывает мини-окно (при любом методе закрытии)
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void SmallWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            smallWindow = null;
        }

        #endregion

        #region ## Обработчики событий главного окна ##

        /// <summary>
        /// Первоначальная загрузка окна.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void Main_Load(object sender, EventArgs e)
        {
            textBoxConvert1.Text = "0";
            textBoxConvert2.Text = "0";

            Theme.ApplyTheme(this, panelMain, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
            BigFontSize.ApplyBigFontSize(this, panelMain);
            Language.LoadLanguage();
            ApplyLabels();

            textBoxConvert1.Font = new Font(textBoxConvert1.Font, FontStyle.Bold);

            Language.ApplyConverterdWords(comboBoxConvert1, comboBoxConvert2);
        }

        /// <summary>
        /// Отвечает за размер кнопок при увеличении или уменьшении окна.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void Main_Resize(object sender, EventArgs e)
        {
            float fontSize = (float)(this.Height / 36.0);
            foreach (Control control in tableLayoutPanelButtons.Controls)
            {
                control.Font = new Font(control.Font.FontFamily, fontSize, control.Font.Style);
            }
        }

        #endregion

        #region ## Кнопки для меню-строки ##

        /// <summary>
        /// Открывает мини-окно.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void миниокноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (smallWindow == null)
            {
                smallWindow = new FormSmallWindow(this);
                smallWindow.FormClosing += SmallWindow_FormClosing;
                smallWindow.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Переключает состояние "Поверх всех окон"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void поверхОстальныхОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = поверхОстальныхОконToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Выход из приложения.
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Открывает окно "Настройки"
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings settingsForm = new FormSettings();
            SaveLoadNumbers.SaveNumbers(textBoxConvert1.Text, comboBoxConvert1.SelectedIndex, textBoxConvert2.Text, comboBoxConvert2.SelectedIndex);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                Theme.ApplyTheme(this, panelMain, tableLayoutPanelButtons, menuStrip, comboBoxConvert1, comboBoxConvert2, textBoxConvert1, textBoxConvert2, buttonShowOrHidePanelButtons, ClearAllResults);
                BigFontSize.ApplyBigFontSize(this, panelMain);
                Language.LoadLanguage();
                ApplyLabels();
                Language.ApplyConverterdWords(comboBoxConvert1, comboBoxConvert2);
                SaveLoadNumbers.LoadNumbers(textBoxConvert1, comboBoxConvert1, textBoxConvert2, comboBoxConvert2, lastFocusedTextBox);
                SetFlag.SetTextBoxFocus(this, lastFocusedTextBox);
            }
        }

        /// <summary>
        /// Открывает "Справку".
        /// </summary>
        /// <param name="sender">Элемент управления</param>
        /// <param name="e">Действие</param>
        private void cправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReference about = new FormReference();
            about.Show();
        }

        #endregion

        #region ## Настройки приложения ##

        /// <summary>
        /// Индивидуальные строки для загрузки языка
        /// </summary>
        private void ApplyLabels()
        {
            this.Text = Resources.MainFormTitle;
            миниокноToolStripMenuItem.Text = Resources.MainFormMiniWindow;
            файлToolStripMenuItem.Text = Resources.MainFormFile;
            выходToolStripMenuItem.Text = Resources.MainExit;
            настройкиToolStripMenuItem.Text = Resources.SettingsFormTitle;
            справкаToolStripMenuItem.Text = Resources.MainFormReference;
            remainderLabel.Text = Resources.MainFormRemainder;
            поверхОстальныхОконToolStripMenuItem.Text = Resources.MainFormTopMost;
            checkBoxStack16.Text = Resources.MainFormStackX16;
            Comma.Text = Resources.PointDigit;
        }

        #endregion
    }
}