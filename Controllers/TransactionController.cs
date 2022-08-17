using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Periodic.Models;
using Periodic.Data;

namespace Periodic.Controllers
{
    [Route("api/users/{usr_id:int}/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController(IPeriodicRepo repo)
        {
            this._repo = repo;
        }

        private IPeriodicRepo _repo;

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactionsByUserId([FromRoute]int usr_id)
        {
            return Ok(this._repo.GetAllTransactionsByuserId(usr_id));
        }

        [Route("{trns_id:int}")]
        [HttpGet]
        public ActionResult<Transaction> GetTransactionById([FromRoute]int usr_id, [FromRoute]int trns_id)
        {
            return Ok(this._repo.GetTransactionById(usr_id,trns_id));
        }

        [HttpPost]
        public ActionResult<Transaction> CreateTransaction([FromBody]Transaction trns)
        {
            this._repo.CreateTransaction(trns);
            return CreatedAtAction("GetTransactionById", new{usr_id = trns.UserId, trns_id = trns.Id}, trns);
        }

        [Route("{trns_id:int}")]
        [HttpPut]
        public ActionResult<Transaction> UpdateTransaction(Transaction trns)
        {
            this._repo.CreateTransaction(trns);
            return Ok(trns);
        }

        [Route("{trns_id:int}")]
        [HttpDelete]
        public ActionResult DeleteTransaction([FromRoute]int usr_id, [FromRoute]int trns_id)
        {
            var trns_from_db = this._repo.GetTransactionById(usr_id, trns_id);
            this._repo.DeleteTransaction(trns_from_db);
            return NoContent();
        }
    }

}