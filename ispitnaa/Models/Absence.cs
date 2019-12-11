using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ispitnaa.Models
{
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; }

        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public bool isApproved { get; set; }

        public Absence()
        {
            isApproved = false;
        }
    }
}