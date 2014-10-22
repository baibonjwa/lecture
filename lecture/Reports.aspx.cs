using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using lecture.BLL;
using lecture.Model.Abstract;

namespace lecture
{
    public partial class Reports : System.Web.UI.Page
    {
        [Inject]
        public ITaskByDetailRepository itbd { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["recordsID"] != null)
                {
                    GridView1.DataSource = itbd.GetDetailItemByTaskDetailID(Request.QueryString["recordsID"].Split('|'));
                    GridView1.DataBind();
                }
            }
        }

        protected void btn_download_Click(object sender, EventArgs e)
        {
            Tools.GridViewToExcel(GridView1, "application/ms-exce", "temp.xls");
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}