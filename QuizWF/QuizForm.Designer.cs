using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizWF
{
    partial class QuizForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label questionLabel;
        private RadioButton[] optionButtons;
        private RoundedButton nextButton;
        private Label warningLabel;
        private Label loggedInAsLabel;
        private Label usernameLabel;
        private Button closeButton;
        private int currentQuestionIndex = 0;
        private int totalPoints = 0;
        private List<Question> questions;
        private string username;

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
            this.questionLabel = new Label();
            this.optionButtons = new RadioButton[4];
            this.nextButton = new RoundedButton();
            this.warningLabel = new Label();
            this.loggedInAsLabel = new Label();
            this.usernameLabel = new Label();
            this.closeButton = new Button();

            this.SuspendLayout();

            // 
            // questionLabel
            // 
            this.questionLabel.Font = new Font("Segoe UI", 12F);
            this.questionLabel.Location = new Point(20, 70);
            this.questionLabel.Size = new Size(360, 60);
            this.questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // optionButtons
            // 
            for (int i = 0; i < this.optionButtons.Length; i++)
            {
                this.optionButtons[i] = new RadioButton();
                this.optionButtons[i].Font = new Font("Segoe UI", 10F);
                this.optionButtons[i].Location = new Point(20, 140 + (i * 40));
                this.optionButtons[i].Size = new Size(360, 30);
                this.optionButtons[i].CheckedChanged += new EventHandler(this.OptionButton_CheckedChanged);
            }
            // 
            // nextButton
            // 
            this.nextButton.FlatStyle = FlatStyle.Flat;
            this.nextButton.Font = new Font("Segoe UI", 10F);
            this.nextButton.Location = new Point(140, 500);
            this.nextButton.Size = new Size(120, 40);
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new EventHandler(this.NextButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.Font = new Font("Segoe UI", 9F);
            this.warningLabel.ForeColor = Color.Red;
            this.warningLabel.Location = new Point(20, 450);
            this.warningLabel.Size = new Size(360, 30);
            this.warningLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.warningLabel.Text = "Please select an answer.";
            this.warningLabel.Visible = false;
            // 
            // loggedInAsLabel
            // 
            this.loggedInAsLabel.Font = new Font("Segoe UI", 10F);
            this.loggedInAsLabel.Location = new Point(10, 10);
            this.loggedInAsLabel.Size = new Size(90, 30);
            this.loggedInAsLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.loggedInAsLabel.Text = "Logged in as";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new Font("Segoe UI", 10F);
            this.usernameLabel.Location = new Point(100, 10);
            this.usernameLabel.Size = new Size(200, 30);
            this.usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.usernameLabel.ForeColor = Color.Green;
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = FlatStyle.Flat;
            this.closeButton.Font = new Font("Segoe UI", 10F);
            this.closeButton.Location = new Point(340, 10);
            this.closeButton.Size = new Size(30, 30);
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.BackColor = Color.Red;
            this.closeButton.ForeColor = Color.White;
            this.closeButton.Click += new EventHandler(this.CloseButton_Click);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 600);
            this.Controls.Add(this.loggedInAsLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.questionLabel);
            foreach (var optionButton in this.optionButtons)
            {
                this.Controls.Add(optionButton);
            }
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.warningLabel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "QuizForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quiz";
            this.Load += new EventHandler(this.QuizForm_Load);
            this.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            this.ResumeLayout(false);
        }
    }
}
