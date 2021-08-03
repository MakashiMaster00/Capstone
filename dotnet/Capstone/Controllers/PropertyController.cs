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

        [HttpPut("{id}")]
        public IActionResult UpdateProperty(Property property, int id)
        {
            int successStatus = 0;

            if (property.PropertyId == id)
            {
                successStatus = propertyDao.UpdateProperty(property);
            }
            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Property not successfully updated." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            int successStatus = 0;

            successStatus = propertyDao.DeleteProperty(id);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Property not successfully deleted." });
            }
        }

        [HttpGet("{id}/images")]
        public ActionResult<Property> GetImages(int id)
        {
            List<Image> images = propertyDao.GetImages(id);

            if (images.Count != 0)
            {
                return Ok(images);
            }
            else
            {
                return BadRequest(new { message = "No images associated with that property id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddImage(Image image)
        {
            int imageId = propertyDao.AddImages(image);

            if (imageId != 0)
            {
                return Ok(imageId);
            }
            else
            {
                return BadRequest(new { message = "Image not successfully created." });
            }
        }

        [HttpPut("{id}/images")]
        public IActionResult UpdateImage(Image image, int id)
        {
            int successStatus = 0;

            if (image.ImageId == id)
            {
                successStatus = propertyDao.UpdateImages(image);
            }
            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Image not successfully updated." });
            }
        }

        [HttpDelete("{id}/images")]
        public IActionResult DeleteImage(int id)
        {
            int successStatus = 0;

            successStatus = propertyDao.DeleteImages(id);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Image not successfully deleted." });
            }
        }
    }
}
