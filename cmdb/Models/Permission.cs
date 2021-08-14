using System;
using System.Collections.Generic;

#nullable disable

namespace cmdb.Models
{
    public partial class Permission
    {
        public long PermisionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDes { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
