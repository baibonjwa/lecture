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
    public partial class RecordDel : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem RDAL { get; set; }
        [Inject]
        public ITargetRepository itr { set; get; }
        [Inject]
        public UserRepository ur { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            User u = (User)Session["User"];
            if (!IsPostBack)
            {
                Teacher tea = ur.GetTeacherByID(u.UserId);
                lb_count.Text = itr.GetTargetByTypeID(tea.teacherType.TeacherTypeID).Count.ToString();
                Tools.add_year(dd_year);
                dd_year.SelectedIndex = Tools.SelectDD_Value(dd_year, DateTime.Now.Year.ToString());
                dd_mouth.SelectedIndex = Tools.SelectDD_Value(dd_mouth, DateTime.Now.Month.ToString());
                search(u.UserId);
                //这里计算总条数
            }
            if (Session["User"] != null)
            {
                search(u.UserId);
            }
            else
            {
                Find_Messages mess = new Find_Messages();
                mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
            }

        }
        void search(int id)
        {
            List<LessionRecord> list = RDAL.GetRecordsByUserId(id);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ClassSpot = list[i].ClassSpot.Replace("|", "-");
                String temp = "";
                String[] str = list[i].Class_Str.Split('|');
                for (int j = 0; j < str.Length - 1; j++)
                {
                    temp += str[j];
                    temp += "<br />";
                }
                temp += str[str.Length - 1];
                list[i].Class_Str = temp;
            }
            lb_mess0.Text = list.FindAll(delegate(LessionRecord p) { return p.RecordDate.Month == DateTime.Now.Month && p.RecordDate.Year == DateTime.Now.Year; }).Count.ToString();
            String year = dd_year.SelectedValue;
            list = list.FindAll(delegate(LessionRecord p) { return p.RecordDate.Month == Convert.ToInt32(dd_mouth.SelectedValue) && p.RecordDate.Year == Convert.ToInt32(dd_year.SelectedValue); });
            Tools.addTip(lb_monthCount, dd_mouth.SelectedItem.Text + "的记录总条数为" + list.FindAll(delegate(LessionRecord p) { return p.RecordDate.Month == Convert.ToInt32(dd_mouth.SelectedValue) && p.RecordDate.Year == Convert.ToInt32(dd_year.SelectedValue); }).Count.ToString() + "条", System.Drawing.Color.Green);
            gv_Del.DataSource = list;
            gv_Del.DataBind();
        }
        protected void gv_Del_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            //if (cmd == "Del")
            //{
            //    RDAL.RemoveRecord(id);
            //    User u = (User)Session["User"];
            //    gv_Del.DataSource = RDAL.GetRecordsByUserId(u.UserId);
            //    gv_Del.DataBind();
            //}
            //else if (cmd == "Edit")
            //{
            //    Session["id"] = id;
            //    Response.Redirect("RecordEdit.aspx");
            //}
            //else 
            if (cmd == "Sel")
            {
                Session["id"] = id;
                Response.Redirect("RecordCheck.aspx");
            }
        }

        protected void gv_Del_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                //添加删除确认
                //LinkButton linkButton = (LinkButton)e.Row.FindControl("ltbn_del");
                //linkButton.Attributes.Add("onclick", "return confirm('您确认要删除吗?');");
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            User u = (User)Session["User"];
            if (Session["User"] != null)
            {
                search(u.UserId);

            }
            else
            {
                Find_Messages mess = new Find_Messages();
                mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
            }
        }
    }
}