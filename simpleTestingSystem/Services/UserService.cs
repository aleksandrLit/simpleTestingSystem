using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleTestingSystem.Models;

namespace simpleTestingSystem.Services
{
    class UserService : IUserService
    {
        List<User> users;

        public UserService()
        {
            users = new List<User>();
            users.Add(new User { usernName = "root", password = "root", firstName = "Администратор", isSuperuser = true });
            users.Add(new User { usernName = "tester1", password = "tester1", firstName = "Иван", lastName = "Иванов", middleName = "Иванович", isSuperuser = false });
        }

        public void setUsers(List<User> users)
        {
            this.users = users;
        }

        public void createUser(User user)
        {
            users.Add(user);
        }

        public User getUserByUsernameAndPassword(string userName, string password)
        {
            foreach (User user in users)
            {
                if (user.usernName.Equals(userName) && user.password.Equals(password))
                {
                    return user;
                }
            }
            return null;            
        }

        public List<User> getUsers()
        {
            return users;
        }
    }
}
