using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFinder.Entities;

namespace DiasProjectUser.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUsersDAL();
        int CreateUserInitialDAL(User user);
        bool CheckVerificationCodeDAL(User user,int id);
        void VerificationTimeOutDAL(User user, int id);
    }
}
