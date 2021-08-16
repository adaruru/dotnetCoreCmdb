using System;
using System.Collections.Generic;

#nullable disable

namespace cmdbLibrary.Models
{
    public partial class Role
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            Users = new HashSet<User>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }
        public long? DeleteBy { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
