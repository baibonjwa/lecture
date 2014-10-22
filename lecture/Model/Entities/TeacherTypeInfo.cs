using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{

    //教师类型表的实体类
    public class TeacherTypeInfo
    {
        public int TeacherTypeID { set; get; }
        public String TeacherType { set; get; }
        public int IsStop { set; get; }

    }
}