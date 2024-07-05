using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizWF
{
    partial class ResultsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label resultsLabel;
        private Button closeButton;
        private Timer confettiTimer;
        private List<ConfettiParticle> confettiParticles;
        private Random random;
        private Label usernameLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.resultsLabel = new Label();
            this.closeButton = new Button();
            this.confettiTimer = new Timer();
            this.usernameLabel = new Label();

            this.SuspendLayout();
            // 
            // resultsLabel
            // 
            this.resultsLabel.Font = new Font("Segoe UI", 12F);
            this.resultsLabel.Location = new Point(50, 100);
            this.resultsLabel.Size = new Size(300, 50);
            this.resultsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = FlatStyle.Flat;
            this.closeButton.Font = new Font("Segoe UI", 10F);
            this.closeButton.Location = new Point(150, 200);
            this.closeButton.Size = new Size(100, 30);
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new EventHandler(this.CloseButton_Click);
            // 
            // confettiTimer
            // 
            this.confettiTimer.Interval = 50;
            this.confettiTimer.Tick += new EventHandler(this.ConfettiTimer_Tick);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new Font("Segoe UI", 10F);
            this.usernameLabel.Location = new Point(10, 10);
            this.usernameLabel.Size = new Size(200, 30);
            this.usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 250);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ResultsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.Paint += new PaintEventHandler(this.ResultsForm_Paint);
            this.Load += new EventHandler(this.ResultsForm_Load);
            this.ResumeLayout(false);
        }
    }
}
