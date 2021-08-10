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

>>>>>>> 5b4f26e15d42f23b9a784ba3206788c761333509
        Employee GetEmployee(int id);

    }
}
