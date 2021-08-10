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

        Employee GetEmployee(int id);

=======
        Employee GetEmployee(int id);
        int AddEmployee(Employee employee);
        int DeleteEmployee(int id);
>>>>>>> 678510713a4efc2e7d4aa747022741f88e5b3c38
    }
}
