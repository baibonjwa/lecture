using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ITargetRepository
    {
        Boolean AddTarget(TargetInfo lr);
        Boolean RemoveTarget(TargetInfo lr);
        Boolean UpdateTarget(TargetInfo lr);
        TargetInfo GetTargetByTypeID(int Id);
        TargetInfo GetTargetByType(String name);
        List<TargetInfo> GetAllTarget();
    }
}