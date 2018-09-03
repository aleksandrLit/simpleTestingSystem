using System;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class AnswerForm : Form
    {
        public string currentAnswer { get; set; }

        public AnswerForm()
        {
            InitializeComponent();
        }

        public AnswerForm(string answer)
        {
            InitializeComponent();
            currentAnswer = answer;
            fillForm();
        }

        private void saveAnswerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(answerTextBox.Text))
            {
                currentAnswer = answerTextBox.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void answerTextBox_TextChanged(object sender, EventArgs e)
        {
            saveAnswerButton.Enabled = !string.IsNullOrWhiteSpace(answerTextBox.Text);
        }

        private void fillForm()
        {
            answerTextBox.Text = currentAnswer;
        }
    }
}
