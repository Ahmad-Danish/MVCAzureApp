using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAzureApp.Models;

namespace MVCAzureApp.Repository
{
    interface IDesignation
    {
        int InsertUpdateDesignation(Designation designation);
        string IsDesignationExist(Designation designation);
        List<Designation> DesignationList();
        Designation GetDesignationById(int id);
        List<Designation> DDLdesignations();
    }
}
