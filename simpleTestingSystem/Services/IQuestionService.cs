using simpleTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    public interface IQuestionService
    {
        List<TestQuestion> getQuestion();
        void serializeQuestions(List<TestQuestion> questions);
    }
}
