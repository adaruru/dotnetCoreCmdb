using System;
using System.Collections.Generic;

#nullable disable

namespace cmdb.Models
{
    public partial class User
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsVarify { get; set; }
        public long? DeleteBy { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string PasswordHash { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
