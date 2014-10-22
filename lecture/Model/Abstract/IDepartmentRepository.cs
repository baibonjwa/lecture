using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IDepartmentRepository
    {
        Boolean AddDepartment(DepartmentInfo lr);

        Boolean RemoveDepartment(int id);

        Boolean UpdateDepartment(DepartmentInfo lr);

        DepartmentInfo GetDepartmentByID(int Id);

        List<DepartmentInfo> GetAllDepartment();
    }
}