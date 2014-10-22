using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using lecture.Model.Concrete;
using System.Data.SqlClient;
using System.Data;

namespace lecture.Model.Concrete
{
    public class TaskByDetailRepository : ITaskByDetailRepository
    {
        List<TaskByDetailEntity> list;
        public bool AddTask(TaskByDetailEntity task)
        {
            string sql = "insert into tb_taskDetail values(@teacher,@teachertype,@IsStop,@publishTime,@taskDate);select @@IDENTITY as 'identity'";
            //SqlParameter classSpot = new SqlParameter("@classSpot", task.ClassSpot);
            SqlParameter taskDate = new SqlParameter("@taskDate", task.taskDate);
            SqlParameter teacher = new SqlParameter("@teacher", task.Teacher);
            SqlParameter teachertype = new SqlParameter("@teachertype", task.TeacherType);
            SqlParameter IsStop = new SqlParameter("@IsStop", task.IsStop);
            SqlParameter publishTime = new SqlParameter("@publishTime", task.PublishTime);
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, teacher, teachertype, IsStop, publishTime, taskDate));


            for (int i = 0; i < task.Contents.Count; i++)
            {
                sql = "insert into tb_taskDetailItem values(@dTime,@dSpot,@dCourse,@taskDetailID)";
                SqlParameter dTime = new SqlParameter("@dTime", task.Contents[i].dTime);
                SqlParameter dSpot = new SqlParameter("@dSpot", task.Contents[i].dSpot);
                SqlParameter dCourse = new SqlParameter("@dCourse", task.Contents[i].dCourse);
                SqlParameter taskDetailID = new SqlParameter("@taskDetailID", count);
                SqlHelper.ExecuteScalar(SqlHelper.GetConnection(), CommandType.Text, sql, dTime, dSpot, dCourse, taskDetailID);
            }
            return true;
        }
        public bool RemoveTask(int id)
        {
            string sql = "delete from tb_taskDetail where taskdetailid=@taskdetailid";
            SqlParameter taskdetailid = new SqlParameter("@taskdetailid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, taskdetailid);
            return true;
        }
        public List<TaskByDetailEntity> GetAllTask()
        {
            //TaskByDetailEntity task = new TaskByDetailEntity();
            //list = new List<TaskByDetailEntity>();
            //string sql = "select taskDetailID,teachertypeID,teacherID,courseID,contents,time,isstop from tb_taskDetail where isStop =0";
            //using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            //{
            //    UserRepository ur = new UserRepository();
            //    CourseRepository cr = new CourseRepository();
            //    TeacherTypeRepository ttr = new TeacherTypeRepository();
            //    while (dr.Read())
            //    {
            //        TaskByDetailEntity data = new TaskByDetailEntity();
            //        // data.ClassSpot = dr["ClassSpot"].ToString();
            //        data.Teacher = ur.GetTeacherByID(Convert.ToInt32(dr["teacherID"]));
            //        data.TaskID = Convert.ToInt32(dr["taskDetailID"]);
            //        //data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["listener"]));
            //        data.Course = cr.GetCourseByID(Convert.ToInt32(dr["courseID"]));
            //        data.Time = Convert.ToDateTime(dr["time"].ToString());
            //        data.Contents = dr["contents"].ToString();
            //        data.TeacherType = ttr.GetTypeById(Convert.ToInt32(dr["teachertypeID"]));
            //        //data.Publisher = ur.GetUserByID(Convert.ToInt32(dr["publisher"]));
            //        // data.PublishTime = Convert.ToDateTime(dr["time"].ToString());
            //        data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
            //        list.Add(data);
            //    }
            //    dr.Close();
            //}
            return list;
        }
        public List<DetailItem> GetDetailItemByTaskDetailID(int id)
        {
            List<DetailItem> list = new List<DetailItem>();
            DetailItem data = new DetailItem();
            string sql = "select taskDetailItem,dTime,dSpot,dCourse,taskDetailID from tb_taskDetailItem where taskDetailID=@taskDetailID";
            SqlParameter taskDetailID = new SqlParameter("@taskDetailID", id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, taskDetailID))
            {
                while (dr.Read())
                {
                    data = new DetailItem();
                    // data.ClassSpot = dr["ClassSpot"].ToString();
                    data.dTime = dr["dTime"].ToString();
                    data.dSpot = dr["dSpot"].ToString();
                    data.dCourse = dr["dCourse"].ToString();
                    data.taskDetailID = Convert.ToInt32(dr["taskDetailID"]);
                    data.taskDetailItem = Convert.ToInt32(dr["taskDetailItem"]);
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public List<TaskByDetailReport> GetDetailItemByTaskDetailID(String[] id)
        {
            List<TaskByDetailReport> list = new List<TaskByDetailReport>();
            DetailItem data = new DetailItem();
            string sql = "select 听课教师,听课时间,听课地点,听课课程,任务月份,taskDetailID,任务月份,taskDetailItem from v_task where 1=1 and (";
            for (int i = 0; i < id.Length; i++)
            {
                sql += "taskDetailID=@taskDetailID" + i + " or ";
            }
            sql += "1=0)";
            SqlParameter[] taskDetailID = new SqlParameter[id.Length];
            for (int i = 0; i < id.Length; i++)
            {
                taskDetailID[i] = new SqlParameter("@taskDetailID" + i + "", id[i]);
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, taskDetailID))
            {
                while (dr.Read())
                {
                    TaskByDetailReport dataReport = new TaskByDetailReport();
                    dataReport.Contents = new DetailItem();
                    // data.ClassSpot = dr["ClassSpot"].ToString();
                    dataReport.Teacher = dr["听课教师"].ToString();
                    dataReport.dCourse = dr["听课课程"].ToString();
                    dataReport.dTime = dr["听课时间"].ToString();
                    dataReport.dSpot = dr["听课地点"].ToString();
                    dataReport.taskDetailID = Convert.ToInt32(dr["taskDetailID"]);
                    dataReport.taskDetailItem = Convert.ToInt32(dr["taskDetailItem"]);
                    dataReport.taskDate = dr["任务月份"].ToString();
                    list.Add(dataReport);
                }
                dr.Close();
            }
            return list;
        }
        public TaskByDetailEntity GetTaskbyID(int id)
        {
            TaskByDetailEntity data = new TaskByDetailEntity();
            string sql = "select * from tb_taskDetail where taskDetailID = @tasktypeid";
            SqlParameter tasktypeid = new SqlParameter("@tasktypeid", id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    data.TaskID = Convert.ToInt32(dr["taskDetailID"]);
                    data.Teacher = dr["teacher"].ToString();
                    data.taskDate = Convert.ToInt32(dr["taskDate"].ToString());
                    data.TeacherType = dr["teachertype"].ToString();
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    data.PublishTime = Convert.ToDateTime(dr["publishTime"]);
                    List<DetailItem> di = new List<DetailItem>();
                    di = GetDetailItemByTaskDetailID(id);
                    for (int j = 0; j < di.Count; j++)
                    {
                        data.Contents.Add(di[j]);
                    }
                }
                dr.Close();
            }
            return data;
        }
        public List<TaskByDetailEntity> GetTaskByDepartment(int depID)
        {
            list = new List<TaskByDetailEntity>();
            TaskByDetailEntity data = new TaskByDetailEntity();
            string sql = "select * from v_task_dep where userDepartmentID = ''+ @userDepartmentID +'' order by taskDetailID desc";
            SqlParameter tasktypeid = new SqlParameter("@userDepartmentID", depID);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    data = new TaskByDetailEntity();
                    data.TaskID = Convert.ToInt32(dr["taskDetailID"]);
                    data.Teacher = dr["teacher"].ToString();
                    data.TeacherType = dr["teachertype"].ToString();
                    data.taskDate = Convert.ToInt32(dr["taskDate"].ToString());
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    data.PublishTime = Convert.ToDateTime(dr["publishTime"]);
                    List<DetailItem> di = new List<DetailItem>();
                    di = GetDetailItemByTaskDetailID(Convert.ToInt32(dr["taskDetailID"]));
                    for (int j = 0; j < di.Count; j++)
                    {
                        data.Contents.Add(di[j]);
                    }
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public List<TaskByDetailEntity> GetTaskbyName(String name)
        {
            list = new List<TaskByDetailEntity>();
            TaskByDetailEntity data = new TaskByDetailEntity();
            string sql = "select * from tb_taskDetail where teacher = ''+ @teacher +'' order by taskDetailID desc";
            SqlParameter tasktypeid = new SqlParameter("@teacher", name);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                CourseRepository cr = new CourseRepository();
                while (dr.Read())
                {
                    data = new TaskByDetailEntity();
                    data.TaskID = Convert.ToInt32(dr["taskDetailID"]);
                    data.Teacher = dr["teacher"].ToString();
                    data.TeacherType = dr["teachertype"].ToString();
                    data.taskDate = Convert.ToInt32(dr["taskDate"].ToString());
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    data.PublishTime = Convert.ToDateTime(dr["publishTime"]);
                    List<DetailItem> di = new List<DetailItem>();
                    di = GetDetailItemByTaskDetailID(Convert.ToInt32(dr["taskDetailID"]));
                    for (int j = 0; j < di.Count; j++)
                    {
                        data.Contents.Add(di[j]);
                    }
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public bool UpdateTask(TaskByDetailEntity task)
        {
            string sql = "update tb_taskDetail set teacher=@teacher,teachertype=@teachertype,taskDate=@taskDate where taskDetailID=@taskDetailID";
            SqlParameter taskDetailID = new SqlParameter("@taskDetailID", task.TaskID);
            SqlParameter teacher = new SqlParameter("@teacher", task.Teacher);
            SqlParameter teachertype = new SqlParameter("@teachertype", task.TeacherType);
            SqlParameter taskDate = new SqlParameter("@taskDate", task.taskDate);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, taskDetailID, teacher, teachertype, taskDate);


            List<DetailItem> di = new List<DetailItem>();
            di = GetDetailItemByTaskDetailID(Convert.ToInt32(task.TaskID));
            for (int i = 0; i < di.Count; i++)
            {
                sql = "delete from tb_taskDetailItem where taskDetailItem=@taskDetailItem";
                SqlParameter taskDetailItem = new SqlParameter("@taskDetailItem", di[i].taskDetailItem);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, taskDetailItem);
            }
            for (int i = 0; i < task.Contents.Count; i++)
            {
                sql = "insert into tb_taskDetailItem values(@dTime,@dSpot,@dCourse,@taskDetailID)";
                SqlParameter dTime = new SqlParameter("@dTime", task.Contents[i].dTime);
                SqlParameter dSpot = new SqlParameter("@dSpot", task.Contents[i].dSpot);
                SqlParameter dCourse = new SqlParameter("@dCourse", task.Contents[i].dCourse);
                SqlParameter taskD = new SqlParameter("@taskDetailID", task.TaskID);
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, dTime, dSpot, dCourse, taskD);
            }

            return true;
        }
        public List<TaskByDetailEntity> GetTaskByNameAndPost(String name, String post, String depID)
        {
            MultCondition mc = new MultCondition();
            Condition con = new Condition();
            con.ConditionName = "teacher";
            con.ConditionValue = name;
            con.Operator = Operator.Like;
            if (name != null && name != "")
            {
                mc.AddCondition(con);
            }
            Condition con2 = new Condition();
            con2.ConditionName = "teachertype";
            con2.Operator = Operator.Equal;
            con2.ConditionValue = post;
            if (post != null && post != "")
            {
                mc.AddCondition(con2);
            }
            Condition con3 = new Condition();
            con2.ConditionName = "userDepartmentID";
            con2.Operator = Operator.Equal;
            con2.ConditionValue = depID;
            if (depID != "0")
            {
                mc.AddCondition(con2);
            }
            String sql = "select * from v_task_dep where 1=1";
            ConditionAnalyze cal = new ConditionAnalyze();
            SqlParameter[] para = cal.AndAnalyzePara(mc, ref sql);
            sql += " order by taskDetailID desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, para))
            {
                list = new List<TaskByDetailEntity>();
                while (dr.Read())
                {
                    TaskByDetailEntity data = new TaskByDetailEntity();
                    data.Teacher = dr["teacher"].ToString();
                    data.TaskID = Convert.ToInt32(dr["taskDetailID"]);
                    data.taskDate = Convert.ToInt32(dr["taskDate"].ToString());
                    data.TeacherType = dr["teachertype"].ToString();
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    data.PublishTime = Convert.ToDateTime(dr["publishTime"]);
                    list.Add(data);
                }
                dr.Close();
            }
            return list;

        }
    }
    public class TaskByTypeRepository : ITaskByTypeRepository
    {
        List<TaskByTypeEntity> list;
        public bool AddTask(TaskByTypeEntity task)
        {
            string sql = "insert into tb_taskType(teacherTypeID,week,contents,publisher,time) values(@teacherTypeID,@week,@contents,@publisher,@time)";
            SqlParameter pTeacherTypeID = new SqlParameter("@teacherTypeID", task.TeacherType.TeacherTypeID);
            SqlParameter pWeek = new SqlParameter("@week", task.Week);
            SqlParameter pContents = new SqlParameter("@contents", task.Contents);
            SqlParameter pPublisher = new SqlParameter("@publisher", task.Publisher.UserId);
            SqlParameter pTime = new SqlParameter("@time", task.PublishTime);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, pTeacherTypeID, pWeek, pContents, pPublisher, pTime);
            return true;
        }
        public bool RemoveTask(int id)
        {
            string sql = "delete from tb_taskType where tasktypeid=@tasktypeid";
            SqlParameter tasktypeid = new SqlParameter("@tasktypeid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid);
            return true;
        }
        public List<TaskByTypeEntity> GetAllTask()
        {
            list = new List<TaskByTypeEntity>();
            string sql = "select * from tb_taskType where isStop =0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                while (dr.Read())
                {
                    TaskByTypeEntity data = new TaskByTypeEntity();
                    data.TaskID = Convert.ToInt32(dr["taskTypeID"]);
                    data.TeacherType = ttr.GetTypeById(Convert.ToInt32(dr["teacherTypeID"]));
                    data.Week = dr["week"].ToString();
                    data.Contents = dr["contents"].ToString();
                    data.Publisher = ur.GetTeacherByID(Convert.ToInt32(dr["publisher"]));
                    data.PublishTime = Convert.ToDateTime(dr["time"].ToString());
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public TaskByTypeEntity GetTaskbyID(int id)
        {
            TaskByTypeEntity data = new TaskByTypeEntity();
            string sql = "select * from tb_taskType where tasktypeid =@tasktypeid";
            SqlParameter tasktypeid = new SqlParameter("@tasktypeid", id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                while (dr.Read())
                {

                    data.TaskID = Convert.ToInt32(dr["taskTypeID"]);
                    data.TeacherType = ttr.GetTypeById(Convert.ToInt32(dr["teacherTypeID"]));
                    data.Week = dr["week"].ToString();
                    data.Contents = dr["contents"].ToString();
                    data.Publisher = ur.GetTeacherByID(Convert.ToInt32(dr["publisher"]));
                    data.PublishTime = Convert.ToDateTime(dr["time"].ToString());
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());

                }
                dr.Close();
            }
            return data;
        }
        public bool UpdateTask(TaskByTypeEntity task)
        {
            string sql = "update tb_taskType set teacherTypeID=@teacherTypeID,week=@week,contents=@contents,publisher=@publisher,time=@time where tasktypeid=@tasktypeid";
            SqlParameter tasktypeid = new SqlParameter("@tasktypeid", task.TaskID);
            SqlParameter pTeacherTypeID = new SqlParameter("@teacherTypeID", task.TeacherType.TeacherTypeID);
            SqlParameter pWeek = new SqlParameter("@week", task.Week);
            SqlParameter pContents = new SqlParameter("@contents", task.Contents);
            SqlParameter pPublisher = new SqlParameter("@publisher", task.Publisher.UserId);
            SqlParameter pTime = new SqlParameter("@time", task.PublishTime);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, tasktypeid, pTeacherTypeID, pWeek, pContents, pPublisher, pTime);
            return true;
        }
    }
    public class TaskByNameRepository : ITaskByNameRepository
    {
        List<TaskByNameEntity> list;
        public bool AddTask(TaskByNameEntity task)
        {
            string sql = "insert into tb_taskName(listener,week,contents,publisher,time) values(@listener,@week,@contents,@publisher,@time)";
            SqlParameter pTeacherTypeID = new SqlParameter("@listener", task.Listener.UserId);
            SqlParameter pWeek = new SqlParameter("@week", task.Week);
            SqlParameter pContents = new SqlParameter("@contents", task.Contents);
            SqlParameter pPublisher = new SqlParameter("@publisher", task.Publisher.UserId);
            SqlParameter pTime = new SqlParameter("@time", task.PublishTime);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, pTeacherTypeID, pWeek, pContents, pPublisher, pTime);
            return true;
        }
        public bool RemoveTask(int id)
        {
            string sql = "delete from tb_taskName where tasknameid=@tasknameid";
            SqlParameter tasknameid = new SqlParameter("@tasknameid", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, tasknameid);
            return true;
        }
        public List<TaskByNameEntity> GetAllTask()
        {
            list = new List<TaskByNameEntity>();
            string sql = "select * from tb_taskName where isStop =0";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql))
            {
                TeacherTypeRepository ttr = new TeacherTypeRepository();
                UserRepository ur = new UserRepository();
                while (dr.Read())
                {
                    TaskByNameEntity data = new TaskByNameEntity();
                    data.TaskID = Convert.ToInt32(dr["taskNameID"]);
                    data.Listener = ur.GetTeacherByID(Convert.ToInt32(dr["listener"]));
                    data.Week = dr["week"].ToString();
                    data.Contents = dr["contents"].ToString();
                    data.Publisher = ur.GetTeacherByID(Convert.ToInt32(dr["publisher"]));
                    data.PublishTime = Convert.ToDateTime(dr["time"].ToString());
                    data.IsStop = Convert.ToInt32(dr["isStop"].ToString());
                    list.Add(data);
                }
                dr.Close();
            }
            return list;
        }
        public bool UpdateTask(TaskByNameEntity task)
        {
            string sql = "update from tb_taskName set listener=@listener,week=@week,contents=@contents,publisher=@publisher,time=@time where tasknameid=@tasknameid";
            SqlParameter tasknameid = new SqlParameter("@tasknameid", task.TaskID);
            SqlParameter pTeacherTypeID = new SqlParameter("@listener", task.Listener.UserId);
            SqlParameter pWeek = new SqlParameter("@week", task.Week);
            SqlParameter pContents = new SqlParameter("@contents", task.Contents);
            SqlParameter pPublisher = new SqlParameter("@publisher", task.Publisher.UserId);
            SqlParameter pTime = new SqlParameter("@time", task.PublishTime);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, tasknameid, pTeacherTypeID, pWeek, pContents, pPublisher, pTime);
            return true;
        }

    }
}
