using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Abstract
{
    public interface IUserRegister
    {
        Boolean AddUser(User u);
    }
}