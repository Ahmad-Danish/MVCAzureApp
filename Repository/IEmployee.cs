using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAzureApp.Models;

namespace MVCAzureApp.Repository
{
    interface IEmployee
    {
        int InsertUpdateEmployee(Employee employee);
        List<Employee> Emplist(int Id);
        Employee GetEmployeeById(int Id);

    }
}
