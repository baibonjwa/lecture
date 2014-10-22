using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using System.Data.SqlClient;
using System.Data;

namespace lecture.Model.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private List<DepartmentInfo> list;
        public Boolean AddDepartment(DepartmentInfo lr)
        {
                string sql = "insert into tb_department values(@DepName,@DepType,@isStop)";
                SqlParameter DepName = new SqlParameter("@DepName", lr.DepName);
                SqlParameter DepType = new SqlParameter("@DepType", lr.DepType);
                SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, DepName, DepType, isStop);
                return true;
        }

        public Boolean RemoveDepartment(int id)
        {
            string sql = "delete from tb_department where depid=@id";
            SqlParameter depid = new SqlParameter("@id",id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, depid);
            return true;
        }

        public Boolean UpdateDepartment(DepartmentInfo lr)
        {
            string sql = "update tb_department set DepName=@DepName,DepType=@DepType,isStop=@isStop where depid=@depid";
            SqlParameter depid = new SqlParameter("@depid", lr.DepId);
            SqlParameter DepName = new SqlParameter("@DepName", lr.DepName);
            SqlParameter DepType = new SqlParameter("@DepType", lr.DepType);
            SqlParameter isStop = new SqlParameter("@isStop", lr.IsStop);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql,depid, DepName, DepType, isStop);
            return true;
      }

        public DepartmentInfo GetDepartmentByID(int Id)
        {
            list = new List<DepartmentInfo>();
            DepartmentInfo data = null;
            string sql = "select * from tb_department where isStop =0 and depid=@id";
            SqlParameter paramID = new SqlParameter("@id", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    data = new DepartmentInfo();
                    data.DepId = Convert.ToInt32(dr["DepId"]);
                    data.DepName = dr["DepName"].ToString();
                    data.DepType = dr["DepType"].ToString();
                }
            }
            return data;
        }

        public List<DepartmentInfo> GetAllDepartment()
        {
            list = new List<DepartmentInfo>();
            string sql = "select * from tb_department where isStop =0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    DepartmentInfo data = new DepartmentInfo();
                    data.DepId = Convert.ToInt32(dr["DepId"]);
                    data.DepName = dr["DepName"].ToString();
                    data.DepType = dr["DepType"].ToString();
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
    }
}