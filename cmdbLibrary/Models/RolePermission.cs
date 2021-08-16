using System;
using System.Collections.Generic;

#nullable disable

namespace cmdbLibrary.Models
{
    public partial class RolePermission
    {
        public long RolePermissionId { get; set; }
        public long RoleId { get; set; }
        public long PermisionId { get; set; }
        public string IsActive { get; set; }

        public virtual Permission Permision { get; set; }
        public virtual Role Role { get; set; }
    }
}
