using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleTestingSystem.Utils;

namespace simpleTestingSystem.Models
{
    public class TestingReport
    {
        public string firstName { get; set; }
        public string lastName { set; get; }
        public string middleName { set; get; }
        public string mark { get; set; }
        public List<Pair<string, string>> questionAnswerPair { get; set; }
    }
}
