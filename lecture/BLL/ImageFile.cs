using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;

namespace lecture.BLL
{
    public class ImageFile:SysFiles
    {
        private byte[] FileContent { get; set; }

        public override void SetFileContent()
        {

        }
    }
}