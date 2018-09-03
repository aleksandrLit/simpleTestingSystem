using simpleTestingSystem.Models;
using System.Collections.Generic;

namespace simpleTestingSystem.Services
{
    public interface IUserService
    {
        User getUserByUsernameAndPassword(string userName, string password);
        bool isExistUserWithUsername(string username);
        void createUser(User user);
        List<User> getUsers();
        void serializeUsers();
    }
}
