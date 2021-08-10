using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEmployeeDao
    {
        List<Employee> GetEmployeesByLandlordId(int id);

        int AddEmployee(Employee employee);
        int DeleteEmployee(int id);
        Employee GetEmployee(int id);

    }
}
