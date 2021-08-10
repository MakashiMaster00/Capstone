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
>>>>>>> 9186cc0b4d4056ab1ee4b1fd3e3c4b403cb2c423

        Employee GetEmployee(int id);

        int AddEmployee(Employee employee);
<<<<<<< HEAD
        int DeleteEmployee(int id);




        Employee GetEmployee(int id);
=======
>>>>>>> 9186cc0b4d4056ab1ee4b1fd3e3c4b403cb2c423

        int DeleteEmployee(int id);
    }
}
