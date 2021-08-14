using System;
using System.Collections.Generic;

#nullable disable

namespace cmdb.Models
{
    public partial class RolePermission
    {
        public string RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public string PermisionId { get; set; }
        public string IsActive { get; set; }
    }
}
