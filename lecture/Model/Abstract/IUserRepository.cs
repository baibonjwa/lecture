using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IUserRepository
    {
        Boolean AddUser(User u);
        Boolean AddUser(Teacher u);
        Boolean UpdateUser(User u);
        Boolean UpdateUser(Teacher u);
        Boolean UpdateUserState(User u);
        Boolean ChangePassword(int userid, string OldPassword, string NewPassword);
        Boolean DeleteUser(int id);
        User GetUserByName(String userName);
        User GetUserByRealName(String realName);
        List<Teacher> GetUserByVerify(String userVerify, String userDepartmentID);

        User GetUserByID(int ID);
        Teacher GetTeacherByID(int ID);
        List<Teacher> GetTeacherByName(String name);
        List<Teacher> GetTeacherByName2(String name);
        Teacher GetTeacherByNum(String num);
        List<User> GetUsers();

        Boolean GetPwdAndName(String userName, String pwd);
    }
}