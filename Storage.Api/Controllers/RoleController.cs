using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Common.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Common.Constants;
using Storage.Model;
using Storage.Model.Entities;
using Storage.Service.Dtos;
using Storage.Service.Interfaces;

namespace Storage.Api.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddRoleAsync([FromBody] Role request)
        {
            if (ModelState.IsValid)
                try
                {
                    var result = await _roleService.Add(request);
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }

            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return StatusCode(StatusCodes.Status400BadRequest, message);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] Role request)
        {
            if (ModelState.IsValid)
                try
                {
                    await _roleService.Update(request);
                    return new BaseResponse<Role>(Messages.UPDATE_SUCCESSFULLY, StatusCodes.Status202Accepted, request);
                }
                catch (Exception e)
                {
                    return new BaseResponse<Role>(Messages.INTERNAL_ERROR + Environment.NewLine + e.Message, StatusCodes.Status500InternalServerError, request);
                }

            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return new BaseResponse<Role>(message, StatusCodes.Status400BadRequest, request);
        }
        [HttpDelete("/{roleGuid}")]
        public async Task<IActionResult> DeleteRoleAsync(Guid roleGuid)
        {
            try
            {
                var result = await _roleService.Get(roleGuid);
                if (result != null)
                {
                    await _roleService.Remove(roleGuid);
                    return new BaseResponse<Guid>(Messages.DELETE_SUCCESSFULLY, StatusCodes.Status202Accepted, roleGuid);

                }
                return new BaseResponse<Guid>(Messages.INTERNAL_ERROR, StatusCodes.Status500InternalServerError, roleGuid);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse<Guid>(Messages.INTERNAL_ERROR + Environment.NewLine + e.Message, StatusCodes.Status500InternalServerError, roleGuid);
            }
            //Check isExist roleGuId

        }
    }
}