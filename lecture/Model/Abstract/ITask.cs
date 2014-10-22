using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ITask
    {

    }
    public interface ITaskByDetail : ITask
    {
        bool AddTask(TaskByDetailEntity task);
        bool RemoveTask(int id);
        //public abstract List<TaskEntityBase> SearchTask();
        bool UpdateTask(TaskByDetailEntity task);
        TaskByDetailEntity GetTaskByListener(Teacher user);
        TaskByDetailEntity GetTaskByID(int id);
    }
    public interface ITaskByName : ITask
    {
        bool AddTask(TaskByNameEntity task);
        bool RemoveTask(int id);
        //public abstract List<TaskEntityBase> SearchTask();
        bool UpdateTask(TaskByNameEntity task);
    }
    public interface ITaskByType : ITask
    {
        bool AddTask(TaskByTypeEntity task);
        bool RemoveTask(int id);
        //public abstract List<TaskEntityBase> SearchTask();
        bool UpdateTask(TaskByTypeEntity task);
    }
}