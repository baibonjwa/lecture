using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;

namespace lecture.BLL
{
    public class TaskLog : ILog
    {
        public Boolean LogWriteByClass(String logMessage, String ClassName)
        {
            return true;
        }
        public Boolean LogWrite(String logMessage)
        {
            return true;
        }
        public String LogReadByTime(DateTime StartTime, DateTime EndTime)
        {
            return "0";
        }
        public String LogRead(DateTime StartTime, DateTime EndTime, String ClassName)
        {
            return "0";
        }
    }
}
