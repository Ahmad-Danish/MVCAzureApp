using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAzureApp.Models;
using MVCAzureApp.Repository;

namespace MVCAzureApp.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartment objDepartment;

        public DepartmentController()
        {
            objDepartment = new Departmentdata();
        }
       

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddDepartment(Department department)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                id = objDepartment.InsertUpdateDepartment(department);
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Departmentlist()
        {
            return View();           
        }

        public ActionResult DeptList()
        {
            List<Department> department = objDepartment.DepartmentList();
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsDepartmentExists(Department department)
        {
            string isexists = string.Empty;
            if (department.DepartmentName != "")
            {
                isexists = objDepartment.IsDepartmentExists(department);
            }
            return Json(isexists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartmentById(Department depart)
        {
            Department department = new Department();
            if (depart.Id > 0)
            {
                department = objDepartment.GetDepartmentById(depart.Id);
            }
            return Json(department, JsonRequestBehavior.AllowGet);


        }


        public ActionResult Test()
        {
            return View();
        }

    }
}
