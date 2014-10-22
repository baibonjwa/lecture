using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public class CourseInfo
    {
        public int CouresID { set; get; }
        public String CourseName { set; get; }
        public String CourseType { set; get; }
        public String CourseNumer { set; get; }
        private List<ClassInfo> classes = new List<ClassInfo>();
        public List<ClassInfo>  Classes
        {
            set
            {
                classes = Classes;
            }
            get
            {
                return classes;
            }
        }
        public CourseTeacherInfo Teacher { set; get; }

        public void AddClass(ClassInfo c)
        {
            classes.Add(c);
        }

        public void RemoveClass(ClassInfo c)
        {
            classes.Remove(c);
        }
    }
}