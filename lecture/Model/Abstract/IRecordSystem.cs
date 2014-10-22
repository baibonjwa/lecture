using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IRecordSystem
    {
        Boolean AddRecord(LessionRecord lr);

        Boolean RemoveRecord(int id);

        List<LessionRecord> GetRecordsByUserId(int userId);

        List<LessionRecord> GetRecordsByYearAndMonth(String Year, String Month);

        LessionRecord SelectRecord(int recordId);

        Boolean UpdateRecord(LessionRecord lr);
    }
}