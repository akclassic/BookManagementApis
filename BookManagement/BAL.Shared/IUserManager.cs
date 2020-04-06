using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.BAL.Implementation
{
    public interface IUserManager
    {
        public bool Login(UserLoginModel userLoginModel);
    }
}
