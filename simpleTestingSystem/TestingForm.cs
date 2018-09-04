using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IQuestionService questionService;


        public TestingForm(IQuestionService questionService)
        {
            InitializeComponent();
            userAnswers = new Dictionary<int, int>();
            testingService = new TestingService();
            this.questionService = questionService;
            List<TestQuestion> questions = questionService.getQuestion();
            if (isListNotNullAndHaveItems(questions))
            {
                prepareForm(questions);
            }
            else
            {
                MessageBox.Show(Properties.Resources.FILE_NOT_FOUNT_OR_DAMAGED, Properties.Resources.ERROR);
                this.Close();
            }

        }

        private bool isListNotNullAndHaveItems<T>(List<T> list)
        {
            return list != null && list.Any();
        }

        private void prepareForm(List<TestQuestion> questions)
        {
            randomizeQuestion = testingService.randomizeQuestionList(questions);
            currentQuestionIndex = 0;
            currentQuestion = randomizeQuestion[currentQuestionIndex];
            renderQuestion(currentQuestion);
            setAnswersProgressBar.Value = 0;
            setAnswersProgressBar.Maximum = randomizeQuestion.Count;
            setAnswersProgressBar.Step = 1;
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
            questionTextBox.Text = currentQuestion.textQuestion;
            answersCheckedListBox.Items.Clear();
            answersCheckedListBox.Items.AddRange(currentQuestion.answers.ToArray());
            if (userAnswers.ContainsKey(currentQuestionIndex))
            {
                lastCheckedIndex = userAnswers[currentQuestionIndex];
                answersCheckedListBox.SetItemChecked(lastCheckedIndex.Value, true);

            }
            refreshComponents();
        }

        private void previosQuestionButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (getPreviosQuestion() != null)
            {
                renderQuestion(currentQuestion);
            }
        }

        private void nextQuestionsButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (getNextQuestion() != null)
            {
                renderQuestion(currentQuestion);
            }
        }

        private void giveAnswerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (answersCheckedListBox.CheckedIndices.Count != 0)
            {
                if (userAnswers.ContainsKey(currentQuestionIndex))
                {
                    userAnswers[currentQuestionIndex] = answersCheckedListBox.CheckedIndices[0];
                }
                else
                {
                    userAnswers.Add(currentQuestionIndex, answersCheckedListBox.CheckedIndices[0]);
                    setAnswersProgressBar.PerformStep();
                }
                if (isUserAnsweredAllQuestions())
                {
                    endTestingButton.Enabled = true;
                }
                else if (getNextQuestion() != null)
                {
                    renderQuestion(currentQuestion);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.NEED_SELECTED_ANSWER, Properties.Resources.ATTENTION);
            }
        }

        private void endTestingButton_MouseClick(object sender, MouseEventArgs e)
        {
            string markInText = testingService.getMarkInText(testingService.calculateResult(userAnswers, randomizeQuestion));
            MessageBox.Show(string.Format(Properties.Resources.YOUR_RESULT, markInText));
            TestingReport report = fillTesingReport(markInText);
            testingService.writeTextInfoResult(report);
            this.Close();
        }

        private bool isUserAnsweredAllQuestions()
        {
            return randomizeQuestion.Count.Equals(userAnswers.Count);
        }

        private void refreshComponents()
        {
            questionTextBox.Refresh();
            answersCheckedListBox.Refresh();
        }

        private TestingReport fillTesingReport(string markInText)
        {
            TestingReport report = new TestingReport();
            User currentUser = (User)Properties.Settings.Default.Context[Properties.Resources.CURRENT_USER];
            report.firstName = currentUser.firstName;
            report.lastName = currentUser.lastName;
            report.middleName = currentUser.middleName;
            report.mark = markInText;
            report.questionAnswerPair = testingService.fillPairQuestionAnswer(randomizeQuestion, userAnswers);
            return report;
        }
    }
}
