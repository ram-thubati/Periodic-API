using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Periodic.Data;
using Periodic.Helpers;
using Periodic.Models.Requests;
using Periodic.Models.Responses;

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
        public ActionResult<LoginResponse> LoginUser([FromBody]LoginRequest lreq)
        {
            try
            {
                var resp = this._arepo.LoginUser(lreq);
                return Ok(resp);
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