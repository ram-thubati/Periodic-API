using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Periodic.Models;
using Periodic.Data;
using System.Security.Claims;

namespace Periodic.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly int usr_id;
        private IPeriodicRepo _repo;

        public TransactionController(IPeriodicRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            this._repo = repo;

            usr_id = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
        {
            return Ok(this._repo.GetAllTransactionsByuserId(usr_id));
        }

        [Route("{trns_id:int}")]
        [HttpGet]
        public ActionResult<Transaction> GetTransactionById([FromRoute]int trns_id)
        {
            return Ok(this._repo.GetTransactionById(usr_id,trns_id));
        }

        [HttpPost]
        public ActionResult<Transaction> CreateTransaction([FromBody]Transaction trns)
        {
            this._repo.CreateTransaction(trns);
            return CreatedAtAction("GetTransactionById", new{trns_id = trns.Id}, trns);
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
        public ActionResult DeleteTransaction([FromRoute]int trns_id)
        {
            var trns_from_db = this._repo.GetTransactionById(usr_id, trns_id);
            this._repo.DeleteTransaction(trns_from_db);
            return NoContent();
        }
    }

}