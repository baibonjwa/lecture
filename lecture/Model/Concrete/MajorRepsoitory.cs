using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using Ninject;
using System.Data.SqlClient;
using System.Data;

namespace lecture.Model.Concrete
{
    public class MajorRepsoitory : IMajorRepository
    {

        List<MajorInfo> ausers = new List<MajorInfo>();
        public Boolean AddMajor(MajorInfo lr)
        {
            string sql = "insert into tb_major values(@majorName,@DepID,@isStop)";
            SqlParameter majorName = new SqlParameter("@majorName", lr.MajorName);
            SqlParameter DepID = new SqlParameter("@DepID", lr.MajorDepartment.DepId);
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, majorName, DepID, isStop);
            return true;
        }

        public Boolean RemoveMajor(int id)
        {
            string sql = "delete from tb_major where majorid=@majorid";
            SqlParameter majorid = new SqlParameter("@majorid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, majorid);
            return true;
        }

        public Boolean UpdateMajor(MajorInfo lr)
        {
            string sql = "update tb_major set majorName=@majorName,DepID=@DepID,isStop=@isStop where majorid=@majorid";
            SqlParameter majorid = new SqlParameter("@majorid", lr.MajorId);
            SqlParameter majorName = new SqlParameter("@majorName", lr.MajorName);
            SqlParameter DepID = new SqlParameter("@DepID", lr.MajorDepartment.DepId);
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, majorid, majorName, DepID, isStop);
            return true;
        }

        public MajorInfo GetMajorByID(int Id)
        {
            MajorInfo data = null;
            string sql = "select * from tb_major where isStop =0 and majorId=@id";
            SqlParameter paramID = new SqlParameter("@id", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    DepartmentRepository dre = new DepartmentRepository();
                    data = new MajorInfo();
                    data.MajorId = Convert.ToInt32(dr["majorId"]);
                    data.MajorName = dr["majorName"].ToString();
                    data.MajorDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["DepID"]));
                }
            }
            return data;
        }

        public List<MajorInfo> GetAllMajor()
        {

            ausers = new List<MajorInfo>();
            string sql = "select * from tb_teacherType where isStop =0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    //随便实例一个临时对象
                    MajorInfo data = new MajorInfo();
                    //调用Department里的函数
                    DepartmentRepository dre = new DepartmentRepository();
                    data.MajorId = Convert.ToInt32(dr["MajorId"]);
                    data.MajorName = dr["MajorName"].ToString();
                    data.MajorDepartment = dre.GetDepartmentByID(Convert.ToInt32(dr["DepID"]));
                    ausers.Add(data);
                }
                dr.Close();
            }
            return ausers;
        }
    }
}