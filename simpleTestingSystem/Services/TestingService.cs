using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using simpleTestingSystem.Models;
using simpleTestingSystem.Utils;
using System.IO;

namespace simpleTestingSystem.Services
{
    class TestingService : ITestingService
    {
        static Random rnd = new Random();
        List<TestQuestion> questionBeforeRandomize { set; get; }

        public List<TestQuestion> randomizeQuestionList(List<TestQuestion> questions)
        {
            List<TestQuestion> list = new List<TestQuestion>(questions);
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
                randomizeAnswers(value);
            }
            return list;
        }

        public void randomizeAnswers(TestQuestion testQuestion)
        {
            List<string> answers = testQuestion.answers;
            int n = answers.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = answers[k];
                answers[k] = answers[n];
                answers[n] = value;
                if (k.Equals(testQuestion.correctAnswerNumber))
                {
                    testQuestion.correctAnswerNumber = n;
                } else if (n.Equals(testQuestion.correctAnswerNumber))
                {
                    testQuestion.correctAnswerNumber = k;
                }
            }
        }

        public double calculateResult(Dictionary<int, int> userAnswers, List<TestQuestion> currentQuestions)
        {
            int correctAnswers = 0;
            foreach(var value in userAnswers.ToArray())
            {
                int currentAnswers = currentQuestions[value.Key].correctAnswerNumber;
                if (currentAnswers.Equals(value.Value))
                {
                    correctAnswers++;
                }
            }
            return (double)correctAnswers / currentQuestions.Count;
        }

        public string getMarkInText(double markInProcent)
        {
            if (markInProcent >= 0.53D && markInProcent < 0.8D)
            {
                return "Удовлетворительно";
            } else if (markInProcent >= 0.8D && markInProcent < 0.93D)
            {
                return "Хорошо";
            } else if (markInProcent >= 0.93D)
            {
                return "Отлично";
            } else
            {
                return "Неудовлетворительно";
            }
        }

        public void writeTextInfoResult(TestingReport report)
        {
            string outputText = prepareTextFromTextFile(report);
            String fileName = string.Format("{0}{1}{2}-{3}.txt", report.firstName, report.middleName, report.lastName, DateTime.Now.ToShortDateString());
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(outputText);
            }

        }

        public List<Pair<string, string>> fillPairQuestionAnswer(List<TestQuestion> questions, Dictionary<int, int> answersForQuestions)
        {
            List<Pair<string, string>> answers = new List<Pair<string, string>>();
            foreach(KeyValuePair<int, int> valie in answersForQuestions)
            {
                answers.Add(new Pair<string, string>(questions[valie.Key].textQuestion, questions[valie.Key].answers[valie.Value]));
            }
            return answers;
        }

        private string prepareTextFromTextFile(TestingReport report)
        {
            StringBuilder outputText = new StringBuilder();
            outputText.Append("-------------------------------------------------------------------\n");
            outputText.Append("-------------------------Начало отчета-----------------------------\n");
            outputText.AppendFormat("-----------------------{0}-------------------------\n", DateTime.Now);
            outputText.Append("-------------------------------------------------------------------\n");
            outputText.AppendFormat("Пользователь - {0} {1} {2}\n", report.firstName, report.middleName, report.lastName);
            outputText.AppendFormat("За прохождение теста получил следующую оценку - {0}\n", report.mark);
            outputText.Append("Выбрал следующие ответы на вопросы: \n");
            int numberQuestion = 1;
            foreach (Pair<string, string> questionAnswerPair in report.questionAnswerPair)
            {
                outputText.AppendFormat("Вопрос №{0}. {1}. Ответ - {2}\n", numberQuestion++, questionAnswerPair.Left, questionAnswerPair.Right);
            }
            outputText.Append("-------------------------------------------------------------------\n");
            outputText.Append("-------------------------Конец отчета------------------------------\n");
            outputText.Append("-------------------------------------------------------------------\n");
            return outputText.ToString();
        }
    }
}
