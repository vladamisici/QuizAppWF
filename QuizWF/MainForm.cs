using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuizWF
{
    public partial class MainForm : RoundedForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MainForm()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                warningLabel.Visible = true;
                return;
            }
            else
            {
                QuizForm quizForm = new QuizForm(username);
                quizForm.Show();
                this.Hide();
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                        (this.ClientSize.Height - panel1.Height) / 2);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (warningLabel.Visible == true)
                warningLabel.Visible = false;
        }
    }
}
