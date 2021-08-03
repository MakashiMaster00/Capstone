using System;
using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IImageDao
    {
        List<Image> GetImages(int id);
        int AddImage(Image image);
        int UpdateImage(Image image);
        int DeleteImage(int id);
    }
}
