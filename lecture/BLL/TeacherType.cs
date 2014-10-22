using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using lecture.Model.Abstract;
using lecture.Model.Entities;

namespace lecture.BLL
{
    public class TeacherType : ITeacherType
    {
        [Inject]
        public ITeacherTypeRepsoitory itt { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddType(TeacherTypeInfo lr)
        {
            log.LogWriteByClass("执行AddType()操作 时间：" + DateTime.Now.ToString() + "", "TeacherType");
            return itt.AddType(lr);
        }

        public Boolean RemoveType(int id)
        {
            return itt.RemoveType(id);
        }

        public Boolean UpdateRecord(TeacherTypeInfo lr)
        {
            return itt.UpdateRecord(lr);
        }
        public TeacherTypeInfo GetTypeById(int Id)
        {
            return itt.GetTypeById(Id);
        }


        public List<TeacherTypeInfo> GetAllType()
        {
            return itt.GetAllType();
        }

    }
}