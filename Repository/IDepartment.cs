using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAzureApp.Models;

namespace MVCAzureApp.Repository
{
    interface IDepartment
    {
        int InsertUpdateDepartment(Department department);
        string IsDepartmentExists(Department departmentName);
        List<Department> DepartmentList();
        Department GetDepartmentById(int id);
        List<Department> DDLdepartments();
    }
}
