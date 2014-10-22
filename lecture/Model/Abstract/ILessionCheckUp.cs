using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ILessionCheckUp
    {
        int[] TaskCount(Teacher user, int week);
        TargetInfo GetTarget(Teacher user);
    }

}