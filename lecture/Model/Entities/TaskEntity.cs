using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;

namespace lecture.Model.Entities
{
    public class TaskByDetailEntity : TaskEntityBase
    {
        public String Teacher { get; set; }
        public String TeacherType { get; set; }
        public int taskDate { get; set; }
        private List<DetailItem> _contents = new List<DetailItem>();
        public List<DetailItem> Contents
        {
            set
            {
                _contents = Contents;
            }
            get
            {
                return _contents;
            }
        }
        public void AddContent(DetailItem r)
        {
            _contents.Add(r);
        }
        public void RemoveContent(DetailItem r)
        {
            _contents.Remove(r);
        }
        public void ClearContent()
        {
            _contents.Clear();
        }
    }
    public class TaskByDetailReport : TaskEntityBase
    {
        public int taskDetailItem { get; set; }
        public int taskDetailID { get; set; }
        public String Teacher { get; set; }
        public String taskDate { get; set; }
        public String dTime { get; set; }
        public String dSpot { get; set; }
        public String dCourse { get; set; }
        public DetailItem Contents;

    }
    public class DetailItem
    {
        public int taskDetailItem { get; set; }
        public String dTime { get; set; }
        public String dSpot { get; set; }
        public String dCourse { get; set; }
        public int taskDetailID { get; set; }
    }


    public class TaskByNameEntity : TaskEntityBase
    {
        private Teacher listener;
        private String week;
        private String contents;

        public Teacher Listener
        {
            get { return listener; }
            set { listener = value; }
        }
        public String Week
        {
            get { return week; }
            set { week = value; }
        }
        public String Contents
        {
            get { return contents; }
            set { contents = value; }
        }
    }
    public class TaskByTypeEntity : TaskEntityBase
    {
        private TeacherTypeInfo teachertype;
        private String week;
        private String contents;



        public TeacherTypeInfo TeacherType
        {
            get { return teachertype; }
            set { teachertype = value; }
        }
        public String Week
        {
            get { return week; }
            set { week = value; }
        }
        public String Contents
        {
            get { return contents; }
            set { contents = value; }
        }
    }
}
