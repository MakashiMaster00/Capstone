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

        int AddEmployee(Employee employee);
        int DeleteEmployee(int id);
=======
<<<<<<< HEAD
=======

>>>>>>> e5327ec3320e425ba71d25f7ffd554c3153a5c38
>>>>>>> f17c4890d7c639f400b4a232d8c8a4aa4583fb9f
        Employee GetEmployee(int id);

    }
}
