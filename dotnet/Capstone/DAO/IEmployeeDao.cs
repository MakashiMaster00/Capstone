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

>>>>>>> e5327ec3320e425ba71d25f7ffd554c3153a5c38
        Employee GetEmployee(int id);

    }
}
