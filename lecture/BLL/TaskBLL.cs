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

    public class TaskByDetail : ITaskByDetail
    {
        //TaskByDetailRepository itdr = new TaskByDetailRepository();
        [Inject]
        public TaskByDetailRepository itdr { set; get; }

        [Inject]
        public ILog log { set; get; }

        private TaskEntityBase ConvertToA(TaskByDetailEntity b)
        {
            return (TaskEntityBase)b;
        }
        //private TaskByDetailRepository op = new TaskByDetailRepository();
        public bool AddTask(TaskByDetailEntity task)
        {
            log.LogWriteByClass("sdf", "sdf");
            return itdr.AddTask(task);
        }
        public bool RemoveTask(int id)
        {
            return itdr.RemoveTask(id);
        }
        public TaskByDetailEntity GetTaskByListener(Teacher user)
        {
            List<TaskByDetailEntity> list = itdr.GetAllTask();
            return list.Find(delegate(TaskByDetailEntity p) { return p.Teacher == user.UserName; });
        }
        public TaskByDetailEntity GetTaskByID(int id)
        {
            return itdr.GetTaskbyID(id);
        }
        //public override List<TaskEntityBase> SearchTask()
        //{
        //    return op.SearchTask().ConvertAll<TaskEntityBase>(new Converter<TaskByDetailEntity, TaskEntityBase>(ConvertToA));
        //}
        //new一个新方法，覆盖原方法
        //public List<TaskByDetailEntity> SearchTask()
        //{
        //    return itdr.SearchTask();
        //}
        public bool UpdateTask(TaskByDetailEntity task)
        {
            return itdr.UpdateTask(task);
        }
    }
    public class TaskByName : ITaskByName
    {
        [Inject]
        public TaskByNameRepository itnr { set; get; }
        //TaskByNameRepository itnr = new TaskByNameRepository();

        [Inject]
        public ILog log { set; get; }

        private TaskEntityBase ConvertToA(TaskByNameEntity b)
        {
            return (TaskEntityBase)b;
        }
        public TaskByNameEntity task = new TaskByNameEntity();
        //private TaskByNameRepository op = new TaskByNameRepository();
        public bool AddTask(TaskByNameEntity task)
        {
            //按姓名添加的非空验证
            if (task.Publisher == null || task.Listener == null || task.Contents == "" || task.PublishTime == null)
            {
                return false;
            }
            log.LogWriteByClass("执行AddTask()操作", "TaskByName");
            return itnr.AddTask(task);
        }
        public bool RemoveTask(int id)
        {
            return itnr.RemoveTask(id);
        }
        public List<TaskByNameEntity> SearchTask()
        {
            return itnr.GetAllTask();
        }
        //public override List<TaskEntityBase> SearchTask()
        //{
        //    return op.SearchTask().ConvertAll<TaskEntityBase>(new Converter<TaskByNameEntity, TaskEntityBase>(ConvertToA));
        //}
        public bool UpdateTask(TaskByNameEntity task)
        {
            return itnr.UpdateTask(task);
        }
        public TaskByNameEntity GetTaskByListener(Teacher user)
        {
            List<TaskByNameEntity> list = itnr.GetAllTask();
            return list.Find(delegate(TaskByNameEntity p) { return p.Listener.UserName == user.UserName; });
        }
    }
    public class TaskByType : ITaskByType
    {
        //TaskByTypeRepository ittr = new TaskByTypeRepository();
        [Inject]
        public TaskByTypeRepository ittr { set; get; }

        [Inject]
        public ILog log { set; get; }


        private TaskEntityBase ConvertToA(TaskByTypeEntity b)
        {
            return (TaskEntityBase)b;
        }
        public TaskByTypeEntity task = new TaskByTypeEntity();
        //private TaskByTypeRepository op = new TaskByTypeRepository();
        public bool AddTask(TaskByTypeEntity task)
        {
            //按类型添加的非空验证
            if (task.Contents == "" || task.Publisher == null || task.PublishTime == null || task.TeacherType != null || task.Week == null || task.Contents == "")
            {
                return false;
            }
            log.LogWriteByClass("执行AddTask()操作", "TaskByType");
            return ittr.AddTask(task);
        }
        public bool RemoveTask(int id)
        {
            return ittr.RemoveTask(id);
        }
        public List<TaskByTypeEntity> SearchTask()
        {
            return ittr.GetAllTask();
        }
        //public override List<TaskEntityBase> SearchTask()
        //{
        //    return op.SearchTask().ConvertAll<TaskEntityBase>(new Converter<TaskByTypeEntity, TaskEntityBase>(ConvertToA));
        //}
        public bool UpdateTask(TaskByTypeEntity task)
        {
            return ittr.UpdateTask(task);
        }
        public TaskByTypeEntity GetTaskByType(Teacher user)
        {
            List<TaskByTypeEntity> list = ittr.GetAllTask();
            return list.Find(delegate(TaskByTypeEntity p) { return p.TeacherType.TeacherTypeID == user.teacherType.TeacherTypeID; });
        }
    }
}
