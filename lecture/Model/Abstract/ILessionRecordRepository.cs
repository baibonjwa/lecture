using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface ILessionRecordRepository
    {
        Boolean AddRecord(LessionRecord lr);
        Boolean AddRecord_New(LessionRecord lr);
        Boolean DeleteRecord(int id);
        Boolean UpdateRecord(LessionRecord lr);
        Boolean UpdateRecordState(LessionRecord lr);
        List<LessionRecord> GetRecordsById(int userId);
        List<LessionRecord> GetRecordsByYearAndMonth(String Year, String Month);
        List<LessionRecord> SelectedRecordIsPass(String state);
        LessionRecord SelectedRecord(int recordId);
    }
}