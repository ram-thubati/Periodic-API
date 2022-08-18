using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Periodic.Data;
using Periodic.Helpers;
using Periodic.Models.Requests;

namespace Periodic.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
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
            try
            {
                var token = this._arepo.LoginUser(lreq);
                return Ok(token);
            }
            catch(Exception e)
            {
                return Unauthorized("Invalid credentials");
            }
        }

        [Route("signup")]
        [HttpPost]
        public ActionResult SignupUser([FromBody]SignupRequest sreq)
        {
            try
            {
                this._arepo.SignupUser(sreq);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
            
        }

    }
}