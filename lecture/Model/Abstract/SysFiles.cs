using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Abstract
{
    public abstract class SysFiles
    {
        public String FileType { set; get; }
        public int FileID { set; get; }
        public String FileName { set; get; }

        public abstract void SetFileContent();
    }
}