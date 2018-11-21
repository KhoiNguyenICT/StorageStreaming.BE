using System;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Storage.Model.Entities.temp;

namespace Storage.Model.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public virtual IEnumerable<RolePermission> Roles { get; internal set; }


    }
}