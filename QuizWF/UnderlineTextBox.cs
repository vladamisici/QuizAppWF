using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuizWF
{
    public class UnderlineTextBox : TextBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2))
            {
                int y = this.ClientSize.Height - 1;
                e.Graphics.DrawLine(pen, 0, y, this.ClientSize.Width, y);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    using (Pen pen = new Pen(Color.Gray, 2))
                    {
                        int y = this.ClientSize.Height - 1;
                        g.DrawLine(pen, 0, y, this.ClientSize.Width, y);
                    }
                }
            }
        }
    }
}
