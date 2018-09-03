using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Models
{
    public class User
    {
        public String usernName { get; set; }
        public String password { get; set; }
        public String firstName { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public Boolean isSuperuser { get; set; }
    }
}
