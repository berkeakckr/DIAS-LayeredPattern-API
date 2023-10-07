using DiasProjectUser.Business.Abstract;
using DiasProjectUser.DataAccess.Abstract;
using DiasProjectUser.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UserFinder.Entities;

namespace DiasProjectUser.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public static int createdId;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }
        public void CreateUserInitial(User user)
        {

            SendVerificationCode(user);
            createdId = _userRepository.CreateUserInitialDAL(user);
            Console.WriteLine("UserManager-CreateUserInitial   "+createdId);

        }

        public void CheckVerificationCode(User user)
        {
            Console.WriteLine("userManager-CheckVerificationCode    "+createdId);
            _userRepository.CheckVerificationCodeDAL(user, createdId);
        }
        
            

    public void VerificationTimeOut(User user)
        {
            Console.WriteLine("userManager-VerificationTimeOut    " + createdId);
            _userRepository.VerificationTimeOutDAL(user, createdId);
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsersDAL();
        }

        private void SendVerificationCode(User user)
        {
            Random random = new Random();
            string verificationCode = random.Next(10000, 100000).ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("tyhfnew@gmail.com", "adbtysqsmilfopdl");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Email Doğrulama İçin Aktivasyon Kodunuz";
            msg.Body = "Aktivasyon Kodunuz: " + verificationCode;
            string toAdress = user.email;
            msg.To.Add(toAdress);
            string fromAdress = "tyhfnew@gmail.com";
            msg.From = new MailAddress(fromAdress);
            try
            {
                smtp.Send(msg);
                user.verificationCode = verificationCode;
            }
            catch
            {
                throw;
            }
        }


    }
}
