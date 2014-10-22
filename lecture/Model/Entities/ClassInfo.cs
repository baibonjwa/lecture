using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public class ClassInfo
    {
        public int ClassId { set; get; }
        public String ClassName { set; get; }
        public MajorInfo ClassMajor { set; get; }
        public DepartmentInfo ClassDep { set; get; }
        public int IsStop { set; get; }
    }
}