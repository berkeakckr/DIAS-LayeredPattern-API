using DiasProjectUser.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UserFinder.Entities;

namespace DiasProjectUser.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        int lastId;
        public int CreateUserInitialDAL(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                user.dateOfAction = DateTime.Now;
                userDbContext.Users.Add(user);
                
                userDbContext.SaveChanges();
                lastId = user.id;
            }
            return lastId;
        }

        public List<User> GetAllUsersDAL()
        {
            using (var userDbContext=new UserDbContext())
            {
                return userDbContext.Users.ToList();
            }       
        }

        public bool CheckVerificationCodeDAL(User user,int id)
        {
            using (var userDbContext = new UserDbContext())
            {
                
                var user2 = userDbContext.Users.FirstOrDefault(u => u.id == id);
                if (user2.verificationCode != null && user.verificationCode == user2.verificationCode)
                {
                    user2.status = "SUCCESS";
                    userDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    user2.status = "FAIL";
                    userDbContext.SaveChanges();
                    return false;
                }
                
            }
        }

        public void VerificationTimeOutDAL(User user, int id)
        {
            using (var userDbContext = new UserDbContext())
            {
                var user2 = userDbContext.Users.FirstOrDefault(u => u.id == id);
                user2.status = "TIMEOUT";
                userDbContext.SaveChanges();
            }
        }
    }
}
