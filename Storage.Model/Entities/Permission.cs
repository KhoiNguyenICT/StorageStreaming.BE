using System.Collections.Generic;
using Storage.Model.Entities.temp;

namespace Storage.Model.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }    
    }
}