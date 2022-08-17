using Microsoft.AspNetCore.Mvc;
using Periodic.Data;
using Periodic.Helpers;
using Periodic.Models.Requests;

namespace Periodic.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IAuthRepo authrepo)
        {
            this._arepo = authrepo;
        }
        
        private IAuthRepo _arepo;

        [Route("login")]
        [HttpPost]
        public ActionResult<string> LoginUser([FromBody]LoginRequest lreq)
        {
            if(_arepo.LoginUser(lreq))
            {
                var token = "Jwttoken";
                return Ok(token);                
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }

        [Route("signup")]
        [HttpPost]
        public ActionResult SignupUser([FromBody]SignupRequest sreq)
        {
            var status = this._arepo.SignupUser(sreq);
            if(status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}