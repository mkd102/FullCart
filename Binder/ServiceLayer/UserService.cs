using InterfaceDAL;
using InterfaceService;
using Models;
using System;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private IDAL<User> _idal;
       public UserService(IDAL<User> idal) {
            this._idal = idal;
        }
        public User CreateUser(User user)
        {
            user.UserRoles.Add(new UserRole() { RoleId = 2 });
           var newuser= this._idal.Add(user);
            this._idal.Save();
            return newuser;
        }
    }
}
