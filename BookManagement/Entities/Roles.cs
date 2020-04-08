using System;
using System.Collections.Generic;

namespace BookManagement.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
