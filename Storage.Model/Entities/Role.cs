using Storage.Model.Entities.temp;
using System.Collections.Generic;

namespace Storage.Model.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<RolePermission> Permissions { get; internal set; }
    }
}