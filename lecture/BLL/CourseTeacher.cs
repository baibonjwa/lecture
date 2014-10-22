using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using lecture.Model.Concrete;
using Ninject;

namespace lecture.BLL
{
    public class CourseTeacher : ICourseTeacher
    {
        [Inject]
        public ICourseTeacherRepository ictr { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddCourseTeacher(CourseTeacherInfo lr)
        {
            log.LogWriteByClass("执行AddCourseTeacher()操作 时间：" + DateTime.Now.ToString() + "", "CourseTeacher");
            return ictr.AddCourseTeacher(lr);
        }

        public Boolean RemoveCourseTeacher(int lr)
        {
            return ictr.RemoveCourseTeacher(lr);
        }

        public Boolean UpdateCourseTeacher(CourseTeacherInfo lr)
        {
            return ictr.UpdateCourseTeacher(lr);
        }

        public CourseTeacherInfo GetCourseTeacherByID(int Id)
        {
            return ictr.GetCourseTeacherByID(Id);
        }

        public List<CourseTeacherInfo> GetAllCourseTeacher()
        {
            return ictr.GetAllCourseTeacher();
        }
    }
}