using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Model;
using Storage.Model.Entities;
using Storage.Service.Dtos.LoginHistory;
using Storage.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Storage.Service.Implementations
{
    public class RoleService: BaseService<Role>, IRoleService
    {
        public RoleService(AppDbContext context) : base(context)
        {
        }

       
    }
}