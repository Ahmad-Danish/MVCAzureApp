using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAzureApp.Models
{
    public class Department
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage="Department Name is required")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string DepartmentDesc { get; set; }
    }
}