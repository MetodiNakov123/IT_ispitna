using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ispitnaa.Models
{
    public class AddWorkGroupModel
    {
        public int EmployeeId { get; set; }

        public int WorkGroupId { get; set; }

        public List<WorkGroup> workGroups { get; set; }

        public AddWorkGroupModel()
        {
            workGroups = new List<WorkGroup>();
        }
    }
}