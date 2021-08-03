using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public ActionResult<Property> GetProperty(int id)
        {
            Property property = propertyDao.GetProperty(id);

            if (property != null)
            {
                return Ok(property);
            }
            else
            {
                return BadRequest(new { message = "No property associated with that id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddProperty(Property property)
        {
            int propertyId = propertyDao.AddProperty(property);

            if (propertyId != 0)
            {
                return Ok(propertyId);
            }
            else
            {
                return BadRequest(new { message = "Property not successfully created." });
            }
        }

    }
}
