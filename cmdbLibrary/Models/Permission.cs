using System;
using System.Collections.Generic;

#nullable disable

namespace cmdbLibrary.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public long PermisionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDes { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
