using System;
using System.Collections.Generic;

namespace BookManagement.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
