using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using Ninject;

namespace lecture.BLL
{
    public class RecordSystem : IRecordSystem
    {
        [Inject]
        public ILessionRecordRepository ilrr { set; get; }

        [Inject]
        public ILog log { set; get; }

        public Boolean AddRecord(LessionRecord lr)
        {
            log.LogWriteByClass("执行AddRecord()操作 时间：" + DateTime.Now.ToString() + "", "RecordSystem");
            //log.LogWriteByClass("b", "RecordSystem");
            return ilrr.AddRecord_New(lr);
        }

        public Boolean RemoveRecord(int id)
        {
            return ilrr.DeleteRecord(id);
        }

        public List<LessionRecord> GetRecordsByUserId(int userId)
        {
            return ilrr.GetRecordsById(userId);
        }
        public List<LessionRecord> GetRecordsByYearAndMonth(String Year, String Month)
        {
            return ilrr.GetRecordsByYearAndMonth(Year, Month);
        }
        public List<LessionRecord> SelectRecordIsPass(String state)
        {
            return ilrr.SelectedRecordIsPass(state);
        }

        public LessionRecord SelectRecord(int recordId)
        {
            return ilrr.SelectedRecord(recordId);
        }

        public Boolean UpdateRecord(LessionRecord lr)
        {
            return ilrr.UpdateRecord(lr);
        }
        public Boolean UpdateRecordState(LessionRecord lr)
        {
            return ilrr.UpdateRecordState(lr);
        }
        //public void aaa()
        //{

        //}
    }
}