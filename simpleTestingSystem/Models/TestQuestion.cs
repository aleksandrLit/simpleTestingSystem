using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Models
{
    [Serializable]
    class TestQuestion
    {
        public String textQuestion { get; set; }
        public List<String> answers { get; set; }
        public int correctAnswerNumber { get; set; }
    }
}
