using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ITaskByDetailRepository
    {
        bool AddTask(TaskByDetailEntity task);
        bool RemoveTask(int id);
        List<TaskByDetailEntity> GetAllTask();
        bool UpdateTask(TaskByDetailEntity task);
        List<DetailItem> GetDetailItemByTaskDetailID(int id);
        List<TaskByDetailReport> GetDetailItemByTaskDetailID(String[] id);
        //public TaskByDetailEntity GetTaskbyID(int id);
    }
    public interface ITaskByTypeRepository
    {
        bool AddTask(TaskByTypeEntity task);
        bool RemoveTask(int id);
        List<TaskByTypeEntity> GetAllTask();
        bool UpdateTask(TaskByTypeEntity task);
    }
    public interface ITaskByNameRepository
    {
        bool AddTask(TaskByNameEntity task);
        bool RemoveTask(int id);
        List<TaskByNameEntity> GetAllTask();
        bool UpdateTask(TaskByNameEntity task);
    }
}
