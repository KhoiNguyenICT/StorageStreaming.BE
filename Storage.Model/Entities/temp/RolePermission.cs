using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Model.Entities.temp
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
