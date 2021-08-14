using System;
using System.Collections.Generic;

#nullable disable

namespace cmdb.Models
{
    public partial class Role
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }
        public long? DeleteBy { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; }
    }
}
