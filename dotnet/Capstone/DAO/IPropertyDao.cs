using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPropertyDao
    {
        List<Property> GetProperties();
        Property GetProperty(int id);
        int AddProperty(Property property);
        int UpdateProperty(Property property);
        int DeleteProperty(int id);
        List<Image> GetImages(int id);

        int AddImages(Image image);

        int UpdateImages(Image image);

        int DeleteImages(int id);
    }

}
