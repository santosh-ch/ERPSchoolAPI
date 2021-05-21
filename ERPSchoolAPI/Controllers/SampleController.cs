using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SampleController:ControllerBase
    {
        public string Get()
        {
            return "Sample controller - Get";
        }

        [Route("~/read/{name}")]
        [Route("~/msg")]
        [Route("~/api/[controller]/[action]")]
        public string GetMsg(string name = "No Name")
        {
            return $"Sample controller - GetMsg {name}";
        }

        [Route("{id:range(5,9)}")]
        public string GetRange(int id = 0)
        {
            return $"Sample controller - GetRange my number is {id}";
        }

        [Route("{str:regex(^[[\\d]]*)}")]
        public string GetStr(string str = "")
        {
            return $"Sample controller - GetStr my string is {str}";
        }

    }
}
