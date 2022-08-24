using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Periodic.Controllers
{
    [AllowAnonymous]
    [Route("api/health")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public ActionResult GetStatus()
        {
            return Ok();
        }
    }
}