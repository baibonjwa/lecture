using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;


namespace lecture.Model.Abstract
{
    public interface ICourse
    {
        Boolean AddCourse(CourseInfo lr);

        Boolean RemoveCourse(int id);

        Boolean UpdateCourse(CourseInfo lr);

        CourseInfo GetCourseByID(int Id);
        CourseInfo GetCourseByNumer(String Id);

        List<CourseInfo> GetAllCourse();
    }
}