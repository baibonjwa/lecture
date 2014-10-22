using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public class DepartmentInfo
    {
        public int DepId { set; get; }
        public String DepName { set; get; }
        public String DepType { set; get; }
        public String IsStop { set; get; }
    }
}