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
<<<<<<< HEAD
=======

>>>>>>> 6f78c1d0d7e7a7c1d352af72643cc3790bb12b4c
    }
}
