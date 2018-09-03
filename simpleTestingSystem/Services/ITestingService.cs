using simpleTestingSystem.Models;
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
    }
}
