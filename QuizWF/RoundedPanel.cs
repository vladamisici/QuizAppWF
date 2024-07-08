using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizWF
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 15;
        public Color BorderColor { get; set; } = Color.LightGray;
        public int BorderWidth { get; set; } = 1;

        public RoundedPanel()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.BackColor = SystemColors.Control;
            this.BorderStyle = BorderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Clear the background with the panel's back color
            e.Graphics.Clear(this.BackColor);

            // Draw inner white rectangle with rounded corners
            e.Graphics.FillRoundedRectangle(new SolidBrush(Color.White), 0, 0, this.Width - 1, this.Height - 1, CornerRadius);

            // Draw border
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                e.Graphics.DrawRoundedRectangle(pen, 0, 0, this.Width - 1, this.Height - 1, CornerRadius);
            }
        }
    }
}
