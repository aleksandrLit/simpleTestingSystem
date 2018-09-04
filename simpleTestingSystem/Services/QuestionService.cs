using System;
using System.Collections.Generic;
using System.Linq;
using simpleTestingSystem.Models;
using System.IO;

namespace simpleTestingSystem.Services
{
    class QuestionService : IQuestionService
    {
        List<TestQuestion> questions;
    
        public QuestionService()
        {
            questions = deserializeQuestions();
        }

        public List<TestQuestion> getQuestion()
        {
            return questions;
        }

        public void serializeQuestions(List<TestQuestion> serializeQuestions)
        {
            questions = serializeQuestions;
            SerializeUtils.serialize(questions.ToArray(), Properties.Resources.FILE_QUESTIONS);
        }

        private List<TestQuestion> deserializeQuestions()
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            if (File.Exists(Properties.Resources.FILE_QUESTIONS))
            {
                object deserializeObject = SerializeUtils.deserialize(Properties.Resources.FILE_QUESTIONS);
                questions = ((TestQuestion[])deserializeObject).ToList();
            }
            return questions;
        }
    }
}
