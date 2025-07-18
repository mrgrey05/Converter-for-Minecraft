using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CFM.Custom
{
    public partial class ColorShadeSlider : UserControl
    {
        private Color baseColor = Color.Red;
        private int shadeValue = 50;

        public event EventHandler ShadeValueChanged;

        public Color BaseColor
        {
            get { return baseColor; }
            set
            {
                baseColor = value;
                Invalidate();
            }
        }

        public int ShadeValue
        {
            get { return shadeValue; }
            set
            {
                shadeValue = Math.Max(0, Math.Min(100, value));
                OnShadeValueChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        protected virtual void OnShadeValueChanged(EventArgs e)
        {
            ShadeValueChanged?.Invoke(this, e);
        }

        public ColorShadeSlider()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle clientRect = ClientRectangle;

            LinearGradientBrush brush = new LinearGradientBrush(
                clientRect,
                Color.Black, 
                BaseColor,  
                LinearGradientMode.Horizontal);

            g.FillRectangle(brush, clientRect);
            brush.Dispose();

            int sliderPosition = (int)((float)ShadeValue / 100 * clientRect.Width);
            int sliderWidth = 6;
            int sliderHeight = clientRect.Height;
            Rectangle sliderRect = new Rectangle(sliderPosition - sliderWidth / 2, 0, sliderWidth, sliderHeight);

            g.FillRectangle(Brushes.White, sliderRect);
            g.DrawRectangle(Pens.Black, sliderRect);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            UpdateShadeValue(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                UpdateShadeValue(e.X);
            }
        }

        private void UpdateShadeValue(int mouseX)
        {
            ShadeValue = (int)((float)mouseX / Width * 100);
        }

        public Color GetShadeColor()
        {
            float ratio = (float)shadeValue / 100;
            return BlendColors(Color.Black, BaseColor, ratio);
        }

        private Color BlendColors(Color color1, Color color2, float ratio)
        {
            int r = (int)(color1.R * (1 - ratio) + color2.R * ratio);
            int g = (int)(color1.G * (1 - ratio) + color2.G * ratio);
            int b = (int)(color1.B * (1 - ratio) + color2.B * ratio);

            return Color.FromArgb(r, g, b);
        }
    }
}
