using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using lecture.Model.Concrete;
using Ninject;

namespace lecture.BLL
{
    public class LessionCheckUp : ILessionCheckUp
    {
        [Inject]
        public ITargetRepository itr { set; get; }
        [Inject]
        public TaskByType ittr { set; get; }
        [Inject]
        public TaskByName itnr { set; get; }
        [Inject]
        public TaskByDetail itdr { set; get; }
        [Inject]
        public RecordSystem rs { set; get; }
        //[Inject]
        //public ITargetRepository itr { set; get; }

        [Inject]
        private ILog log { set; get; }
        public int[] TaskCount(Teacher user, int week)
        {
            int[] results = new int[3];
            ////取出指标
            //TargetInfo ti = GetTarget(user);
            ////计算使用该系统的学期
            //DateTime dt_start = new DateTime();
            //DateTime dt_end = new DateTime();
            //if (DateTime.Now.Month == 1)
            //{
            //    dt_start = new DateTime(DateTime.Now.Year - 1, 8, 1);
            //    dt_end = new DateTime(DateTime.Now.Year, 2, 1);
            //}
            //else if (DateTime.Now.Month >= 8 && DateTime.Now.Month <= 12)
            //{
            //    dt_start = new DateTime(DateTime.Now.Year, 8, 1);
            //    dt_end = new DateTime(DateTime.Now.Year + 1, 2, 1);
            //}
            //else if (DateTime.Now.Month >= 2 && DateTime.Now.Month <= 7)
            //{
            //    dt_start = new DateTime(DateTime.Now.Year, 2, 1);
            //    dt_end = new DateTime(DateTime.Now.Year, 7, 1);
            //}


            ////假设共有23周
            ////ti.Week是每n周 
            ////  (23/ti.Week)取整是轮回总数   week/ti.week是现在所在第几个轮回
            ////  该轮回的周次为。下限(week/ti.week)*ti.week+1  上限(week/ti.week)*ti.week+ti.week
            ////ti.Count是每周听课0数

            ////取出三种听课任务
            //TaskByDetailEntity tbde = itdr.GetTaskByListener(user);
            //TaskByTypeEntity tbte = ittr.GetTaskByType(user);
            //TaskByNameEntity tbne = itnr.GetTaskByListener(user);

            //String[] taskWeek = tbne.Week.Split(',');

            ////取出听课记录
            //List<LessionRecord> record = rs.GetRecordsByUserId(user.UserId);
            ////取出对应时间的记录
            //int endWeek = 0;
            //int startWeek = 0;
            //if (ti.Week == 1)
            //{
            //    endWeek = (week / ti.Week) * ti.Week + ti.Week - 1;
            //    startWeek = (week / ti.Week) * ti.Week;
            //}
            //else
            //{
            //    endWeek = (week / ti.Week) * ti.Week + ti.Week;
            //    startWeek = (week / ti.Week) * ti.Week + 1;
            //}
            //record = record.FindAll(delegate(LessionRecord p) { return p.WeekNumber <= endWeek && p.WeekNumber >= startWeek; });
            //record = record.FindAll(delegate(LessionRecord p) { return DateTime.Compare(p.RecordDate, dt_end) < 0 && DateTime.Compare(p.RecordDate, dt_start) > 0; });



            ////计算有效听课记录
            //int effect = 0;
            //for (int i = 0; i < record.Count; i++)
            //{
            //    //和具体任务对比
            //    if (tbde != null && tbde.Time == record[i].RecordDate && tbde.Course.CouresID == record[i].Course.CouresID && tbde.Listener.UserId == record[i].Listener.UserId)
            //    {
            //        effect++;
            //        continue;
            //    }
            //    //和姓名任务对比
            //    if (user.UserName == tbne.Listener.UserName)
            //    {
            //        if (taskWeek[GetWeek(record[i].RecordDate) - 1] == "1")
            //        {
            //            effect++;
            //            continue;
            //        }
            //    }
            //    if (user.teacherType.TeacherTypeID == tbte.TeacherType.TeacherTypeID)
            //    {
            //        if (taskWeek[GetWeek(record[i].RecordDate) - 1] == "1")
            //        {
            //            effect++;
            //            continue;
            //        }
            //    }
            //}

            //results[0] = ti.Count;
            //results[1] = effect;
            //results[2] = ti.Count - effect < 0 ? 0 : ti.Count - effect;
            return results;
        }
        public TargetInfo GetTarget(Teacher user)
        {
            return itr.GetTargetByTypeID(user.teacherType.TeacherTypeID); ;
        }
        private int GetWeek(DateTime datePoint)//函数作用是接受某一天，然后返回该日期所处星期的第一天
        {
            int result = 0;
            //新建要返回的变量
            //其实到此为止。。就已经判断完所处本周中哪一天了。 C#自带了这个方法，只不过DayOfWeek不是一个基本类型，需要用string取出来。
            //转换为我们可以判断操作的string类型
            DayOfWeek day = datePoint.DayOfWeek;
            string dayString = day.ToString();
            //switch判断
            switch (dayString)
            {
                case "Monday":
                    //若就是星期一，那本周开头一天就是这个传进来的变量
                    result = 1;
                    break;
                case "Tuesday":
                    //以此类推
                    result = 2;
                    break;
                case "Wednesday":
                    result = 3;
                    break;
                case "Thursday":
                    result = 4;
                    break;
                case "Friday":
                    result = 5;
                    break;
                case "Saturday":
                    result = 6;
                    break;
                case "Sunday":
                    result = 7;
                    break;
            }
            //switch
            return result;
        }

    }
}