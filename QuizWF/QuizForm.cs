using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using OfficeOpenXml;

namespace QuizWF
{
    public partial class QuizForm : RoundedForm
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private List<UserAnswer> userAnswers;

        public QuizForm(string username)
        {
            this.username = username;
            InitializeComponent();
            usernameLabel.Text = username;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            userAnswers = new List<UserAnswer>();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            string json = File.ReadAllText("quiz.json");
            questions = JsonSerializer.Deserialize<List<Question>>(json);
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var question = questions[currentQuestionIndex];
                questionLabel.Text = question.QuestionText;

                for (int i = 0; i < optionButtons.Length; i++)
                {
                    optionButtons[i].Text = question.Options[i];
                    optionButtons[i].Checked = false;
                }

                warningLabel.Visible = false;
            }
            else
            {
                SaveResults();
                this.Close();
                ResultsForm resultsForm = new ResultsForm(username, totalPoints);
                resultsForm.ShowDialog();
            }
        }

        private void OptionButton_CheckedChanged(object sender, EventArgs e)
        {
            warningLabel.Visible = false;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            bool answerSelected = optionButtons.Any(rb => rb.Checked);

            if (!answerSelected)
            {
                warningLabel.Visible = true;
                return;
            }

            var selectedButton = optionButtons.FirstOrDefault(rb => rb.Checked);
            if (selectedButton != null)
            {
                var question = questions[currentQuestionIndex];
                int points = 0;

                if (selectedButton.Text == question.CorrectAnswer)
                {
                    points = question.Points;
                    totalPoints += points;
                }

                userAnswers.Add(new UserAnswer
                {
                    Question = question.QuestionText,
                    Answer = selectedButton.Text,
                    Points = points
                });
            }

            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveResults()
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"{username}_results");
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{username}_results_{DateTime.Now:dd_MM_yy_HH_mm_ss}.xlsx");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Results");

                worksheet.Cells[1, 1].Value = "Question";
                worksheet.Cells[1, 2].Value = "Answer";
                worksheet.Cells[1, 3].Value = "Points";

                for (int i = 0; i < userAnswers.Count; i++)
                {
                    var userAnswer = userAnswers[i];
                    worksheet.Cells[i + 2, 1].Value = userAnswer.Question;
                    worksheet.Cells[i + 2, 2].Value = userAnswer.Answer;
                    worksheet.Cells[i + 2, 3].Value = userAnswer.Points;
                }

                worksheet.Cells[userAnswers.Count + 2, 1].Value = "Total";
                worksheet.Cells[userAnswers.Count + 2, 3].Value = totalPoints;

                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int Points { get; set; }
    }

    public class UserAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Points { get; set; }
    }
}
