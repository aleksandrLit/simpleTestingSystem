using System;
using System.Collections.Generic;

namespace simpleTestingSystem.Models
{
    [Serializable]
    public  class TestQuestion
    {
        public string textQuestion { get; set; }
        public List<string> answers { get; set; }
        public int correctAnswerNumber { get; set; }
    }
}
