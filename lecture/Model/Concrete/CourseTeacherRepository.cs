using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;
using lecture.Model.Abstract;
using System.Data.SqlClient;
using System.Data;
namespace lecture.Model.Concrete
{
    public class CourseTeacherRepository : ICourseTeacherRepository
    {
        private List<CourseTeacherInfo> list;
        public Boolean AddCourseTeacher(CourseTeacherInfo lr)
        {
            string sql = "insert into tb_person values(@personName,@isStop,@personType)";
            SqlParameter personName = new SqlParameter("@personName", lr.GetTeacher());
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlParameter personType = new SqlParameter("@personType", "授课教师");
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, personName, isStop, personType);
            return true;
        }

        public Boolean RemoveCourseTeacher(int id)
        {
            string sql = "delete from tb_person where courseteacherid=@ctid";
            SqlParameter ctid = new SqlParameter("@ctid",id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql,ctid);
            return true;
        }

        public Boolean UpdateCourseTeacher(CourseTeacherInfo lr)
        {
            return true;
        }

        public CourseTeacherInfo GetCourseTeacherByID(int Id)
        {
            CourseTeacherInfo data = null;
            string sql = "select * from tb_person where isStop =0 and personType='授课教师' and personId=@personId";
            SqlParameter paramID = new SqlParameter("@personId", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    data = new CourseTeacherInfo();
                    data.PersonId = Convert.ToInt32(dr["personId"]);
                    data.PersonName = dr["personName"].ToString();
                    data.PersonType = dr["personType"].ToString();
                }
            }
            return data;
        }

        public List<CourseTeacherInfo> GetAllCourseTeacher()
        {
            list = new List<CourseTeacherInfo>();
            string sql = "select * from tb_person where isStop =0 and personType='授课教师'";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    CourseTeacherInfo data = new CourseTeacherInfo();
                    data.PersonId = Convert.ToInt32(dr["personId"]);
                    data.PersonName = dr["personName"].ToString();
                    data.PersonType = dr["personType"].ToString();
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
    }
}