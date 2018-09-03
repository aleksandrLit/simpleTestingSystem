using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleTestingSystem.Models;

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
                return "Не удовлетворительно";
            }
        }
    }
}
