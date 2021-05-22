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
    public class StaffController : ControllerBase
    {
        List<Staff> staff = new List<Staff>();
        public StaffController()
        {
            this.staff.Add(new Staff() { Id=1,Name="Rama Rao",Subject="Maths" });
            this.staff.Add(new Staff() { Id = 2, Name = "Sujatha", Subject = "Science" });
            this.staff.Add(new Staff() { Id = 3, Name = "Ravi", Subject = "Social" });
        }

        public IActionResult GetStaff()
        {
            if(this.staff == null)
            {
                return NotFound();
            }
            return Ok(this.staff);
        }

        [Route("{id}")]
        public ActionResult<Staff> GetStaffById(int id =0)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var queriedStaff = this.staff.Where(x => x.Id == id).FirstOrDefault();
            if (queriedStaff == null)
            {
                return NotFound();
            }
            return Ok(queriedStaff);
        }

        [HttpPost("submit")]
        public IActionResult SubmitStaff(Staff staff)
        {
            try
            {
                if (staff.Name == string.Empty)
                {
                    return BadRequest();
                }
                int id = this.staff.Max(x => x.Id) + 1;
                this.staff.Add(new Staff() { Id = id, Name = staff.Name, Subject = staff.Subject });
                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = $"Exception in API {e.Message}" });
            }
        }
    }
}
