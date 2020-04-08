using BookManagement.Entities;
using BookManagement.Models;
using System.Linq;

namespace BookManagement.BAL.Implementation
{
    public class UserManager : IUserManager
    {
        public bool Login(UserLoginModel userLoginModel)
        {
            using(var context = new BookManagementContext())
            {
                var IsUser = context.Users.FirstOrDefault(u => u.Email == userLoginModel.Email && u.Password == userLoginModel.Password);
                
                if(IsUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
