using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using AmritERP.Behaviour.Login;
using AmritERP.Model;
using Microsoft.AspNetCore.Mvc;

namespace AmritERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        [HttpGet]
        public ActionResult checkServerRunning(){
            return new JsonResult(Ok("EverthingFine"));
        }

        // [HttpPost]
        // public ActionResult<object> updateLogin([FromBody] TblLogin data)
        // {
        //     loginContract invoke = new loginContract();
        //     return invoke.updateLogin(data);
        // }
        // [HttpPost]
        // public ActionResult<object> checkLogin([FromBody] loginCheckOBJ data)
        // {
        //     loginContract invoke = new loginContract();
        //     return invoke.checkLogin(data);
        // }
    }
}

