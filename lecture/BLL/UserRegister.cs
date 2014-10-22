using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using Ninject;

namespace lecture.BLL
{
    
    public class  UserRegister:IUserRegister
    {
        [Inject]
        public IUserRepository iur { set; get; }

        [Inject]
        public ILog ilog { set; get; }

        public Boolean AddUser(User u)
        {
            //UserLog
            ilog.LogWriteByClass("add", "UserRegister");
            iur.AddUser(u);
            return true;
        }

    }
}