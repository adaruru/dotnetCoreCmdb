using System;
using System.Collections.Generic;

#nullable disable

namespace cmdb.Models
{
    public partial class UserPermission
    {
        public int UserId { get; set; }
        public string PermisionId { get; set; }
        public string IsActive { get; set; }
        public string UserPermissionId { get; set; }
    }
}
