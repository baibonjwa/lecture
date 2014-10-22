using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IClassRepository
    {
        Boolean AddClass(ClassInfo lr);

        Boolean RemoveClass(int id);

        Boolean UpdateClass(ClassInfo lr);

        ClassInfo GetClassByID(int Id);

        List<ClassInfo> GetAllClass();
    }
}