using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFinder.Entities;

namespace DiasProjectUser.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        void CreateUserInitial(User user);
        void CheckVerificationCode(User user);
        void VerificationTimeOut(User user);
        //void SetUserPassword(User user);
    }
}
