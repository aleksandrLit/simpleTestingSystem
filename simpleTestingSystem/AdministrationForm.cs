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
        public const string FILE_QUESTION = "fileQuestion";

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean selectedItemNotNull = ((ListBox)sender).SelectedItem != null;
            selectedItem = selectedItemNotNull ? (TestQuestion)listBox1.SelectedItem : null;
            button2.Enabled = selectedItemNotNull;
            button3.Enabled = selectedItemNotNull;
        }

        private void fillQuestionList(BindingList<TestQuestion> questions)
        {
            listBox1.DataSource = questions;
            listBox1.DisplayMember = "textQuestion";
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2_MouseClick(sender, e);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            using (var addQuestionForm = new QuestionForm())
            {
                addQuestionForm.Text = "Добавить новый вопрос";
                var result = addQuestionForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    questions.Add(addQuestionForm.question);
                }
                this.Show();
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            TestQuestion selectedQuestion = (TestQuestion)listBox1.SelectedItem;
            int selectedIndex = listBox1.SelectedIndex;
            using (var addQuestionForm = new QuestionForm(selectedQuestion))
            {
                addQuestionForm.Text = "Изменить вопрос";
                var result = addQuestionForm.ShowDialog();
                if (DialogResult.OK.Equals(result))
                {
                    questions[selectedIndex] = addQuestionForm.question;
                }
                this.Show();
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            questions.Remove((TestQuestion)listBox1.SelectedItem);
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            TestQuestion[] testQuestions = questions.ToArray();
            BinaryFormatter formatter = new BinaryFormatter();
            string fileName = Properties.Resources.ResourceManager.GetString(FILE_QUESTION);
            SerializeUtils.serialize(testQuestions, fileName);
            MessageBox.Show("Вопросы успешно сохранены!");
        }

        private List<TestQuestion> loadQuestion()
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            if (File.Exists(Properties.Resources.ResourceManager.GetString(FILE_QUESTION)))
            {
                object deserializeObject = SerializeUtils.deserialize(Properties.Resources.ResourceManager.GetString(FILE_QUESTION));
                questions = ((TestQuestion[])deserializeObject).ToList();
            }
            return questions;
        }
    }
}
