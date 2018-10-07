using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAzureApp.Models;
using MVCAzureApp.Repository;

namespace MVCAzureApp.Controllers
{
    public class EmployeeController : Controller
    {
        IDepartment objDepartment;
        IDesignation objDesignation;
        IEmployee objEmp;

        public EmployeeController()
        {
            objDepartment = new Departmentdata();
            objDesignation = new Designationdata();
            objEmp = new Employeedata();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult DDLDepartments()
        {
            List<Department> departments = objDepartment.DDLdepartments();
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DDLDesignation()
        {
            List<Designation> designations = objDesignation.DDLdesignations();
            return Json(designations, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddEmployee(Employee employee)
        {

            if (ModelState.IsValid)
            {
                int id = objEmp.InsertUpdateEmployee(employee);
                var results = new { Status = "success" };
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray();

                var results = new { Status = "fail", errors };
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult getEmployees(Employee employee)
        {
            if (employee.Id == 0)
            {
                List<Employee> emplist = objEmp.Emplist(employee.Id);
                return Json(emplist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Employee emp = objEmp.Emplist(employee.Id).SingleOrDefault();
                return Json(emp, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
