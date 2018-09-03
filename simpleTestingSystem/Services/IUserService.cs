using simpleTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    interface IUserService
    {
        User getUserByUsernameAndPassword(String userName, String password);
        void createUser(User user);
        void setUsers(List<User> users);
        List<User> getUsers();
    }
}
