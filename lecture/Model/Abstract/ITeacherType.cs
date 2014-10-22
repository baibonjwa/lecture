using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ITeacherType
    {
        Boolean AddType(TeacherTypeInfo lr);

        Boolean RemoveType(int id);

        Boolean UpdateRecord(TeacherTypeInfo lr);

        TeacherTypeInfo GetTypeById(int Id);

        List<TeacherTypeInfo> GetAllType();
    }
}