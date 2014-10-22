using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace lecture.Model.Abstract
{
    public abstract class TaskEntityBase
    {
        public int TaskID { set; get; }
        public User Publisher { set; get; }
        public DateTime PublishTime { set; get; }
        public int IsStop { set; get; }
    }
}
