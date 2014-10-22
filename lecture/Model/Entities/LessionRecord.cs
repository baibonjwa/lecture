using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;

namespace lecture.Model.Entities
{
    public class LessionRecord
    {
        public int Id { set; get; }
        public int WeekNumber { set; get; }
        public DateTime RecordDate { set; get; }
        public String ClassSpot { set; get; }
        public CourseInfo Course { set; get; }
        public String Course_Str { set; get; }
        public String Class_Str { set; get; }
        public String CourseTeacher_Str { set; get; }
        public String RecordTime_Str { set; get; }
        public String filePath_Str { set; get; }
        public String CourseType_Str { set; get; }
        public String State { set; get; }
        private List<RecordItem> _contents = new List<RecordItem>();
        public List<RecordItem> Contents
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
        public User Listener { set; get; }
        public List<SysFiles> Files { set; get; }

        public void AddContent(RecordItem r)
        {
            _contents.Add(r);
        }
        public void RemoveContent(RecordItem r)
        {
            _contents.Remove(r);
        }

        public void ClearContent()
        {
            _contents.Clear();
        }

        public void AddFile(SysFiles f)
        {
            Files.Add(f);
        }

        public void RemoveFile(SysFiles f)
        {
            Files.Remove(f);
        }
        public void ClearFile()
        {
            Files.Clear();
        }
    }

    public class ItemTypeInfo
    {
        public int ItemTypeID { set; get; }
        public String ItemType { set; get; }
        public String ItemName { set; get; }
        public String ItemDescription { set; get; }
    }
}