using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CFM.Custom
{
    public partial class ColorPickerControl : UserControl
    {
        private Color selectedColor = Color.Red;
        private Bitmap colorBitmap;
        public Bitmap ColorBitmap { get { return colorBitmap; } }
        public Color SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                OnSelectedColorChanged(EventArgs.Empty);
                Invalidate(); // Перерисовать элемент управления
            }
        }

        public event EventHandler SelectedColorChanged;

        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            SelectedColorChanged?.Invoke(this, e);
        }

        public ColorPickerControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ResizeRedraw = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GenerateColorBitmap();
        }

        private void GenerateColorBitmap()
        {
            if (Width <= 0 || Height <= 0) return;

            colorBitmap = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(colorBitmap))
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        
                        double hue = (double)x / Width * 300;
                                                              
                        double saturation = 1 - (double)y / Height;
                        double brightness = 1; 

                        Color color = HSBToColor(hue, saturation, brightness);
                        colorBitmap.SetPixel(x, y, color);
                    }
                }
            }
        }

        private Color HSBToColor(double hue, double saturation, double brightness)
        {
            double r = 0, g = 0, b = 0;

            if (saturation == 0)
            {
                r = g = b = brightness;
            }
            else
            {
                double h = (hue % 360) / 60;
                int i = (int)h;
                double f = h - i;
                double p = brightness * (1 - saturation);
                double q = brightness * (1 - saturation * f);
                double t = brightness * (1 - saturation * (1 - f));

                switch (i)
                {
                    case 0: r = brightness; g = t; b = p; break;
                    case 1: r = q; g = brightness; b = p; break;
                    case 2: r = p; g = brightness; b = t; break;
                    case 3: r = p; g = q; b = brightness; break;
                    case 4: r = t; g = p; b = brightness; break;
                    default: r = brightness; g = p; b = q; break;
                }
            }

            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (colorBitmap != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(colorBitmap, 0, 0, Width, Height);

                int markerSize = 10;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(Width - markerSize - 2, Height - markerSize - 2, markerSize, markerSize));
                e.Graphics.FillRectangle(new SolidBrush(SelectedColor), new Rectangle(Width - markerSize - 1, Height - markerSize - 1, markerSize - 1, markerSize - 1));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SelectColor(e.X, e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                SelectColor(e.X, e.Y);
            }
        }

        private void SelectColor(int x, int y)
        {
            if (colorBitmap != null && x >= 0 && x < Width && y >= 0 && y < Height)
            {
                SelectedColor = colorBitmap.GetPixel(x, y);
            }
        }
    }
}
