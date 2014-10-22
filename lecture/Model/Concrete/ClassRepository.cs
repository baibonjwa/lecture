using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;
using lecture.Model.Concrete;
using lecture.Model.Abstract;
using System.Data.SqlClient;
using System.Data;

namespace lecture.Model.Concrete
{
    public class ClassRepository : IClassRepository
    {
        private List<ClassInfo> list;
        public Boolean AddClass(ClassInfo lr)
        {
            string sql = "insert into tb_class values(@className,@classMajorID,@DepId,@isStop)";
            SqlParameter className = new SqlParameter("@className", lr.ClassName);
            SqlParameter classMajorID = new SqlParameter("@classMajorID", lr.ClassMajor.MajorId);
            SqlParameter DepId = new SqlParameter("@DepId", lr.ClassDep.DepId);
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, className, classMajorID, DepId, isStop);
            return true;
        }

        public Boolean RemoveClass(int id)
        {
            string sql = "delete from tb_class where classID=@classID";
            SqlParameter classID = new SqlParameter("@classID", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, classID);
            return true;
        }

        public Boolean UpdateClass(ClassInfo lr)
        {
            string sql = "update tb_class set className=@className,classMajorID=@classMajorID,DepId=@DepId,isStop=@isStop where classId=@id";
            SqlParameter classid = new SqlParameter("@id", lr.ClassId);
            SqlParameter className = new SqlParameter("@className", lr.ClassName);
            SqlParameter classMajorID = new SqlParameter("@classMajorID", lr.ClassMajor.MajorId);
            SqlParameter DepId = new SqlParameter("@DepId", lr.ClassDep.DepId);
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, classid, className, classMajorID, DepId, isStop);
            return true;
        }

        public ClassInfo GetClassByID(int Id)
        {
            ClassInfo data = null;
            string sql = "select * from tb_class where classId=@classId and isStop=0";
            SqlParameter paramID = new SqlParameter("@classId", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    MajorRepsoitory mr = new MajorRepsoitory();
                    data = new ClassInfo();
                    data.ClassId = Convert.ToInt32(dr["classId"]);
                    data.ClassName = dr["className"].ToString();
                    data.ClassMajor = mr.GetMajorByID(Convert.ToInt32(dr["classMajorID"]));
                    data.ClassDep = dre.GetDepartmentByID(Convert.ToInt32(dr["DepId"]));
                }
            }
            return data;
        }

        public List<ClassInfo> GetAllClass()
        {
            list = new List<ClassInfo>();
            string sql = "select * from tb_class where isStop =0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    MajorRepsoitory mr = new MajorRepsoitory();
                    ClassInfo data = new ClassInfo();
                    data.ClassId = Convert.ToInt32(dr["classId"]);
                    data.ClassName = dr["className"].ToString();
                    data.ClassMajor = mr.GetMajorByID(Convert.ToInt32(dr["classMajorID"]));
                    data.ClassDep = dre.GetDepartmentByID(Convert.ToInt32(dr["DepId"]));
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
    }
}