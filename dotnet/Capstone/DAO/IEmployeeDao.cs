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
>>>>>>> 56ae40c4737e86c1d42e794bbe7d9646363fda05
        Employee GetEmployee(int id);

    }
}
