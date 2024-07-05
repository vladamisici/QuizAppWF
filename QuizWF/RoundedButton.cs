using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizWF
{
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 15;

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
                e.Graphics.DrawPath(Pens.Gray, path);
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
