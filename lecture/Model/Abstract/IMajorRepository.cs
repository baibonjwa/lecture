using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IMajorRepository
    {
        Boolean AddMajor(MajorInfo lr);

        Boolean RemoveMajor(int id);

        Boolean UpdateMajor(MajorInfo lr);

        MajorInfo GetMajorByID(int Id);

        List<MajorInfo> GetAllMajor();
    }
}