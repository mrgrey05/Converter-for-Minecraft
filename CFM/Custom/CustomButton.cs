using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CFM.Custom
{
    public class CustomButton : Button
    {
        private Color _baseColor = Color.White;
        private Color _hoverColor = Color.FromArgb(255, 231, 231, 231);
        private Color _clickColor = Color.FromArgb(255, 225, 225, 225);
        private bool _isPressed = false;
        private int _cornerRadius = 5;
        private Timer _hoverTimer;
        private bool _isMouseOver = false;

        public CustomButton()
        {
            this.Size = new Size(150, 40);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 3;
            this.FlatAppearance.MouseDownBackColor = Color.White;
            this.FlatAppearance.MouseOverBackColor = Color.White;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint |
                       ControlStyles.AllPaintingInWmPaint |
                       ControlStyles.DoubleBuffer, true);  
            BackColor = Color.White;
            ForeColor = Color.Black;

            _hoverTimer = new Timer();
            _hoverTimer.Interval = 500; 
            _hoverTimer.Tick += HoverTimer_Tick;
            _hoverTimer.Stop(); 
        }

        public Color BaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                Invalidate();
            }
        }
        public Color HoverColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
                Invalidate();
            }
        }
        public Color ClickColor
        {
            get { return _clickColor; }
            set
            {
                _clickColor = value;
                Invalidate();
            }
        }
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            _hoverTimer.Stop();
            if (!_isMouseOver) 
            {
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; // высокое качество

            pevent.Graphics.Clear(this.Parent.BackColor);

            GraphicsPath path = GetRoundRectangle(this.ClientRectangle, _cornerRadius);

            this.Region = new Region(path);
            Color drawColor = _baseColor;
            if (_isPressed)
            {
                drawColor = _clickColor;
            }
            else if (_isMouseOver)
            {
                drawColor = _hoverColor;
            }
            else
            {
                drawColor = _baseColor;
            }
            using (SolidBrush brush = new SolidBrush(drawColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, stringFormat);
            }
            path.Dispose();
        }
        private GraphicsPath GetRoundRectangle(Rectangle bounds, int radius)
        {
            Rectangle boundsAdjusted = new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2);
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(boundsAdjusted.Location, size);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arc, 180, 90);
            arc.X = boundsAdjusted.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = boundsAdjusted.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = boundsAdjusted.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isMouseOver = true;
            _hoverTimer.Stop(); 
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isMouseOver = false;
            _hoverTimer.Start();
            base.OnMouseLeave(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_hoverTimer != null)
                {
                    _hoverTimer.Dispose();
                    _hoverTimer = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
