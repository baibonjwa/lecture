using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ICourseTeacher
    {
        Boolean AddCourseTeacher(CourseTeacherInfo lr);

        Boolean RemoveCourseTeacher(int id);

        Boolean UpdateCourseTeacher(CourseTeacherInfo lr);

        CourseTeacherInfo GetCourseTeacherByID(int Id);

        List<CourseTeacherInfo> GetAllCourseTeacher();
    }
}