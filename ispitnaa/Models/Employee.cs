using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ispitnaa.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Range(0,99,ErrorMessage = "Age must be between 1 and 99")]
        public int Age { get; set; }

        public string Gender { get; set; }

        public string ImgUrl { get; set; }

        public virtual List<WorkGroup> workGroups { get; set; }

        public List<Absence> absences { get; set; }

        public Employee()
        {
            absences = new List<Absence>();
        }
    }
}