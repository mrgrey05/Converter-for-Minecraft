using System.Drawing;
using System.Windows.Forms;

namespace CFM.ConverterHelper
{
    public static class SetFlag
    {
        /// <summary>
        /// Ставит фокус на текстовое поле
        /// </summary>
        /// <param name="form">Окно</param>
        /// <param name="textBox">Текстовое поле</param>
        public static void SetTextBoxFocus(Form form, TextBox textBox)
        {
            SetResetFlag(form, textBox);
            SetTextBoxFont(form, textBox);
            textBox.SelectAll();

            // Устанавливаем флаги в зависимости от типа формы
            if (form is FormMain)
            {
                FormMain mainForm = (FormMain)form;
                mainForm.isContentSelected = true;
                mainForm.lastFocusedTextBox = textBox;
            }
            else if (form is FormSmallWindow)
            {
                FormSmallWindow smallWindowForm = (FormSmallWindow)form;
                smallWindowForm.isContentSelected = true;
                smallWindowForm.lastFocusedTextBox = textBox;
            }
        }

        /// <summary>
        /// Назначение переменной TextBox после последней фокусировки поля 
        /// </summary>
        /// <param name="form">Окно</param>
        /// <param name="textBox">Текстовое поле</param>
        private static void SetResetFlag(Form form, TextBox textBox)
        {
            TextBox lastFocusedTextBox = null;

            if (form is FormMain)
            {
                lastFocusedTextBox = ((FormMain)form).lastFocusedTextBox;
            }
            else if (form is FormSmallWindow)
            {
                lastFocusedTextBox = ((FormSmallWindow)form).lastFocusedTextBox;
            }

            if (lastFocusedTextBox != null && lastFocusedTextBox != textBox)
            {
                if (form is FormMain)
                {
                    ((FormMain)form).shouldResetOnNextInput = true;
                }
                else if (form is FormSmallWindow)
                {
                    ((FormSmallWindow)form).shouldResetOnNextInput = true;
                }
            }

            if (form is FormMain)
            {
                ((FormMain)form).lastFocusedTextBox = textBox;
            }
            else if (form is FormSmallWindow)
            {
                ((FormSmallWindow)form).lastFocusedTextBox = textBox;
            }
        }

        /// <summary>
        /// Делает текст жирным при фокусировке конкретного текстового поля
        /// </summary>
        /// <param name="form">Окно</param>
        /// <param name="textBox">Текстовое поле</param>
        private static void SetTextBoxFont(Form form, TextBox textBox)
        {
            TextBox textBoxConvert1 = null;
            TextBox textBoxConvert2 = null;

            if (form is FormMain)
            {
                FormMain mainForm = (FormMain)form;
                textBoxConvert1 = mainForm.textBoxConvert1;
                textBoxConvert2 = mainForm.textBoxConvert2;

                mainForm.textBoxConvert1.Font = (textBox == textBoxConvert1) ? new Font(textBoxConvert1.Font, FontStyle.Bold) : new Font(textBoxConvert1.Font, FontStyle.Regular);
                mainForm.textBoxConvert2.Font = (textBox == textBoxConvert2) ? new Font(textBoxConvert2.Font, FontStyle.Bold) : new Font(textBoxConvert2.Font, FontStyle.Regular);
            }
            else if (form is FormSmallWindow)
            {
                FormSmallWindow smallWindowForm = (FormSmallWindow)form;
                textBoxConvert1 = smallWindowForm.textBoxConvert1;
                textBoxConvert2 = smallWindowForm.textBoxConvert2;

                smallWindowForm.textBoxConvert1.Font = (textBox == textBoxConvert1) ? new Font(textBoxConvert1.Font, FontStyle.Bold) : new Font(textBoxConvert1.Font, FontStyle.Regular);
                smallWindowForm.textBoxConvert2.Font = (textBox == textBoxConvert2) ? new Font(textBoxConvert2.Font, FontStyle.Bold) : new Font(textBoxConvert2.Font, FontStyle.Regular);
            }
        }
    }
}
