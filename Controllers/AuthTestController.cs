using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Periodic.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("/api/test")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthTestController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public ActionResult<string> GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var role = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return Ok(userId + role);
        }

    }
}