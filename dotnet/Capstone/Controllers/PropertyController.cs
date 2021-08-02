using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyDao propertyDao;

        public PropertyController(IPropertyDao _propertyDao)
        {
            propertyDao = _propertyDao;
        }

        [HttpGet]
        public ActionResult<List<Property>> GetProperties()
        {
            List<Property> properties = propertyDao.GetProperties();

            if (properties.Count != 0)
            {
                return Ok(properties);
            }
            else
            {
                return BadRequest(new { message = "No properties found" });
            }
        }

    }
}
