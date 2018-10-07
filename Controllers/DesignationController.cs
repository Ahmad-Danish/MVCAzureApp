using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAzureApp.Models;
using MVCAzureApp.Repository;

namespace MVCAzureApp.Controllers
{
    public class DesignationController : Controller
    {
        IDesignation objDesignation;
        public DesignationController()
        {
            objDesignation = new Designationdata();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult IsDesignationExist(Designation designation)
        {
            string isexists = string.Empty;
            if (designation.DesignationName != "")
            {
                isexists = objDesignation.IsDesignationExist(designation);
            }
            return Json(isexists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDesignation(Designation designation)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                id = objDesignation.InsertUpdateDesignation(designation);
                //return RedirectToAction("Departmentlist");
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DesignationList()
        {
            //List<Designation> designations = objDesignation.DesignationList();
            //return View(designations);
            return View();
        }

        public ActionResult DesgList()
        {
            List<Designation> designations = objDesignation.DesignationList();
            return Json(designations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDesignationById(Designation designation)
        {
            Designation desig = new Designation();
            if (designation.DesigId > 0)
            {
                desig = objDesignation.GetDesignationById(designation.DesigId);
            }
            return Json(desig, JsonRequestBehavior.AllowGet);
        }

    }
}
