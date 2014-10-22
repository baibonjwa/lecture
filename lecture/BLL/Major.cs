using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using Ninject;

namespace lecture.BLL
{
    public class Major : IMajor
    {
        [Inject]
        public IMajorRepository imr { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddMajor(MajorInfo lr)
        {
            log.LogWriteByClass("执行AddRecord()操作 时间：" + DateTime.Now.ToString() + "", "RecordSystem");
            return imr.AddMajor(lr);
        }

        public Boolean RemoveMajor(int id)
        {
            return imr.RemoveMajor(id);
        }

        public Boolean UpdateMajor(MajorInfo lr)
        {
            return imr.UpdateMajor(lr);
        }

        public MajorInfo GetMajorByID(int Id)
        {
            return imr.GetMajorByID(Id);
        }

        public List<MajorInfo> GetAllMajor()
        {
            return GetAllMajor();
        }
    }
}