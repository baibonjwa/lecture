using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using lecture.BLL;
using Ninject;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using System.Collections.Generic;

namespace lecture
{
    public partial class TaskManage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TaskByTypeRepository tbtr = new TaskByTypeRepository();
            IList task = tbtr.GetAllTask();
            DataSet ds = Tools.ListToDataSet(task);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btn_typeAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
