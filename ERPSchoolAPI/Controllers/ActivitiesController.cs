using ERPSchoolAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    public class ActivitiesController : ControllerBase
    {
        public Activity Activity { get; set; }
        List<Activity> Activities = new List<Activity>();
        public ActivitiesController()
        {
            this.Activities.Add(new Activity() { Id = 1, ActivityName = "Swimming" });
            this.Activities.Add(new Activity() { Id = 2, ActivityName = "Drama" });
            this.Activities.Add(new Activity() { Id = 3, ActivityName = "Cricket" });
            this.Activities.Add(new Activity() { Id = 4, ActivityName = "Hockey" });
        }

        [HttpPost]
        public ActionResult<string> AddActivity()
        {
            this.Activities.Add(this.Activity);
            return Ok(this.Activity.ActivityName);
        }

        [HttpGet]
        public ActionResult<string> GetActivities([ModelBinder(typeof(IntegerArrayBinder))]int[] ids)
        {
            try
            {
                List<Activity> currentActivities = new List<Activity>();
                for (int i = 0; i < ids.Length; i++)
                {
                    var activity = this.Activities.Find(x => x.Id == ids[i]);
                    if (activity != null)
                    {
                        currentActivities.Add(activity);
                    }
                }
                    return Ok(currentActivities);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
