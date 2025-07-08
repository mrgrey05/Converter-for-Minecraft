using CFM.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CFM
{
    public partial class ThemeCustom : Form
    {
        private Color selectedColor;
        private Color foreColor = Color.Black;
        private Color backColor = Color.White;
        private Color[] rainbowColors = new Color[] {
            Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Cyan, Color.BlueViolet, Color.MediumVioletRed
        };
        private int trackBarMaxValue = 100;  
        private int trackBarMidValue = 50;  

        public ThemeCustom()
        {
            InitializeComponent();
            colorPanel.Paint += ColorPanel_Paint;
            colorTrackBar.ValueChanged += ColorTrackBar_ValueChanged;
            trackBarForeColor.ValueChanged += ForeColorTrackBar_ValueChanged;
            trackBarBackColor.ValueChanged += BackColorTrackBar_ValueChanged;
            colorTrackBar.Maximum = trackBarMaxValue;
            trackBarForeColor.Maximum = trackBarMaxValue;
            trackBarBackColor.Minimum = 0;    
            trackBarBackColor.Maximum = trackBarMaxValue;
            trackBarForeColor.Value = trackBarMidValue; 
            trackBarBackColor.Value = trackBarMidValue;
            foreColor = selectedColor;
            backColor = selectedColor;
            LoadLanguage();
        }

        #region Вспомогательные методы
        private Color InterpolateColors(Color color1, Color color2, float fraction)
        {
            float r = color1.R + (color2.R - color1.R) * fraction;
            float g = color1.G + (color2.G - color1.G) * fraction;
            float b = color1.B + (color2.B - color1.B) * fraction;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private Color AdjustBrightness(Color baseColor, int brightnessOffset)
        {
            float correctionFactor = brightnessOffset / (float)trackBarMidValue;

            float red = baseColor.R;
            float green = baseColor.G;
            float blue = baseColor.B;

            if (correctionFactor < 0)
            {
                red *= (1 + correctionFactor);
                green *= (1 + correctionFactor);
                blue *= (1 + correctionFactor);
            }
            else
            {
                red = red + (255 - red) * correctionFactor;
                green = green + (255 - green) * correctionFactor;
                blue = blue + (255 - blue) * correctionFactor;
            }

            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            return Color.FromArgb(baseColor.A, (int)red, (int)green, (int)blue);
        }

        private void UpdateSelectedColorDisplay()
        {
            panelForeColor.BackColor = foreColor;
            panelBackColor.BackColor = backColor;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.ThemeCustomForeColor = foreColor;
            Properties.Settings.Default.ThemeCustomBackColor = backColor;
            Properties.Settings.Default.Save();
        }
        private void LoadLanguage()
        {
            string savedLanguage = Properties.Settings.Default.Language;
            CultureInfo ci = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            this.Text = Resources.ThemeCustomChoiceColor;
            labelAppearance.Text = Resources.ThemeCustomAppearance;
            labelText.Text = Resources.ThemeCustomText;
            buttonCancel.Text = Resources.SettingsBtnCancel;
        }
        #endregion

        #region Обработчики событий
        private void ForeColorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            foreColor = AdjustBrightness(selectedColor, trackBarForeColor.Value - trackBarMidValue);
            panelForeColor.BackColor = foreColor;
        }
        private void BackColorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            backColor = AdjustBrightness(selectedColor, trackBarBackColor.Value - trackBarMidValue);
            panelBackColor.BackColor = backColor;
        }
        private void ColorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            float position = (float)colorTrackBar.Value / trackBarMaxValue;

            float colorIndexFloat = position * (rainbowColors.Length - 1);
            int colorIndex = (int)colorIndexFloat;

            float relativeX = colorIndexFloat - colorIndex;

            if (colorIndex >= 0 && colorIndex < rainbowColors.Length - 1)
            {
                selectedColor = InterpolateColors(rainbowColors[colorIndex], rainbowColors[colorIndex + 1], relativeX);
            }
            else
            {
                selectedColor = rainbowColors[rainbowColors.Length - 1];
            }

            foreColor = selectedColor;
            backColor = selectedColor;
            UpdateSelectedColorDisplay();
        }
        private void ColorPanel_Paint(object sender, PaintEventArgs e)
        {
            float colorWidth = (float)colorPanel.Width / rainbowColors.Length;

            for (int i = 0; i < rainbowColors.Length; i++)
            {
                Color startColor = rainbowColors[i];
                Color endColor = (i < rainbowColors.Length - 1) ? rainbowColors[i + 1] : rainbowColors[i];

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new PointF(i * colorWidth, 0),
                    new PointF((i + 1) * colorWidth, 0),
                    startColor,
                    endColor))
                {
                    e.Graphics.FillRectangle(brush, i * colorWidth, 0, colorWidth, colorPanel.Height);
                }
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveSettings();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void ThemeCustom_Load(object sender, EventArgs e)
        {
            float position = (float)colorTrackBar.Value / trackBarMaxValue;

            float colorIndexFloat = position * (rainbowColors.Length - 1);
            int colorIndex = (int)colorIndexFloat;

            float relativeX = colorIndexFloat - colorIndex;

            if (colorIndex >= 0 && colorIndex < rainbowColors.Length - 1)
            {
                selectedColor = InterpolateColors(rainbowColors[colorIndex], rainbowColors[colorIndex + 1], relativeX);
            }
            else
            {
                selectedColor = rainbowColors[rainbowColors.Length - 1];
            }

            foreColor = selectedColor;
            backColor = selectedColor;
            UpdateSelectedColorDisplay();
        }
        #endregion
    }
}
