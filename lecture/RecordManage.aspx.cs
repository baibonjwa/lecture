using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using lecture.BLL;

namespace lecture
{
    public partial class RecordManage : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem RDAL { get; set; }
        [Inject]
        public ILessionCheckUp LCU { get; set; }
        [Inject]
        public IUserRepository tcher { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                User u = (User)Session["User"];
                if (Session["User"] != null)
                {
                    gv_check.DataSource = RDAL.GetRecordsByUserId(u.UserId);
                    gv_check.DataBind();
                    lb_mess0.Text = RDAL.GetRecordsByUserId(u.UserId).Count.ToString();
                }
                else
                {
                    Find_Messages mess = new Find_Messages();
                    mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0,2); 
                }

   
            }
            
        }

        protected void gv_check_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }
    }
}