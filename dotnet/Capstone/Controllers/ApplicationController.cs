using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationDao appdao;
        public ApplicationController(IApplicationDao _appdao)
        {
            appdao = _appdao;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Application>> GetApplications(int id)
        {
            List<Application> app = appdao.GetApplications(id);

            if (app != null)
            {
                return Ok(app);
            }
            else
            {
                return BadRequest(new { message = "No application associated with that id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddApplication(Application app)
        {
            int appId = appdao.AddApplication(app);

            if (appId != 0)
            {
                return Ok(appId);
            }
            else
            {
                return BadRequest(new { message = "Application not successfully created." });
            }
        }

    }
}
