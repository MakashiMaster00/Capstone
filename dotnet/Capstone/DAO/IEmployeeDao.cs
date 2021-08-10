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
>>>>>>> 48b37900699ef7a972b3f21627118b00ac2e9bc3
        Employee GetEmployee(int id);
        int AddEmployee(Employee employee);
<<<<<<< HEAD

        int DeleteEmployee(int id);




=======
        int DeleteEmployee(int id);
>>>>>>> 48b37900699ef7a972b3f21627118b00ac2e9bc3
    }
}
