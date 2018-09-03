using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class AdministrationForm : Form
    {
        IQuestionService questionService;
        TestQuestion selectedItem;
        BindingList<TestQuestion> questions;

        public AdministrationForm()
        {
            InitializeComponent();
            questionService = new QuestionService();
            questions = new BindingList<TestQuestion>(loadQuestion());
            fillQuestionList(questions);
        }

        private void questionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean selectedItemNotNull = ((ListBox)sender).SelectedItem != null;
            selectedItem = selectedItemNotNull ? (TestQuestion)questionListBox.SelectedItem : null;
            editQuestionButton.Enabled = selectedItemNotNull;
            removeQuestionButton.Enabled = selectedItemNotNull;
        }

        private void fillQuestionList(BindingList<TestQuestion> questions)
        {
            questionListBox.DataSource = questions;
            questionListBox.DisplayMember = "textQuestion";
        }

        private void questionListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editQuestionButton_MouseClick(sender, e);
        }

        private void addQuestionButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            using (var addQuestionForm = new QuestionForm())
            {
                addQuestionForm.Text = Properties.Resources.ADD_QUESTION;
                var result = addQuestionForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    questions.Add(addQuestionForm.question);
                }
                this.Show();
            }
        }

        private void editQuestionButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            TestQuestion selectedQuestion = (TestQuestion)questionListBox.SelectedItem;
            int selectedIndex = questionListBox.SelectedIndex;
            using (var addQuestionForm = new QuestionForm(selectedQuestion))
            {
                addQuestionForm.Text = Properties.Resources.CHANGE_QUESTION;
                var result = addQuestionForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    questions[selectedIndex] = addQuestionForm.question;
                }
                this.Show();
            }
        }

        private void removeQuestionButton_MouseClick(object sender, MouseEventArgs e)
        {
            questions.Remove((TestQuestion)questionListBox.SelectedItem);
        }

        private void saveQuestionsButton_MouseClick(object sender, MouseEventArgs e)
        {
            TestQuestion[] testQuestions = questions.ToArray();
            BinaryFormatter formatter = new BinaryFormatter();
            string fileName = Properties.Resources.FILE_QUESTIONS;
            SerializeUtils.serialize(testQuestions, fileName);
            MessageBox.Show(Properties.Resources.SUCCESS_SAVED_QUESTIONS);
        }

        private List<TestQuestion> loadQuestion()
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            if (File.Exists(Properties.Resources.FILE_QUESTIONS))
            {
                object deserializeObject = SerializeUtils.deserialize(Properties.Resources.FILE_QUESTIONS);
                questions = ((TestQuestion[])deserializeObject).ToList();
            }
            return questions;
        }
    }
}
