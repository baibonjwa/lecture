using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public class MajorInfo
    {
        public int MajorId { set; get; }
        public String MajorName { set; get; }
        public DepartmentInfo MajorDepartment { set; get; }
        public int IsStop { set; get; }
    }
}