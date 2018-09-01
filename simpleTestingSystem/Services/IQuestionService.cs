using simpleTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    interface IQuestionService
    {
        void addQuestion(TestQuestion question);
        void updateQuestion(TestQuestion question, int questionNumber);
        void deleteQuestion(int questionNumber);
        List<TestQuestion> getQuestion();
        void setQuestion(List<TestQuestion> questions);
    }
}
