using System;
using System.Collections.Generic;

#nullable disable

namespace cmdbLibrary.Models
{
    public partial class UserPermission
    {
        public long UserPermissionId { get; set; }
        public long UserId { get; set; }
        public long PermisionId { get; set; }
        public string IsActive { get; set; }

        public virtual Permission Permision { get; set; }
        public virtual User User { get; set; }
    }
}
