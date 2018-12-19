using System;
using System.Collections.Generic;
using System.Text;
using ST.SharedUserEntitiesLib;

namespace ST.SharedInterfacesLib
{
    public interface ISTUsersRepo
    {
        User GetUserMatching(string userName, string password);
        IEnumerable<User> GetAllUsers();
        void Initialise(string connectionString);
        User SignUp(User user);
        User Get(int id);
    }
}
