using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Periodic.Data;
using Periodic.Models;


namespace Periodic.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IPeriodicRepo _repo;
        private readonly int usr_id;
        
        public AccountController(IPeriodicRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            this._repo = repo;
            
            usr_id = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAllAccounts()
        {
            
            var accs = this._repo.GetAllAccountsByUserId(usr_id);
            return Ok(accs);
        }

        [Route("{acc_id:int}")]
        [HttpGet]
        public ActionResult<Account> GetAccountById([FromRoute]int acc_id)
        {
            return this._repo.GetAccountById(usr_id,acc_id);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody]Account new_acc)
        {
            this._repo.CreateAccount(new_acc);

            return CreatedAtAction("GetAccountById", new{acc_id = new_acc.Id}, new_acc);
        }

        [Route("{acc_id:int}")]
        [HttpPut]
        public ActionResult<Account> UpdateAccount([FromRoute]int acc_id, [FromBody]Account new_acc)
        {
            this._repo.UpdateAccount(new_acc);
            return Ok(new_acc);
        }

        [Route("{acc_id:int}")]
        [HttpDelete]
        public ActionResult DeleteAccount([FromRoute]int acc_id)
        {
            var acc_from_db = this._repo.GetAccountById(usr_id,acc_id);
            if(acc_from_db is null)
            {
                return NotFound($"Account doesn't exist");
            }
            else
            {
                this._repo.DeleteAccount(acc_id);
                return Ok("Account deleted");
            }
            
        }

    }
}