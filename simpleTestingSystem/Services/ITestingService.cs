using simpleTestingSystem.Models;
using simpleTestingSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    interface ITestingService
    {
        List<TestQuestion> randomizeQuestionList(List<TestQuestion> questions);
        double calculateResult(Dictionary<int, int> userAnswers, List<TestQuestion> questions);
        string getMarkInText(double markInProcent);
        void writeTextInfoResult(TestingReport report);
        List<Pair<string, string>> fillPairQuestionAnswer(List<TestQuestion> questions, Dictionary<int, int> answersForQuestions);
    }
}
