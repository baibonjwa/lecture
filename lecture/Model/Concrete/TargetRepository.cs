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
    public class TargetRepository : ITargetRepository
    {
        public Boolean AddTarget(TargetInfo lr)
        {
            return true;
        }
        public Boolean RemoveTarget(TargetInfo lr)
        {
            return true;
        }
        public Boolean UpdateTarget(TargetInfo lr)
        {
            return true;
        }
        public TargetInfo GetTargetByTypeID(int typeId)
        {
            TargetInfo data = null;
            string sql = "select * from tb_target where teacherTypeID=@typeId";
            SqlParameter paramID = new SqlParameter("@typeId", typeId);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    TeacherTypeRepository ttp = new TeacherTypeRepository();
                    TargetInfo dre = new TargetInfo();
                    data = new TargetInfo();
                    data.TargetID = Convert.ToInt32(dr["targetID"]);
                    data.Week = Convert.ToInt32(dr["week"]);
                    data.Count = Convert.ToInt32(dr["count"]);
                    data.TeacherTypeID = ttp.GetTypeById(Convert.ToInt32(dr["week"]));
                }
                
            }
            return data;
        }
        public TargetInfo GetTargetByType(String typeName)
        {
            TargetInfo data = null;



            string sql = "select * from tb_target where teacherTypeID=@teacherTypeID";
            SqlParameter paramID = new SqlParameter("@teacherTypeID", typeName);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    TeacherTypeRepository ttp = new TeacherTypeRepository();
                    TargetInfo dre = new TargetInfo();
                    data = new TargetInfo();
                    data.TargetID = Convert.ToInt32(dr["targetID"]);
                    data.Week = Convert.ToInt32(dr["week"]);
                    data.Count = Convert.ToInt32(dr["week"]);
                    data.TeacherTypeID = ttp.GetTypeById(Convert.ToInt32(dr["week"]));
                }
            }
            return data;
        }
        public List<TargetInfo> GetAllTarget()
        {
            return null;
        }
    }
}