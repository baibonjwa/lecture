using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public class TargetInfo
    {
        public int TargetID { set; get; }
        public int Week { set; get; }
        public int Count { set; get; }
        public TeacherTypeInfo TeacherTypeID { set; get; }
    }
}