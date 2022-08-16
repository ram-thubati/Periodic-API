using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Periodic.Models;
using Periodic.Data;

namespace Periodic.Controllers
{
    [Route("api/users/{usr_id:int}/scheduled")]
    [ApiController]
    public class ScheduledController : ControllerBase
    {
        public ScheduledController(IPeriodicRepo repo)
        {
            this._repo = repo;
        }

        private IPeriodicRepo _repo;

        [HttpGet]
        public ActionResult<IEnumerable<Scheduled>> GetAllScheduledTransactions([FromRoute]int usr_id)
        {
            return Ok(this._repo.GetAllScheduledByUserId(usr_id));
        }

        [Route("{sch_id:int}")]
        [HttpGet]
        public ActionResult<Scheduled> GetScheduledById([FromRoute]int usr_id, [FromRoute]int sch_id)
        {
            return Ok(this._repo.GetScheduledById(usr_id,sch_id));
        }

        [Route("{sch_id:int")]
        [HttpPut]
        public ActionResult UpdateScheduled([FromBody]Scheduled sch)
        {
            this._repo.UpdateSchedule(sch);
            return Ok();
        }

        [HttpPost]
        public ActionResult<Scheduled> CreateScheduled([FromBody]Scheduled new_sch)
        {
            this._repo.CreateSchedule(new_sch);
            return CreatedAtAction("GetScheduledById", new{usr_id = new_sch.Id, sch_id = new_sch.Id}, new_sch);
        }

        [Route("{sch_id:int}")]
        [HttpDelete]
        public ActionResult DeleteScheduled([FromRoute]int usr_id, [FromRoute]int sch_id)
        {
            var sch_db = this._repo.GetScheduledById(usr_id, sch_id);
            this._repo.DeleteSchedule(sch_db);
            return NoContent();
        }
    }
}