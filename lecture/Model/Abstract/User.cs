using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public class User
    {
        public int UserId { set; get; }
        public String UserName { set; get; }
        public String RealName { set; get; }
        public String UserTel { set; get; }
        public String UserEmail { set; get; }
        public String UserPassword { set; get; }
        public DepartmentInfo UserDepartment { set; get; }
        public String UserType { get; set; }
        public String UserVerify { get; set; }



        public virtual String GetUserType()
        {
            return UserType;
        }
    }
}