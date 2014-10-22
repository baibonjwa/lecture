using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;
using lecture.Model.Abstract;
using Ninject;

namespace lecture.BLL
{
    public class Course : ICourse
    {
        [Inject]
        public ICourseRepository icr { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddCourse(CourseInfo lr)
        {
            log.LogWriteByClass("执行AddCourse()操作 时间：" + DateTime.Now.ToString() + "", "Course");
            return icr.AddCourse(lr);
        }

        public Boolean RemoveCourse(int id)
        {
            CourseInfo ci = icr.GetCourseByID(id);
            string cl = "";
            for (int i = 0; i < ci.Classes.Count; i++)
            {
                cl += ci.Classes[i].ClassId + "|";
            }
            cl = cl.Substring(0, cl.Length - 1);
            log.LogWriteByClass("执行AddCourse()操作 CourseName: " + ci.CourseName.ToString() + " CourseType: " + ci.CourseType.ToString() + " Classes: " + cl.ToString() + " Teacher: " + ci.Teacher.ToString() + " 时间：" + DateTime.Now.ToString() + "", "Course");
            return icr.RemoveCourse(id);
        }

        public Boolean UpdateCourse(CourseInfo lr)
        {
            return icr.UpdateCourse(lr);
        }

        public CourseInfo GetCourseByID(int Id)
        {
            return icr.GetCourseByID(Id);
        }

        public CourseInfo GetCourseByNumer(String Numer)
        {
            return icr.GetCourseByNumer(Numer);
        }

        public List<CourseInfo> GetAllCourse()
        {
            return icr.GetAllCourse();
        }
    }
}