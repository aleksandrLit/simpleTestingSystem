using simpleTestingSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class QuestionForm : Form
    {
        private Nullable<int> lastCheckedIndex = null; 
        public TestQuestion question { set; get; }

        public QuestionForm()
        {
            InitializeComponent();
            fillForm();
        }

        public QuestionForm(TestQuestion question)
        {
            InitializeComponent();
            this.question = question;
            fillForm();
        }

        private void fillForm()
        {
            if (question != null)
            {
                questionTextBox.Text = question.textQuestion;
                fillAnswerList(question.answers, question.correctAnswerNumber);
            }
        }

        private void fillAnswerList(List<string> answers, int numberCorrectAnswer)
        {
            if (answers != null)
            {
                for (int i = 0; i < answers.Count; i++)
                {
                    answersCheckedListBox.Items.Add(answers[i], numberCorrectAnswer == i);
                }
            }
        }

        private void saveQuestionButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTextBox.Text) || ((CheckedListBox)answersCheckedListBox).Items.Count < 2
                || answersCheckedListBox.CheckedIndices.Count == 0)
            {
                MessageBox.Show(Properties.Resources.WRONG_SET_QUESTION_FORM, Properties.Resources.ATTENTION);
                return;
            }
            question = new TestQuestion();
            question.textQuestion = questionTextBox.Text.Trim();
            question.answers = answersCheckedListBox.Items.Cast<string>().ToList();
            fillCorrectAnswer();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fillCorrectAnswer()
        {
            if (answersCheckedListBox.CheckedIndices != null && answersCheckedListBox.CheckedIndices.Count != 0)
            {
                question.correctAnswerNumber = answersCheckedListBox.CheckedIndices[0];
            }
        }

        private void answersCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (CheckState.Checked.Equals(e.NewValue))
            {
                if (lastCheckedIndex != null && !e.Index.Equals(lastCheckedIndex))
                {
                    answersCheckedListBox.SetItemChecked(lastCheckedIndex.Value, false);
                } 
                lastCheckedIndex = e.Index;                             
            }
        }

        private void answersCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSelectedSomeItem = ((CheckedListBox)sender).SelectedItem != null;
            editAnswerButton.Enabled = isSelectedSomeItem;
            removeAnswerButton.Enabled = isSelectedSomeItem;
        }

        private void removeAnswerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (answersCheckedListBox.SelectedItem != null)
            {
                if (answersCheckedListBox.SelectedIndex.Equals(lastCheckedIndex))
                {
                    lastCheckedIndex = null;
                }
                answersCheckedListBox.Items.Remove(answersCheckedListBox.SelectedItem);
            }
        }

        private void addAnswerButton_MouseClick(object sender, MouseEventArgs e)
        {
            createAnswerForm();
        }

        private void editAnswerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (answersCheckedListBox.SelectedItem != null)
            {
                string currentAnswer = (string) answersCheckedListBox.SelectedItem;
                createAnswerForm(currentAnswer, answersCheckedListBox.SelectedIndex);
            }
        }

        private void createAnswerForm(string answer = null, Nullable<int> answerIndex = null)
        {
            this.Hide();
            using (var answerForm = new AnswerForm(answer))
            {
                
                answerForm.Text = answer == null ? Properties.Resources.ADD_ANSWER : Properties.Resources.EDIT_ANSWER;
                var result = answerForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    if (answerIndex != null && answerIndex.HasValue)
                    {
                        answersCheckedListBox.Items[answerIndex.Value] = answerForm.currentAnswer;
                    }
                    else
                    {
                        answersCheckedListBox.Items.Add(answerForm.currentAnswer);
                    }
                }
                this.Show();
            }
        }
    }
}
