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
    public class Department : IDepartment
    {
        [Inject]
        public IDepartmentRepository idr { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddDepartment(DepartmentInfo lr)
        {
            log.LogWriteByClass("执行AddDepartment()操作 时间：" + DateTime.Now.ToString() + "", "TeacherType");
            return idr.AddDepartment(lr);
        }

        public Boolean RemoveDepartment(int id)
        {
            return idr.RemoveDepartment(id);
        }

        public Boolean UpdateDepartment(DepartmentInfo lr)
        {
            return idr.UpdateDepartment(lr);
        }

        public DepartmentInfo GetDepartmentByID(int Id)
        {
            return idr.GetDepartmentByID(Id);
        }

        public List<DepartmentInfo> GetAllDepartment()
        {
            return idr.GetAllDepartment();
        }
    }
}