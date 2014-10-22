using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;

namespace lecture.Model.Entities
{
    public class SystemUser : User
    {

    }
    public class Student : User
    {
        public Student()
        {
            UserType = "学生";
        }

        public override String GetUserType()
        {
            return UserType;
        }
    }

    public class Teacher : User
    {
        public TeacherTypeInfo teacherType { get; set; }
        public String TeacherNum { get; set; }
        public Teacher()
        {
            UserType = "听课教师";
        }

        public override String GetUserType()
        {
            return UserType;
        }
        public String GetTeacherType()
        {
            return teacherType.TeacherType;
        }
        public int GetTeacherTypeID()
        {
            return teacherType.TeacherTypeID;
        }
    }

    public class TeacherManage : Teacher
    {
        public TeacherManage()
        {
            UserType = "学生工作人员";
        }

        public override String GetUserType()
        {
            return UserType;
        }
    }

    public class SystemManage : User
    {
        public SystemManage()
        {
            UserType = "系统管理员";
        }

        public override String GetUserType()
        {
            return UserType;
        }
    }
}