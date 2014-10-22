using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Collections;
using System.Configuration;

namespace lecture.Model.Concrete
{
    public class TeacherTypeRepository : ITeacherTypeRepsoitory
    {
        private List<TeacherTypeInfo> list;
        //db_ctrl sampleDB = new db_ctrl();
        public Boolean AddType(TeacherTypeInfo lr)
        {
            string sql = "insert into tb_teacherType(teacherType,isStop) values(@teacherType,@isStop)";
            SqlParameter paramName = new SqlParameter("@teacherType", lr.TeacherType.ToString());
            SqlParameter paramSex = new SqlParameter("@isStop", lr.IsStop.ToString());
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, paramName, paramSex);
            return true;
        }

        public Boolean RemoveType(int id)
        {
            string sql = "delete from tb_teacherType where teachertypeid=@teachertypeid";
            SqlParameter teachertypeid = new SqlParameter("@teachertypeid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, teachertypeid);
            return true;
        }

        public Boolean UpdateRecord(TeacherTypeInfo lr)
        {
            string sql = "update from tb_teacherType set teacherType=@teacherType,isStop=@isStop where teachertypeid=@teachertypeid";
            SqlParameter teachertypeid = new SqlParameter("@teachertypeid", lr.TeacherTypeID);
            SqlParameter paramName = new SqlParameter("@teacherType", lr.TeacherType.ToString());
            SqlParameter paramSex = new SqlParameter("@isStop", lr.IsStop.ToString());
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, teachertypeid, paramName, paramSex);
            return true;
        }

        public TeacherTypeInfo GetTypeById(int Id)
        {
            TeacherTypeInfo data = null;
            string sql = "select * from tb_teacherType where isStop =0 and teacherTypeID=@teacherTypeID";
            SqlParameter paramID = new SqlParameter("@teacherTypeID", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    TeacherTypeInfo dre = new TeacherTypeInfo();
                    data = new TeacherTypeInfo();
                    data.TeacherTypeID = Convert.ToInt32(dr["teacherTypeID"]);
                    data.TeacherType = dr["teacherType"].ToString();
                    data.IsStop = Convert.ToInt32(dr["isStop"]);
                }
            }
            return data;
        }
        public TeacherTypeInfo GetTypeByName(String name)
        {
            TeacherTypeInfo data = null;
            string sql = "select * from tb_teacherType where isStop =0 and teacherType=@teacherType";
            SqlParameter paramID = new SqlParameter("@teacherType", name);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    TeacherTypeInfo dre = new TeacherTypeInfo();
                    data = new TeacherTypeInfo();
                    data.TeacherTypeID = Convert.ToInt32(dr["teacherTypeID"]);
                    data.TeacherType = dr["teacherType"].ToString();
                    data.IsStop = Convert.ToInt32(dr["isStop"]);
                }
            }
            return data;
        }


        public List<TeacherTypeInfo> GetAllType()
        {
            list = new List<TeacherTypeInfo>();
            string sql = "select * from tb_teacherType where isStop =0 ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    TeacherTypeInfo data = new TeacherTypeInfo();
                    data.TeacherTypeID = Convert.ToInt32(dr["TeacherTypeID"]);
                    data.TeacherType = dr["TeacherType"].ToString();
                    data.IsStop = Convert.ToInt32(dr["IsStop"]);
                    list.Add(data);
                }
                dr.Close();
            }
            return list;

        }
    }
}