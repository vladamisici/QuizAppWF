using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizWF
{
    public partial class ResultsForm : RoundedForm
    {
        private int totalPoints;
        private string username;
        private const int MaxConfettiParticles = 100;

        public ResultsForm(string username, int totalPoints)
        {
            this.username = username;
            this.totalPoints = totalPoints;
            InitializeComponent();
            confettiParticles = new List<ConfettiParticle>();
            random = new Random();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            if (totalPoints >= 50)
            {
                resultsLabel.Text = $"Congratulations, {username}!\nYou scored {totalPoints} points.";
                confettiTimer.Start();
            }
            else
            {
                resultsLabel.Text = $"Try again, {username}.\nYou scored {totalPoints} points.";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfettiTimer_Tick(object sender, EventArgs e)
        {
            if (confettiParticles.Count < MaxConfettiParticles)
            {
                for (int i = 0; i < 5; i++)
                {
                    confettiParticles.Add(new ConfettiParticle(random, this.ClientSize));
                }
            }

            for (int i = confettiParticles.Count - 1; i >= 0; i--)
            {
                if (confettiParticles[i].IsOffScreen(this.ClientSize))
                {
                    confettiParticles.RemoveAt(i);
                }
            }
            this.Invalidate();
        }

        private void ResultsForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var particle in confettiParticles)
            {
                particle.Draw(e.Graphics);
                particle.Update();
            }
        }
    }

    public class ConfettiParticle
    {
        private float x, y;
        private float speedX, speedY;
        private Color color;
        private float size;

        public ConfettiParticle(Random random, Size clientSize)
        {
            x = random.Next(clientSize.Width);
            y = random.Next(-clientSize.Height, 0);
            speedX = (float)(random.NextDouble() * 4 - 2);
            speedY = (float)(random.NextDouble() * 4 + 2);
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            size = (float)(random.NextDouble() * 5 + 2);
        }

        public void Update()
        {
            x += speedX;
            y += speedY;
        }

        public void Draw(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, x, y, size, size);
            }
        }

        public bool IsOffScreen(Size clientSize)
        {
            return y > clientSize.Height || x < 0 || x > clientSize.Width;
        }
    }
}
