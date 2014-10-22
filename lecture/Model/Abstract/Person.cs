using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Abstract
{
    public abstract class Person
    {
        public int PersonId { set; get; }
        public String PersonName { set; get; }
        public String IsStop { set; get; }
        public String PersonType { set; get; }
        public abstract String GetTeacher();
    }
}