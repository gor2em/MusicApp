using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Entities
{
    public class Role
    {
        public Role()
        {
            UserDetails = new Collection<UserDetail>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
