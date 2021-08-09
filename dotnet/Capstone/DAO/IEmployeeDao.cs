using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEmployeeDao
    {
        List<Employee> GetEmployeesByLandlordId(int id);
<<<<<<< HEAD
        
=======
        Employee GetEmployee(int id);
>>>>>>> 79a479e45fb9c18f04f72c3c5cb21a64859bee0c
    }
}
