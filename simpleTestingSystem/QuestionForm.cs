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
                textBox1.Text = question.textQuestion;
                fillAnswerList(question.answers, question.correctAnswerNumber);
            }
        }

        private void fillAnswerList(List<string> answers, int numberCorrectAnswer)
        {
            if (answers != null)
            {
                for (int i = 0; i < answers.Count; i++)
                {
                    checkedListBox1.Items.Add(answers[i], numberCorrectAnswer == i);
                }
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || ((CheckedListBox)checkedListBox1).Items.Count < 2
                || checkedListBox1.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Необходимо заполнить поле вопрос, добавить минимум 2 ответа и выбрать один правильный ответ", "Внимание!");
                return;
            }
            question = new TestQuestion();
            question.textQuestion = textBox1.Text.Trim();
            question.answers = checkedListBox1.Items.Cast<string>().ToList();
            fillCorrectAnswer();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fillCorrectAnswer()
        {
            if (checkedListBox1.CheckedIndices != null && checkedListBox1.CheckedIndices.Count != 0)
            {
                question.correctAnswerNumber = checkedListBox1.CheckedIndices[0];
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (CheckState.Checked.Equals(e.NewValue))
            {
                if (lastCheckedIndex != null && !e.Index.Equals(lastCheckedIndex))
                {
                    checkedListBox1.SetItemChecked(lastCheckedIndex.Value, false);
                } 
                lastCheckedIndex = e.Index;                             
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSelectedSomeItem = ((CheckedListBox)sender).SelectedItem != null;
            button3.Enabled = isSelectedSomeItem;
            button4.Enabled = isSelectedSomeItem;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                if (checkedListBox1.SelectedIndex.Equals(lastCheckedIndex))
                {
                    lastCheckedIndex = null;
                }
                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            createAnswerForm();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                string currentAnswer = (string) checkedListBox1.SelectedItem;
                createAnswerForm(currentAnswer, checkedListBox1.SelectedIndex);
            }
        }

        private void createAnswerForm(string answer = null, Nullable<int> answerIndex = null)
        {
            this.Hide();
            using (var answerForm = new AnswerForm(answer))
            {
                
                answerForm.Text = answer == null ? "Добавить новый ответ" : "Редактировать ответа";
                var result = answerForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    if (answerIndex != null && answerIndex.HasValue)
                    {
                        checkedListBox1.Items[answerIndex.Value] = answerForm.currentAnswer;
                    }
                    else
                    {
                        checkedListBox1.Items.Add(answerForm.currentAnswer);
                    }
                }
                this.Show();
            }
        }
    }
}
