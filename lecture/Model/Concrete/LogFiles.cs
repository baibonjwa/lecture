using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using System.IO;

namespace lecture.Model.Concrete
{
    public class LogFiles : ILog
    {
        public Boolean LogWriteByClass(String logMessage, String ClassName)
        {
            string file = HttpContext.Current.Server.MapPath("~/") + "Files/Upload/logfiles.txt";
            StreamWriter sw = File.AppendText(file);

            sw.WriteLine(logMessage); //使用WriteLine写入内容

            sw.WriteLine(ClassName);

            sw.Flush(); //将缓冲区的内容写入文件

            sw.Close(); //关闭sw对象

            return true;

        }
    }
}