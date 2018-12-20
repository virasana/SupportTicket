using System.Collections.Generic;
using ST.SharedUserEntitiesLib;

namespace ST.SharedInterfacesLib
{
    public interface IUserService<out TUsersRepo> 
        where TUsersRepo: ISTUsersRepo
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User SignUp(User user);
        User Get(int id);
    }
}
