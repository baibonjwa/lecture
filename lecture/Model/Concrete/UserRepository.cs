using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace lecture.Model.Concrete
{
    public class UserRepository : IUserRepository
    {
        List<User> ausers = new List<User>();

        public Boolean AddUser(User u)
        {
            string sql = "insert into tb_user values(@userName,@realName,@userTel,@userEmail,@userPassword,@userDepartmentID,@userType,@UserVerify)";
            SqlParameter userName = new SqlParameter("@userName", u.UserName);
            SqlParameter realName = new SqlParameter("@realName", u.RealName);
            SqlParameter userTel = new SqlParameter("@userTel", u.UserTel);
            SqlParameter userEmail = new SqlParameter("@userEmail", u.UserEmail);
            SqlParameter userPassword = new SqlParameter("@userPassword", u.UserPassword);
            SqlParameter userDepartmentID = new SqlParameter("@userDepartmentID", u.UserDepartment.DepId);
            SqlParameter userType = new SqlParameter("@userType", u.UserType);
            SqlParameter UserVerify = new SqlParameter("@UserVerify", u.UserVerify);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userName, realName, userTel, userEmail, userPassword, userDepartmentID, userType, UserVerify);
            return true;
        }
        public Boolean AddUser(Teacher u)
        {
            string sql = "insert into tb_user values(@userName,@realName,@userTel,@userEmail,@userPassword,@userDepartmentID,@userType,@userVerify);select @@IDENTITY as 'identity'";
            SqlParameter userName = new SqlParameter("@userName", u.UserName);
            SqlParameter realName = new SqlParameter("@realName", u.RealName);
            SqlParameter userTel = new SqlParameter("@userTel", u.UserTel);
            SqlParameter userEmail = new SqlParameter("@userEmail", u.UserEmail);
            SqlParameter userPassword = new SqlParameter("@userPassword", u.UserPassword);
            SqlParameter userDepartmentID = new SqlParameter("@userDepartmentID", u.UserDepartment.DepId);
            SqlParameter userType = new SqlParameter("@userType", u.UserType);
            SqlParameter userVerify = new SqlParameter("@UserVerify", u.UserVerify);
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, userName, realName, userTel, userEmail, userPassword, userDepartmentID, userType, userVerify));


            sql = "insert into tb_teacher values(@userID,@teacherTypeID,@teacherNum)";
            SqlParameter userID = new SqlParameter("@userID", count);
            SqlParameter teacherTypeID = new SqlParameter("@teacherTypeID", u.GetTeacherTypeID());
            SqlParameter teacherNum = new SqlParameter("@teacherNum", u.TeacherNum);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userID, teacherTypeID, teacherNum);
            return true;
        }

        public Boolean UpdateUser(User u)
        {
            string sql = "update  tb_user set userName=@userName,realName=@realName,userTel=@userTel,userEmail=@userEmail,userPassword=@userPassword,userDepartmentID=@userDepartmentID,userType=@userType,userVerify=@userVerify where userid=@userid";
            SqlParameter userid = new SqlParameter("@userid", u.UserId);
            SqlParameter userName = new SqlParameter("@userName", u.UserName);
            SqlParameter realName = new SqlParameter("@realName", u.RealName);
            SqlParameter userTel = new SqlParameter("@userTel", u.UserTel);
            SqlParameter userEmail = new SqlParameter("@userEmail", u.UserEmail);
            SqlParameter userPassword = new SqlParameter("@userPassword", u.UserPassword);
            SqlParameter userDepartmentID;
            if (u.UserDepartment == null)
            {
                userDepartmentID = new SqlParameter("@userDepartmentID", null);
            }
            else
            {
                userDepartmentID = new SqlParameter("@userDepartmentID", u.UserDepartment.DepId);
            }
            SqlParameter userType = new SqlParameter("@userType", u.UserType);
            SqlParameter userVerify = new SqlParameter("@UserVerify", u.UserVerify);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userid, userName, realName, userTel, userEmail, userPassword, userDepartmentID, userType, userVerify);
            return true;
        }
        public Boolean UpdateUserState(User u)
        {
            string sql = "update  tb_user set userVerify=@userVerify where userid=@userid";
            SqlParameter userid = new SqlParameter("@userid", u.UserId);
            SqlParameter userVerify = new SqlParameter("@UserVerify", u.UserVerify);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userid, userVerify);
            return true;
        }
        public Boolean ChangePassword(int userid, string OldPassword, string NewPassword)
        {
            string sqlselect = "select * from tb_user where userid=@userid and userPassword=@userPassword";
            SqlParameter userid1 = new SqlParameter("@userid", userid);
            SqlParameter userPassword = new SqlParameter("@userPassword", OldPassword);
            SqlDataReader dr = (SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sqlselect, userid1, userPassword));

            if (dr.Read())
            {
                string sql = "update  tb_user set userPassword=@NewPassword where userid=@userid";
                SqlParameter userid2 = new SqlParameter("@userid", userid);
                SqlParameter NewPassword0 = new SqlParameter("@NewPassword", NewPassword);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userid2, NewPassword0);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean UpdateUser(Teacher u)
        {
            string sql = "update tb_user set userName=@userName,realName=@realName,userTel=@userTel,userEmail=@userEmail,userDepartmentID=@userDepartmentID,userType=@userType where userid=@userid";
            SqlParameter userid = new SqlParameter("@userid", u.UserId);
            SqlParameter userName = new SqlParameter("@userName", u.UserName);
            SqlParameter realName = new SqlParameter("@realName", u.RealName);
            SqlParameter userTel = new SqlParameter("@userTel", u.UserTel);
            SqlParameter userEmail = new SqlParameter("@userEmail", u.UserEmail);
            //SqlParameter userPassword = new SqlParameter("@userPassword", u.UserPassword);
            SqlParameter userDepartmentID = new SqlParameter("@userDepartmentID", u.UserDepartment.DepId);
            SqlParameter userType = new SqlParameter("@userType", u.UserType);
            //SqlParameter userVerify = new SqlParameter("@UserVerify", u.UserVerify);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userid, userName, realName, userTel, userEmail, userDepartmentID, userType);

            sql = "update tb_teacher set teacherTypeID=@teacherTypeID,teacherNum=@teacherNum where userID=@userID";
            SqlParameter userID = new SqlParameter("@userID", u.UserId);
            SqlParameter teacherTypeID = new SqlParameter("@teacherTypeID", u.teacherType.TeacherTypeID);
            SqlParameter teacherNum = new SqlParameter("@teacherNum", u.TeacherNum);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, userID, teacherTypeID, teacherNum);

            return true;
        }
        public Boolean DeleteUser(int id)
        {
            string sql = "delete from tb_user where userId=@rid";
            SqlParameter rid = new SqlParameter("@rid", id);
            // int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql,rid));
            SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, rid);

            sql = "delete from tb_teacher where userId=@iid";
            SqlParameter iid = new SqlParameter("@iid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, iid);
            return true;
        }

        public User GetUserByName(String userName)
        {
            User user = null;
            string sql = "select * from tb_user where userName=@userName";
            SqlParameter paramID = new SqlParameter("@userName", userName);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                if (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    user = new User();
                    user.UserId = Convert.ToInt32(dr["userId"]);
                    user.UserName = dr["userName"].ToString();
                    user.RealName = dr["realName"].ToString();
                    user.UserTel = dr["userTel"].ToString();
                    user.UserEmail = dr["userEmail"].ToString();
                    user.UserPassword = dr["userPassword"].ToString();
                    user.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    user.UserType = dr["userType"].ToString();
                    user.UserVerify = dr["userVerify"].ToString();
                }
            }
            return user;
        }
        public User GetUserByRealName(String realName)
        {
            User user = null;
            string sql = "select * from tb_user where realName=@realName";
            SqlParameter paramID = new SqlParameter("@realName", realName);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    user = new User();
                    user.UserId = Convert.ToInt32(dr["userId"]);
                    user.UserName = dr["userName"].ToString();
                    user.RealName = dr["realName"].ToString();
                    user.UserTel = dr["userTel"].ToString();
                    user.UserEmail = dr["userEmail"].ToString();
                    user.UserPassword = dr["userPassword"].ToString();
                    user.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    user.UserType = dr["userType"].ToString();
                    user.UserVerify = dr["userVerify"].ToString();
                }
            }
            return user;
        }
        public List<Teacher> GetUserByVerify(String userVerify, String userDepartmentID)
        {
            List<Teacher> list = new List<Teacher>();
            string sql = "select * from tb_user where userVerify=@userVerify and userDepartmentID=@userDepartmentID";
            SqlParameter paramID = new SqlParameter("@userVerify", userVerify);
            SqlParameter paramID2 = new SqlParameter("@userDepartmentID", userDepartmentID);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID, paramID2))
            {
                while (dr.Read())
                {
                    //随便实例一个临时对象
                    Teacher data = new Teacher();
                    //调用Department里的函数
                    DepartmentRepository dre = new DepartmentRepository();
                    UserRepository ur = new UserRepository();
                    data.UserId = Convert.ToInt32(dr["UserId"]);
                    data.UserName = dr["UserName"].ToString();
                    data.RealName = dr["RealName"].ToString();
                    data.UserTel = dr["UserTel"].ToString();
                    data.UserEmail = dr["UserEmail"].ToString();
                    data.UserPassword = dr["UserPassword"].ToString();
                    data.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    data.UserType = dr["userType"].ToString();
                    data.UserVerify = dr["userVerify"].ToString();


                    Teacher tea = ur.GetTeacherByID(data.UserId);
                    data.TeacherNum = tea.TeacherNum;
                    data.teacherType = tea.teacherType;

                    list.Add(data);
                }
                dr.Close();
            }


            return list;
        }
        public Teacher GetTeacherByNum(String Num)
        {
            Teacher user = null;
            string sql = "select * from tb_teacher where teacherNum=@teacherNum";
            SqlParameter paramID = new SqlParameter("@teacherNum", Num);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    user = new Teacher();
                    user.UserId = Convert.ToInt32(dr["userId"]);
                    user.TeacherNum = dr["teacherNum"].ToString();
                    user.teacherType = ttr.GetTypeById(Convert.ToInt32(dr["teacherTypeID"]));
                }
            }
            sql = "select * from tb_user where userId=@userID";
            if (user != null)
            {
                SqlParameter paramID2 = new SqlParameter("@userID", user.UserId);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID2))
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    while (dr.Read())
                    {
                        user.UserName = dr["userName"].ToString();
                        user.RealName = dr["realName"].ToString();
                        user.UserTel = dr["userTel"].ToString();
                        user.UserEmail = dr["userEmail"].ToString();
                        user.UserPassword = dr["userPassword"].ToString();
                        user.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                        user.UserType = dr["userType"].ToString();
                        user.UserVerify = dr["userVerify"].ToString();
                    }
                }
            }
            return user;
        }

        public User GetUserByID(int ID)
        {
            User user = null;
            string sql = "select * from tb_user where userId=@userId";
            SqlParameter paramID = new SqlParameter("@userId", ID);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    user = new User();
                    user.UserId = Convert.ToInt32(dr["userId"]);
                    user.UserName = dr["userName"].ToString();
                    user.RealName = dr["realName"].ToString();
                    user.UserTel = dr["userTel"].ToString();
                    user.UserEmail = dr["userEmail"].ToString();
                    user.UserPassword = dr["userPassword"].ToString();
                    user.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    user.UserType = dr["userType"].ToString();
                    user.UserVerify = dr["userVerify"].ToString();
                }
            }
            return user;
        }
        public Teacher GetTeacherByID(int ID)
        {
            Teacher user = new Teacher();
            string sql = "select * from tb_user where userId=@userId";
            SqlParameter paramID = new SqlParameter("@userId", ID);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                DepartmentRepository dre = new DepartmentRepository();
                while (dr.Read())
                {
                    user.UserId = Convert.ToInt32(dr["userId"]);
                    user.UserName = dr["userName"].ToString();
                    user.RealName = dr["realName"].ToString();
                    user.UserTel = dr["userTel"].ToString();
                    user.UserEmail = dr["userEmail"].ToString();
                    user.UserPassword = dr["userPassword"].ToString();
                    user.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    user.UserType = dr["userType"].ToString();
                    user.UserVerify = dr["userVerify"].ToString();
                }
            }
            sql = "select * from tb_teacher where userId=@userID";
            SqlParameter paramID2 = new SqlParameter("@userID", ID);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID2))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                while (dr.Read())
                {
                    user.teacherType = ttr.GetTypeById(Convert.ToInt32(dr["teacherTypeID"]));
                    user.TeacherNum = dr["teacherNum"].ToString();
                }
            }
            return user;
        }
        public List<Teacher> GetTeacherByName(String Name)
        {
            List<Teacher> list = new List<Teacher>();
            string sql = "select * from tb_user where realName=@realName";
            SqlParameter paramID = new SqlParameter("@realName", Name);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    //随便实例一个临时对象
                    Teacher data = new Teacher();
                    //调用Department里的函数
                    DepartmentRepository dre = new DepartmentRepository();
                    UserRepository ur = new UserRepository();
                    data.UserId = Convert.ToInt32(dr["UserId"]);
                    data.UserName = dr["UserName"].ToString();
                    data.RealName = dr["RealName"].ToString();
                    data.UserTel = dr["UserTel"].ToString();
                    data.UserEmail = dr["UserEmail"].ToString();
                    data.UserPassword = dr["UserPassword"].ToString();
                    data.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    data.UserType = dr["userType"].ToString();
                    data.UserVerify = dr["userVerify"].ToString();


                    Teacher tea = ur.GetTeacherByID(data.UserId);
                    data.TeacherNum = tea.TeacherNum;
                    data.teacherType = tea.teacherType;

                    list.Add(data);
                }
                dr.Close();
            }


            return list;
        }
        public List<Teacher> GetTeacherByName2(String Name)
        {
            List<Teacher> list = new List<Teacher>();
            string sql = "select * from tb_user where userName=@userName";
            SqlParameter paramID = new SqlParameter("@userName", Name);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    //随便实例一个临时对象
                    Teacher data = new Teacher();
                    //调用Department里的函数
                    DepartmentRepository dre = new DepartmentRepository();
                    UserRepository ur = new UserRepository();
                    data.UserId = Convert.ToInt32(dr["UserId"]);
                    data.UserName = dr["UserName"].ToString();
                    data.RealName = dr["RealName"].ToString();
                    data.UserTel = dr["UserTel"].ToString();
                    data.UserEmail = dr["UserEmail"].ToString();
                    data.UserPassword = dr["UserPassword"].ToString();
                    data.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    data.UserType = dr["userType"].ToString();
                    data.UserVerify = dr["userVerify"].ToString();

                    Teacher tea = ur.GetTeacherByID(data.UserId);
                    data.TeacherNum = tea.TeacherNum;
                    data.teacherType = tea.teacherType;

                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public List<User> GetUsers()
        {
            string sql = "select * from tb_teacherType where isStop =0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    //随便实例一个临时对象
                    SystemUser data = new SystemUser();
                    //调用Department里的函数
                    DepartmentRepository dre = new DepartmentRepository();
                    data.UserId = Convert.ToInt32(dr["UserId"]);
                    data.UserName = dr["UserName"].ToString();
                    data.RealName = dr["RealName"].ToString();
                    data.UserTel = dr["UserTel"].ToString();
                    data.UserEmail = dr["UserEmail"].ToString();
                    data.UserPassword = dr["UserPassword"].ToString();
                    data.UserDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["userDepartmentID"]));
                    data.UserType = dr["userType"].ToString();
                    data.UserVerify = dr["userVerify"].ToString();
                    ausers.Add(data);
                }
                dr.Close();
            }
            return ausers;
        }

        public Boolean GetPwdAndName(String userName, String pwd)
        {
            string sql = "select * from tb_user where userName=@userName and userPassword=@userPassword";
            SqlParameter paramName = new SqlParameter("@userName", userName);
            SqlParameter paramPwd = new SqlParameter("@userPassword", pwd);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramName, paramPwd))
            {
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}