using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginService _loginService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(LoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserVM userVM)
        {
            var user = _loginService.Authenticate(userVM);
            if (user != null)
            {
                var token = _loginService.Generate(user);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
