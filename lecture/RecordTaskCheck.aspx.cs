using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using lecture.BLL;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;


namespace lecture
{
    public partial class RecordTaskCheck : System.Web.UI.Page
    {
        [Inject]
        public ITaskByDetail itbd { get; set; }
        [Inject]
        public IUserRepository iur { get; set; }
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ICourse ic { get; set; }
        TaskByDetailRepository tbdr = new TaskByDetailRepository();
        Find_Messages mess = new Find_Messages();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, DateTime.Now.Month.ToString());
                Tools.add_year(dd_year);
                dd_year.SelectedIndex = Tools.SelectDD_Value(dd_year, DateTime.Now.Year.ToString());
                search();

            }

        }

        protected void gv_rw_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

            }
        }

        protected void gv_rw_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //ListBox1.Items.Clear();
            //ListBox1.Visible = true;
            TaskByDetailEntity tbde = new TaskByDetailEntity();
            tbde = itbd.GetTaskByID(Convert.ToInt32(gv_rw.Rows[e.NewSelectedIndex].Cells[1].Text));
            GridView1.Visible = true;
            GridView1.DataSource = tbde.Contents;
            GridView1.DataBind();

            //for (int i = 0; i < tbde.Contents.Count; i++)
            //{
            //    string str = "";
            //    str += "时间：" + tbde.Contents[i].dTime + "；";
            //    str += "地点：" + tbde.Contents[i].dSpot + "；";
            //    str += "课程：" + tbde.Contents[i].dCourse + "。";
            //    ListBox1.Items.Add(str);
            //}
        }
        void search()
        {
            User u = (User)Session["User"];
            if (Session["User"] != null)
            {
                List<TaskByDetailEntity> tbte = new List<TaskByDetailEntity>();
                tbte = tbdr.GetTaskbyName(u.RealName + "[" + u.UserName + "]");
                tbte = tbte.FindAll(delegate(TaskByDetailEntity p) { return Convert.ToString(p.taskDate) == dd_month.SelectedValue && Convert.ToString(p.PublishTime.Year) == dd_year.SelectedValue; });
                gv_rw.DataSource = tbte;
                gv_rw.DataBind();
            }
            else
            {
                mess.FinalMessage2("登录信息失效，请重新登录！", "index.aspx", 0, 2);
            }
        }
        protected void bt_search_Click(object sender, EventArgs e)
        {
            search();
            GridView1.Visible = false;
        }

        protected void gv_rw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_rw.PageIndex = e.NewPageIndex;//更改当前页
            search();
        }
    }
}