using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage.Service.Dtos.LoginHistory;
using Storage.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Storage.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILoginHistoryService _historyService;

        public AccountController(ILoginHistoryService historyService)
        {
            _historyService = historyService;
        }

        [AllowAnonymous]
        [HttpPost("checkToken")]
        public bool CheckToken(CheckTokenLoginNeareastDto checkTokenLoginNeareastDto)
        {
            var result = _historyService.CheckTokenLoginNeareast(checkTokenLoginNeareastDto);
            return result;
        }
    }
}