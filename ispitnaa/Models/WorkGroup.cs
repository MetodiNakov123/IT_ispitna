using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ispitnaa.Models
{
    public class WorkGroup
    {
        [Key]
        public int WorkGroupId { get; set; }

        public string Name { get; set; }

        public virtual List<Employee> employees { get; set; }
    }
}