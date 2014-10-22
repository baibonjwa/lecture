using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Abstract
{
    public interface IDataReport
    {
        void Report<T>(List<T> rt);
    }

    public interface ILog
    {
        Boolean LogWriteByClass(String logMessage, String ClassName);
        //Boolean LogWrite(String logMessage);
        // List<String> LogReadByTime(DateTime StartTime,DateTime EndTime);
        // List<String> LogRead(DateTime StartTime, DateTime EndTime,String ClassName);
    }
    public interface IValidate
    {
        Boolean Validate();
    }
}