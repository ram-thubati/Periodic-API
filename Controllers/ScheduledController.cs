using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Periodic.Models;
using Periodic.Data;
using System.Security.Claims;

namespace Periodic.Controllers
{
    [Route("api/scheduled")]
    [ApiController]
    public class ScheduledController : ControllerBase
    {
        private readonly int usr_id;
        
        private IPeriodicRepo _repo;
        
        public ScheduledController(IPeriodicRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            this._repo = repo;
            
            usr_id = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Scheduled>> GetAllScheduledTransactions()
        {
            return Ok(this._repo.GetAllScheduledByUserId(usr_id));
        }

        [Route("{sch_id:int}")]
        [HttpGet]
        public ActionResult<Scheduled> GetScheduledById([FromRoute]int sch_id)
        {
            return Ok(this._repo.GetScheduledById(usr_id,sch_id));
        }

        [Route("{sch_id:int}")]
        [HttpPut]
        public ActionResult<Scheduled> UpdateScheduled([FromRoute]int sch_id, [FromBody]Scheduled new_sch)
        {
            this._repo.UpdateSchedule(sch_id, new_sch);
            return Ok(new_sch);
        }

        [HttpPost]
        public ActionResult<Scheduled> CreateScheduled([FromBody]Scheduled new_sch)
        {
            this._repo.CreateSchedule(new_sch);
            return CreatedAtAction("GetScheduledById", new{sch_id = new_sch.Id}, new_sch);
        }

        [Route("{sch_id:int}")]
        [HttpDelete]
        public ActionResult DeleteScheduled([FromRoute]int sch_id)
        {
            var sch_db = this._repo.GetScheduledById(usr_id, sch_id);
            this._repo.DeleteSchedule(sch_db);
            return NoContent();
        }
    }
}