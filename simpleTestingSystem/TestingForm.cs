using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
using System;
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
    public partial class TestingForm : Form
    {
        public const string FILE_QUESTION = "fileQuestion";

        private ITestingService testingService;
        private List<TestQuestion> randomizeQuestion;
        private Dictionary<int, int> userAnswers;
        private int currentQuestionIndex;
        private TestQuestion currentQuestion;
        private Nullable<int> lastCheckedIndex = null;


        public TestingForm()
        {
            InitializeComponent();
            userAnswers = new Dictionary<int, int>();
            testingService = new TestingService();
            List<TestQuestion> questions = getTestQuestions();
            if (questions != null)
            {
                randomizeQuestion = testingService.randomizeQuestionList(questions);
                currentQuestionIndex = 0;
                currentQuestion = randomizeQuestion[currentQuestionIndex];
                renderQuestion(currentQuestion);
                progressBar1.Value = 0;
                progressBar1.Maximum = randomizeQuestion.Count;
                progressBar1.Step = 1;
            }
        }

        private List<TestQuestion> getTestQuestions()
        {
            List<TestQuestion> questions = null;
            var deserializeResult = SerializeUtils.deserialize(Properties.Resources.ResourceManager.GetString(FILE_QUESTION));
            if (deserializeResult == null || !(deserializeResult is TestQuestion[]))
            {
                MessageBox.Show("Файл с тестами не найден, либо повреждён!", "Ошибка!");
                this.Close();
            }
            else
            {
                questions = ((TestQuestion[])deserializeResult).ToList();
            }
            return questions;            
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

        private TestQuestion getNextQuestion()
        {
            TestQuestion nextQuestion = null;
            if (currentQuestionIndex + 1 < randomizeQuestion.Count)
            {
                nextQuestion = randomizeQuestion[++currentQuestionIndex];
                currentQuestion = nextQuestion;
            }
            return nextQuestion;
        }

        private TestQuestion getPreviosQuestion()
        {
            TestQuestion previosQuestion = null;
            if (currentQuestionIndex - 1 >= 0)
            {
                previosQuestion = randomizeQuestion[--currentQuestionIndex];
                currentQuestion = previosQuestion;
            }
            return previosQuestion;
        }

        private void renderQuestion(TestQuestion question)
        {
            lastCheckedIndex = null;
            textBox1.Text = currentQuestion.textQuestion;
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(currentQuestion.answers.ToArray());
            if(userAnswers.ContainsKey(currentQuestionIndex))
            {
                lastCheckedIndex = userAnswers[currentQuestionIndex];
                checkedListBox1.SetItemChecked(lastCheckedIndex.Value, true);
                
            }
            refreshComponents();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (getPreviosQuestion() != null)
            {
                renderQuestion(currentQuestion);
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (getNextQuestion() != null)
            {
                renderQuestion(currentQuestion);
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count != 0)
            {
                if (userAnswers.ContainsKey(currentQuestionIndex))
                {
                    userAnswers[currentQuestionIndex] = checkedListBox1.CheckedIndices[0];
                }
                else
                {
                    userAnswers.Add(currentQuestionIndex, checkedListBox1.CheckedIndices[0]);
                    progressBar1.PerformStep();
                }
                if (isUserAnsweredAllQuestions())
                {
                    button4.Enabled = true;
                } 
                else if (getNextQuestion() != null)
                {
                    renderQuestion(currentQuestion);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать вариант ответа", "Внимание!");
            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            double markInProcent = testingService.calculateResult(userAnswers, randomizeQuestion);
            MessageBox.Show(string.Format("Ваш результат - {0} ", testingService.getMarkInText(markInProcent)));
            this.Close();
        }

        private bool isUserAnsweredAllQuestions()
        {
            return randomizeQuestion.Count.Equals(userAnswers.Count);
        }

        private void refreshComponents()
        {
            textBox1.Refresh();
            checkedListBox1.Refresh();
        }
    }
}
