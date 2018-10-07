using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAzureApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        public string DOB { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "JoiningDate is required")]
        public string JoiningDate { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string DepartmentID { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string DesignationID { get; set; }

        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
    }
}