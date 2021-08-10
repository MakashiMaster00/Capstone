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
        int AddEmployee(int id, Employee employee);
        int DeleteEmployee(int landlordId, int employeeId);
        Employee GetEmployee(int id);

>>>>>>> 9ce49f4f53c3345e01dc75d97b71bb81aea3b182
    }
}
