using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
        void AddUserInfo(int userId, string bio, string path);
        GeneralUser GetUserInfo(int id);
        User ChangeUserPassword(int userId, string password, string username);

    }
}
