using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;

namespace lecture.Model.Entities
{
    public class CourseTeacherInfo : Person
    {
        public String teacherNumer;

        public override String GetTeacher()
        {
            String teachMessage = "";
            teachMessage = "<" + teacherNumer + ">" + PersonName;
            return teachMessage;
        }
    }
}