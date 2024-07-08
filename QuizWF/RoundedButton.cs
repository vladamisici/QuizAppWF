using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizWF
{
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 15;
        public Color BaseColor { get; set; } = Color.Blue;
        public Color HoverColor { get; set; } = Color.DarkBlue;
        public Color ClickColor { get; set; } = Color.MediumBlue;
        private Color currentColor;

        public RoundedButton()
        {
            currentColor = BaseColor;
            MouseEnter += RoundedButton_MouseEnter;
            MouseLeave += RoundedButton_MouseLeave;
            MouseDown += RoundedButton_MouseDown;
            MouseUp += RoundedButton_MouseUp;
        }

        private void RoundedButton_MouseEnter(object sender, EventArgs e)
        {
            currentColor = HoverColor;
            Invalidate();
        }

        private void RoundedButton_MouseLeave(object sender, EventArgs e)
        {
            currentColor = BaseColor;
            Invalidate();
        }

        private void RoundedButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentColor = ClickColor;
                Invalidate();
            }
        }

        private void RoundedButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentColor = HoverColor;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseAllFigures();
                Region = new Region(path);
                e.Graphics.DrawPath(Pens.Transparent, path);

                // Fill button background with the current color
                using (Brush brush = new SolidBrush(currentColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw text
                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Region = new Region(GetRoundedRectPath());
        }

        private GraphicsPath GetRoundedRectPath()
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
