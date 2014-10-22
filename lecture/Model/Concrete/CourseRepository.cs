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
    public class CourseRepository : ICourseRepository
    {

        private List<CourseInfo> list;
        private List<ClassInfo> classInfo = new List<ClassInfo>();
        public Boolean AddCourse(CourseInfo lr)
        {
            string sql = "insert into tb_course values(@courseName,@courseType,@courseNumer,@classes,@courseTeacherID)";
            string classCon = "";
            for (int i = 0; i < lr.Classes.Count; i++)
            {
                classCon += lr.Classes[i].ClassId.ToString() + "|";
            }
            classCon = classCon.Substring(0, classCon.Length - 1);

            SqlParameter courseName = new SqlParameter("@courseName", lr.CourseName);
            SqlParameter courseType = new SqlParameter("@courseType", lr.CourseType);
            SqlParameter courseNumer = new SqlParameter("@courseNumer", lr.CourseNumer);
            SqlParameter classes = new SqlParameter("@classes", classCon);
            SqlParameter courseTeacherID = new SqlParameter("@courseTeacherID", lr.Teacher.PersonId);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, courseName, courseType, courseNumer, classes, courseTeacherID);
            return true;
        }

        public Boolean RemoveCourse(int id)
        {
            string sql = "delete from tb_course where courseID=@courseID";
            SqlParameter courseID = new SqlParameter("@courseID", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, courseID);
            return true;
        }

        public Boolean UpdateCourse(CourseInfo lr)
        {

            string sql = "update tb_course set courseName=@courseName,courseType=@courseType,courseNumer=@courseNumer,classes=@classes,courseTeacherID=@courseTeacherID where couresID=@courseid";
            string classCon = "";
            for (int i = 0; i < lr.Classes.Count; i++)
            {
                classCon += lr.Classes[i].ClassId.ToString() + "|";
            }
            classCon = classCon.Substring(0, classCon.Length - 1);
            SqlParameter courseid = new SqlParameter("@courseid", lr.CouresID);
            SqlParameter courseName = new SqlParameter("@courseName", lr.CourseName);
            SqlParameter courseType = new SqlParameter("@courseType", lr.CourseType);
            SqlParameter courseNumer = new SqlParameter("@courseNumer", lr.CourseNumer);
            SqlParameter classes = new SqlParameter("@classes", classCon);
            SqlParameter courseTeacherID = new SqlParameter("@courseTeacherID", lr.Teacher.PersonId);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, courseid, courseName, courseType, courseNumer, classes, courseTeacherID);
            return true;
        }

        public CourseInfo GetCourseByID(int Id)
        {
            CourseInfo data = new CourseInfo();
            string sql = "select * from tb_course where couresID=@id";
            SqlParameter paramID = new SqlParameter("@id", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    ClassRepository cr = new ClassRepository();
                    CourseTeacherRepository ctr = new CourseTeacherRepository();

                    data.CouresID = Convert.ToInt32(dr["couresID"]);
                    data.CourseName = dr["courseName"].ToString();
                    data.CourseNumer = dr["courseNumer"].ToString();
                    string[] classCon = dr["classes"].ToString().Split('|');
                    for (int i = 0; i < classCon.Length; i++)
                    {
                        classInfo.Add(cr.GetClassByID(Convert.ToInt32(classCon[i])));
                    }
                    data.Classes = classInfo;
                    data.Teacher = ctr.GetCourseTeacherByID(Convert.ToInt32(dr["courseTeacherID"]));
                }
            }
            return data;
        }
        public CourseInfo GetCourseByNumer(String Numer)
        {
            CourseInfo data = new CourseInfo();
            string sql = "select * from tb_course where courseNumer=@courseNumer";
            SqlParameter paramID = new SqlParameter("@courseNumer", Numer);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    ClassRepository cr = new ClassRepository();
                    CourseTeacherRepository ctr = new CourseTeacherRepository();

                    data.CouresID = Convert.ToInt32(dr["couresID"]);
                    data.CourseName = dr["courseName"].ToString();
                    data.CourseNumer = dr["courseNumer"].ToString();
                    data.CourseType = dr["courseType"].ToString();
                    string[] classCon = dr["classes"].ToString().Split('|');
                    for (int i = 0; i < classCon.Length; i++)
                    {
                        data.Classes.Add(cr.GetClassByID(Convert.ToInt32(classCon[i])));
                    }
                    data.Teacher = ctr.GetCourseTeacherByID(Convert.ToInt32(dr["courseTeacherID"]));
                }

            }
            return data;
        }

        public List<CourseInfo> GetAllCourse()
        {
            list = new List<CourseInfo>();
            string sql = "select * from tb_course";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    ClassRepository cr = new ClassRepository();
                    CourseTeacherRepository ctr = new CourseTeacherRepository();
                    CourseInfo data = new CourseInfo();
                    data.CouresID = Convert.ToInt32(dr["couresID"]);
                    data.CourseName = dr["courseName"].ToString();
                    data.CourseNumer = dr["courseNumer"].ToString();
                    string[] classCon = dr["classes"].ToString().Split('|');
                    for (int i = 0; i < classCon.Length; i++)
                    {
                        classInfo.Add(cr.GetClassByID(Convert.ToInt32(classCon[i])));
                    }
                    data.Classes = classInfo;
                    data.Teacher = ctr.GetCourseTeacherByID(Convert.ToInt32(dr["courseTeacherID"]));
                    //data.Classes 
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
    }
}