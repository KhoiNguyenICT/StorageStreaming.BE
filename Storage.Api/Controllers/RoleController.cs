using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Common.Errors;
using Storage.Model.Entities;
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

        [HttpPost]
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

        [HttpPut]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] Role request)
        {
            if (ModelState.IsValid)
                try
                {
                    await _roleService.Update(request);
                }
                catch (Exception e)
                {
                    throw new CustomException(e.Message);
                }

            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            throw new CustomException(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            try
            {
                var result = await _roleService.Get(id);
                if (result != null)
                {
                    await _roleService.Remove(id);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                throw new CustomException(e.Message);
            }

            return Ok();
        }
    }
}