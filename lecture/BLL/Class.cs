using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;
using lecture.Model.Abstract;
using Ninject;

namespace lecture.BLL
{
    public class Class : IClass
    {
        [Inject]
        public IClassRepository itt { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddClass(ClassInfo lr)
        {
            log.LogWriteByClass("执行AddClass()操作 时间：" + DateTime.Now.ToString() + "", "Class");
            return itt.AddClass(lr);
        }

        public Boolean RemoveClass(int id)
        {
           ClassInfo ci = itt.GetClassByID(id);
           log.LogWriteByClass("执行RemoveClass()操作 ClassDep: " + ci.ClassDep.ToString() + " ClassId: " + ci.ClassId.ToString() + " ClassMajor: " + ci.ClassMajor.ToString() + " ClassName: " + ci.ClassName.ToString() + " IsStop: " + ci.IsStop.ToString() + " 时间：" + DateTime.Now.ToString() + "", "Class");
           return itt.RemoveClass(id);
        }

        public Boolean UpdateClass(ClassInfo lr)
        {
            return itt.UpdateClass(lr);
        }

        public ClassInfo GetClassByID(int Id)
        {
            return itt.GetClassByID(Id);
        }

        public List<ClassInfo> GetAllClass()
        {
            return itt.GetAllClass();
        }
    }
}