namespace QuizWF
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label usernameLabel;
        private RoundedTextBox usernameTextBox;
        private RoundedButton signUpButton;
        private System.Windows.Forms.Label warningLabel;
        private RoundedPanel panel1;
        private RoundedButton closeButton;

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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new QuizWF.RoundedTextBox();
            this.signUpButton = new QuizWF.RoundedButton();
            this.warningLabel = new System.Windows.Forms.Label();
            this.panel1 = new QuizWF.RoundedPanel();
            this.closeButton = new QuizWF.RoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(84, 36);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(84, 21);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.CornerRadius = 15;
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.usernameTextBox.Location = new System.Drawing.Point(85, 60);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(230, 25);
            this.usernameTextBox.TabIndex = 1;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // signUpButton
            // 
            this.signUpButton.CornerRadius = 15;
            this.signUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.signUpButton.Location = new System.Drawing.Point(135, 150);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(120, 30);
            this.signUpButton.TabIndex = 2;
            this.signUpButton.Text = "Continue";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(85, 100);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(165, 15);
            this.warningLabel.TabIndex = 3;
            this.warningLabel.Text = "Please enter a valid username!";
            this.warningLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Controls.Add(this.signUpButton);
            this.panel1.Controls.Add(this.warningLabel);
            this.panel1.CornerRadius = 15;
            this.panel1.Location = new System.Drawing.Point(200, 125);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(400, 250);
            this.panel1.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.CornerRadius = 15;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.closeButton.Location = new System.Drawing.Point(760, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
