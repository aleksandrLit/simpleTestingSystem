using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleTestingSystem.Models;

namespace simpleTestingSystem.Services
{
    class QuestionService : IQuestionService
    {
        Dictionary<int, TestQuestion> questions;
        int lastQuestionid = 0;
    
        public QuestionService() { }

        public void addQuestion(TestQuestion question)
        {
            questions.Add(lastQuestionid++, question);
        }

        public void deleteQuestion(int questionNumber)
        {
            questions.Remove(questionNumber);
        }

        public List<TestQuestion> getQuestion()
        {
            return questions.Values.ToList();
        }

        public void setQuestion(List<TestQuestion> questions)
        {
            fillQuestionDictionary(questions);
        }

        private void fillQuestionDictionary(List<TestQuestion> questionsList)
        {
            if (questionsList == null)
            {
                return;
            }
            questions = new Dictionary<int, TestQuestion>(questionsList.Count);
            foreach(TestQuestion question in questionsList)
            {
                questions.Add(lastQuestionid++, question);
            } 
        }

        public void updateQuestion(TestQuestion question, int questionNumber)
        {
            questions[questionNumber] = question;
        }
    }
}
