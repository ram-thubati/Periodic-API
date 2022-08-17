using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Periodic.Data;
using Periodic.Models;


namespace Periodic.Controllers
{
    [Route("api/users/{usr_id:int}/Accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(IPeriodicRepo repo)
        {
            this._repo = repo;
        }

        private IPeriodicRepo _repo;


        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAllAccountsByUserId([FromRoute]int usr_id)
        {
            var accs = this._repo.GetAllAccountsByUserId(usr_id);
            return Ok(accs);
        }

        [Route("{acc_id:int}")]
        [HttpGet]
        public ActionResult<Account> GetAccountById([FromRoute]int usr_id, [FromRoute]int acc_id)
        {
            return this._repo.GetAccountById(usr_id,acc_id);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody]Account new_acc)
        {
            this._repo.CreateAccount(new_acc);

            return CreatedAtAction("GetAccountById", new{usr_id = new_acc.UserId, acc_id = new_acc.Id}, new_acc);
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
        public ActionResult DeleteAccount([FromRoute]int usr_id, [FromRoute]int acc_id)
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