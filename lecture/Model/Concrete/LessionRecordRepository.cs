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
    public class LessionRecordRepository : ILessionRecordRepository
    {
        private List<LessionRecord> list;
        public Boolean AddRecord(LessionRecord lr)
        {
            string sql = "insert into tb_lessionRecord values(@weekNumber,@recordDate,@classSpot,@courseID,@userID,@filePath);select @@IDENTITY as 'identity'";
            SqlParameter weekNumber = new SqlParameter("@weekNumber", lr.WeekNumber);
            SqlParameter recordDate = new SqlParameter("@recordDate", lr.RecordDate);
            SqlParameter classSpot = new SqlParameter("@classSpot", lr.ClassSpot);
            SqlParameter courseID = new SqlParameter("@courseID", lr.Course.CouresID);
            SqlParameter userID = new SqlParameter("@userID", lr.Listener.UserId);
            SqlParameter filePath = new SqlParameter("@filePath", lr.Files);
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, weekNumber, recordDate, classSpot, courseID, userID, filePath));

            sql = "insert into tb_recordItem values(@itemContent,@itemTypeID,@id)";
            for (int i = 0; i < lr.Contents.Count; i++)
            {
                SqlParameter id = new SqlParameter("@id", count);
                SqlParameter itemContent = new SqlParameter("@itemContent", lr.Contents[i].ItemContent);
                SqlParameter itemTypeID = new SqlParameter("@itemTypeID", lr.Contents[i].ItemTypeID);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, itemContent, itemTypeID);
            }
            return true;
        }
        public Boolean AddRecord_New(LessionRecord lr)
        {
            string sql = "insert into tb_lessionRecord(weekNumber,recordDate,classSpot,userID,filePath,course,class,courseTeacher,recordTime,courseType) values(@weekNumber,@recordDate,@classSpot,@userID,@filePath,@course,@class,@courseTeacher,@recordTime,@courseType);select @@IDENTITY as 'identity'";
            SqlParameter weekNumber = new SqlParameter("@weekNumber", lr.WeekNumber);
            SqlParameter recordDate = new SqlParameter("@recordDate", lr.RecordDate);
            SqlParameter classSpot = new SqlParameter("@classSpot", lr.ClassSpot);
            SqlParameter filePath = new SqlParameter("@filePath", lr.filePath_Str);
            SqlParameter userID = new SqlParameter("@userID", lr.Listener.UserId);
            SqlParameter course = new SqlParameter("@course", lr.Course_Str);
            SqlParameter class2 = new SqlParameter("@class", lr.Class_Str);
            SqlParameter courseType = new SqlParameter("@courseType", lr.CourseType_Str);
            SqlParameter courseTeacher = new SqlParameter("@courseTeacher", lr.CourseTeacher_Str);
            SqlParameter recordTime = new SqlParameter("@recordTime", lr.RecordTime_Str);

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, weekNumber, recordDate, classSpot, filePath, userID, course, class2, courseTeacher, recordTime, courseType));

            sql = "insert into tb_recordItem values(@itemContent,@itemTypeID,@id)";
            for (int i = 0; i < lr.Contents.Count; i++)
            {
                SqlParameter id = new SqlParameter("@id", count);
                SqlParameter itemContent = new SqlParameter("@itemContent", lr.Contents[i].ItemContent);
                SqlParameter itemTypeID = new SqlParameter("@itemTypeID", lr.Contents[i].ItemTypeID);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, itemContent, itemTypeID);
            }
            return true;
        }
        public Boolean DeleteRecord(int id)
        {
            string sql = "delete from tb_lessionRecord where id=@rid";
            SqlParameter rid = new SqlParameter("@rid", id);
            // int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql,rid));
            SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, rid);

            sql = "delete from tb_recordItem where id=@iid";
            SqlParameter iid = new SqlParameter("@iid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, iid);
            return true;
        }
        public Boolean UpdateRecord(LessionRecord lr)
        {
            string sql = "update tb_lessionRecord set weekNumber=@weekNumber,recordDate=@recordDate, classSpot=@classSpot,filePath=@filePath,userID=@userID,course=@course,class=@class,courseTeacher=@courseTeacher,courseType=@courseType,recordTime=@recordTime,state=@state where id=@id;";
            SqlParameter id = new SqlParameter("@id", lr.Id);
            SqlParameter weekNumber = new SqlParameter("@weekNumber", lr.WeekNumber);
            SqlParameter recordDate = new SqlParameter("@recordDate", lr.RecordDate);
            SqlParameter classSpot = new SqlParameter("@classSpot", lr.ClassSpot);
            //SqlParameter courseID = new SqlParameter("@courseID", lr.Course.CouresID);
            //SqlParameter filePath = new SqlParameter("@filePath", lr.Files);
            SqlParameter filePath = new SqlParameter("@filePath", lr.filePath_Str);
            SqlParameter userID = new SqlParameter("@userID", lr.Listener.UserId);
            SqlParameter course = new SqlParameter("@course", lr.Course_Str);
            SqlParameter class2 = new SqlParameter("@class", lr.Class_Str);
            SqlParameter courseType = new SqlParameter("@courseType", lr.CourseType_Str);
            SqlParameter courseTeacher = new SqlParameter("@courseTeacher", lr.CourseTeacher_Str);
            SqlParameter recordTime = new SqlParameter("@recordTime", lr.RecordTime_Str);
            SqlParameter state = new SqlParameter("@state", "正常");


            // int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql,id, weekNumber, recordDate, classSpot, courseID, userID, filePath));
            //SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, weekNumber, recordDate, classSpot, courseID, userID, filePath);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, weekNumber, recordDate, classSpot, filePath, userID, course, class2, courseTeacher, recordTime, courseType, state);

            sql = "update tb_recordItem set itemContent=@itemContent where itemTypeID=@itemTypeID and id=@iid";
            for (int i = 0; i < lr.Contents.Count; i++)
            {
                SqlParameter iid = new SqlParameter("@iid", lr.Id);
                //SqlParameter itemid = new SqlParameter("@itemid",lr.Contents[i].ItemId);
                SqlParameter itemContent = new SqlParameter("@itemContent", lr.Contents[i].ItemContent);
                SqlParameter itemTypeID = new SqlParameter("@itemTypeID", lr.Contents[i].ItemTypeID);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, iid, itemContent, itemTypeID);
            }
            return true;
        }
        public Boolean UpdateRecordState(LessionRecord lr)
        {
            string sql = "update tb_lessionRecord set state=@state where id=@id;";
            SqlParameter id = new SqlParameter("@id", lr.Id);
            SqlParameter state = new SqlParameter("@state", lr.State);


            // int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql,id, weekNumber, recordDate, classSpot, courseID, userID, filePath));
            //SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, weekNumber, recordDate, classSpot, courseID, userID, filePath);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, id, state);

            return true;
        }
        public List<LessionRecord> GetRecordsById(int userId)
        {
            List<LessionRecord> list = new List<LessionRecord>(); ;
            LessionRecord data = null;
            string sql = "select * from tb_lessionRecord where userID=@userId order by id desc";
            SqlParameter paramID = new SqlParameter("@userId", userId);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    LessionRecord dre = new LessionRecord();
                    UserRepository ur = new UserRepository();
                    data = new LessionRecord();
                    data.Id = Convert.ToInt32(dr["Id"]);
                    data.WeekNumber = Convert.ToInt32(dr["weekNumber"]);
                    data.RecordDate = Convert.ToDateTime(dr["recordDate"]);
                    data.ClassSpot = dr["classSpot"].ToString();
                    //data.Course = cr.GetCourseByID(Convert.ToInt32(dr["courseID"]));
                    data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["userID"]));
                    data.filePath_Str = dr["filePath"].ToString();
                    data.Course_Str = dr["course"].ToString();
                    data.Class_Str = dr["class"].ToString();
                    data.CourseTeacher_Str = dr["courseTeacher"].ToString();
                    data.RecordTime_Str = dr["recordTime"].ToString();
                    data.CourseType_Str = dr["courseType"].ToString();
                    data.State = dr["state"].ToString();
                    list.Add(data);
                }

            }
            return list;
        }

        public List<LessionRecord> GetRecordsByYearAndMonth(String Year, String Month)
        {
            List<LessionRecord> list = new List<LessionRecord>(); ;
            LessionRecord data = null;
            string sql = "select * from tb_lessionRecord where DATEPART(YEAR,recordDate)=@Year  ";
            SqlParameter[] paramYear;
            if (Month == "0")
            {
                paramYear = new SqlParameter[1];
                paramYear[0] = new SqlParameter("@Year", Year);
                sql += "order by id desc";
            }
            else
            {
                paramYear = new SqlParameter[2];
                paramYear[0] = new SqlParameter("@Year", Year);
                paramYear[1] = new SqlParameter("@Month", Month);
                sql += "and  DATEPART(month,recordDate)=@Month order by id desc";

            }
            //SqlParameter paramMonth = new SqlParameter("@Month", Month);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramYear))
            {
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    LessionRecord dre = new LessionRecord();
                    UserRepository ur = new UserRepository();
                    data = new LessionRecord();
                    data.Id = Convert.ToInt32(dr["Id"]);
                    data.WeekNumber = Convert.ToInt32(dr["weekNumber"]);
                    data.RecordDate = Convert.ToDateTime(dr["recordDate"]);
                    data.ClassSpot = dr["classSpot"].ToString();
                    //data.Course = cr.GetCourseByID(Convert.ToInt32(dr["courseID"]));
                    data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["userID"]));
                    data.filePath_Str = dr["filePath"].ToString();
                    data.Course_Str = dr["course"].ToString();
                    data.Class_Str = dr["class"].ToString();
                    data.CourseTeacher_Str = dr["courseTeacher"].ToString();
                    data.RecordTime_Str = dr["recordTime"].ToString();
                    data.CourseType_Str = dr["courseType"].ToString();
                    data.State = dr["state"].ToString();


                    sql = "select * from tb_recordItem where Id=@Id";
                    SqlParameter paramId = new SqlParameter("@Id", data.Id);
                    List<RecordItem> ri = new List<RecordItem>();
                    using (SqlDataReader dr2 = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramId))
                    {
                        while (dr2.Read())
                        {
                            RecordItem r = new RecordItem();
                            r.id = Convert.ToInt32(dr2["id"]);
                            r.ItemContent = dr2["itemContent"].ToString();
                            r.ItemId = Convert.ToInt32(dr2["ItemID"]);
                            r.ItemTypeID = Convert.ToInt32((dr2["itemTypeID"]));
                            data.Contents.Add(r);
                        }
                    }
                    list.Add(data);
                }

            }
            return list;
        }



        public LessionRecord SelectedRecord(int key)
        {
            LessionRecord data = null;
            string sql = "select * from tb_lessionRecord where Id=@Id";
            SqlParameter paramID = new SqlParameter("@Id", key);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    LessionRecord dre = new LessionRecord();
                    UserRepository ur = new UserRepository();
                    data = new LessionRecord();
                    data.Id = Convert.ToInt32(dr["Id"]);
                    data.WeekNumber = Convert.ToInt32(dr["weekNumber"]);
                    data.RecordDate = Convert.ToDateTime(dr["recordDate"]);
                    data.ClassSpot = dr["classSpot"].ToString();
                    //data.Course = cr.GetCourseByID(Convert.ToInt32(dr["courseID"]));
                    data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["userID"]));
                    data.filePath_Str = dr["filePath"].ToString();
                    data.Course_Str = dr["course"].ToString();
                    data.Class_Str = dr["class"].ToString();
                    data.CourseTeacher_Str = dr["courseTeacher"].ToString();
                    data.RecordTime_Str = dr["recordTime"].ToString();
                    data.CourseType_Str = dr["courseType"].ToString();
                    data.State = dr["state"].ToString();
                }

            }
            sql = "select * from tb_recordItem where Id=@Id";
            SqlParameter paramId = new SqlParameter("@Id", key);
            List<RecordItem> ri = new List<RecordItem>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramId))
            {
                while (dr.Read())
                {
                    RecordItem r = new RecordItem();
                    r.id = Convert.ToInt32(dr["id"]);
                    r.ItemContent = dr["itemContent"].ToString();
                    r.ItemId = Convert.ToInt32(dr["ItemID"]);
                    r.ItemTypeID = Convert.ToInt32((dr["itemTypeID"]));
                    data.Contents.Add(r);
                }
            }
            return data;
        }
        public List<LessionRecord> SelectedRecordIsPass(string state)
        {
            List<LessionRecord> list = new List<LessionRecord>(); ;
            LessionRecord data = null;
            string sql = "select * from tb_lessionRecord where state=@state order by id desc";
            SqlParameter paramID = new SqlParameter("@state", state);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    LessionRecord dre = new LessionRecord();
                    UserRepository ur = new UserRepository();
                    data = new LessionRecord();
                    data.Id = Convert.ToInt32(dr["Id"]);
                    data.WeekNumber = Convert.ToInt32(dr["weekNumber"]);
                    data.RecordDate = Convert.ToDateTime(dr["recordDate"]);
                    data.ClassSpot = dr["classSpot"].ToString();
                    //data.Course = cr.GetCourseByID(Convert.ToInt32(dr["courseID"]));
                    data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["userID"]));
                    data.filePath_Str = dr["filePath"].ToString();
                    data.Course_Str = dr["course"].ToString();
                    data.Class_Str = dr["class"].ToString();
                    data.CourseTeacher_Str = dr["courseTeacher"].ToString();
                    data.RecordTime_Str = dr["recordTime"].ToString();
                    data.CourseType_Str = dr["courseType"].ToString();
                    data.State = dr["state"].ToString();
                    list.Add(data);
                }

            }
            return list;
        }

    }
}