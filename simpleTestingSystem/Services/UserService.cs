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
            users = deserializeUsers();
            User superUser = getSuperUser();
            if (!isExistUserWithUsername(superUser.userName))
            {
                users.Add(superUser);
            }
        }

        public void createUser(User user)
        {
            users.Add(user);
        }

        public User getUserByUsernameAndPassword(string userName, string password)
        {
            foreach (User user in users)
            {
                if (user.userName.Equals(userName) && user.password.Equals(password))
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

        public bool isExistUserWithUsername(string username)
        {
            foreach(User user in users)
            {
                if (user.userName.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public void serializeUsers()
        {
            SerializeUtils.serialize(users.ToArray(), Properties.Resources.FILE_USERS);
        }

        private List<User> deserializeUsers()
        {
            List<User> users = null;
            var deserializeResult = SerializeUtils.deserialize(Properties.Resources.FILE_USERS);
            if (deserializeResult == null || !(deserializeResult is User[]))
            {
                users = new List<User>();
            }
            else
            {
                users = ((User[])deserializeResult).ToList();
            }
            return users;
        }

        private User getSuperUser()
        {
            return new User { userName = "root", password = "root", firstName = "Администратор", isSuperuser = true };
        }
    }
}
