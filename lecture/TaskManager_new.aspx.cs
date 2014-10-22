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
using System.Text.RegularExpressions;

namespace lecture
{
    public partial class TaskManager_new : System.Web.UI.Page
    {
        [Inject]
        public ITaskByDetail itbd { get; set; }
        [Inject]
        public IUserRepository iur { get; set; }
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ICourse ic { get; set; }
        [Inject]
        public IDepartmentRepository idr { get; set; }

        static List<LessionRecord> listExcel = new List<LessionRecord>();
        static TaskByDetailEntity tbde = new TaskByDetailEntity();
        TaskByDetailRepository tbdr = new TaskByDetailRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User u = (User)Session["User"];
                Tools.bind_DropDownList<TeacherTypeInfo>(dd_type, irs.GetAllType(), "teacherType", "teacherTypeID");
                Tools.bind_DropDownList_all<TeacherTypeInfo>(dd_type0, irs.GetAllType(), "teacherType", "teacherTypeID");
                Tools.bind_DropDownList_all(dd_college, idr.GetAllDepartment(), "DepName", "DepId");
                Tools.add_year(dd_year);
                dd_year.SelectedIndex = Tools.SelectDD_Text(dd_year, DateTime.Now.Year.ToString());
                dd_month0.SelectedIndex = Tools.SelectDD_Value(dd_month0, DateTime.Now.Month.ToString());
                if (gv_rw.Rows.Count == 0)
                {
                    btn_export.Visible = false;
                }
                if (Session["User"] != null)
                {
                    //Tools.bind_DropDownList_all<TeacherTypeInfo>(dd_type0, irs.GetAllType(), "teacherType", "teacherTypeID");
                    if (u.UserType == "院级学生工作人员")
                    {
                        dd_college.SelectedIndex = Tools.SelectDD_Value(dd_college, u.UserDepartment.DepId.ToString());
                        dd_college.Enabled = false;
                    }
                    //List<LessionRecord> list = RDAL.GetRecordsByUserId(u.UserId);
                }
                else
                {
                    Find_Messages mess = new Find_Messages();
                    mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
                }
            }
        }

        protected void bt_search_Click(object sender, EventArgs e)
        {
            search();
            if (gv_rw.Rows.Count > 0)
            {
                btn_export.Visible = true;
            }
            else
            {
                btn_export.Visible = false;
            }
        }

        protected void gv_rw_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = true;
            tbde = itbd.GetTaskByID(Convert.ToInt32(gv_rw.Rows[e.NewSelectedIndex].Cells[2].Text));
            for (int i = 0; i < tbde.Contents.Count; i++)
            {
                tbde.Contents[i].dTime = tbde.Contents[i].dTime.Replace("|", "  ");
                tbde.Contents[i].dSpot = tbde.Contents[i].dSpot.Replace("|", "-");
            }
            Session["taskid"] = gv_rw.Rows[e.NewSelectedIndex].Cells[2].Text;
            tb_teacherName.Text = tbde.Teacher;
            dd_type.SelectedIndex = Tools.SelectDD_Text(dd_type, tbde.TeacherType);
            dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, tbde.taskDate.ToString());

            //DetailItem[] di = new DetailItem[tbde.Contents.Count];
            //for (int i = 0; i < tbde.Contents.Count; i++)
            //{
            //    di[i] = new DetailItem();
            //    di[i].dTime = tbde.Contents[i].dTime;
            //    di[i].dSpot = tbde.Contents[i].dSpot;
            //    di[i].dCourse = tbde.Contents[i].dCourse;
            //}
            GridView1.DataSource = tbde.Contents;
            GridView1.DataBind();
        }

        protected void gv_rw_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

                e.Row.Cells[1].Attributes.Add("onclick", "return confirm('你确认要删除吗?')");
                Panel1.Visible = false;
            }
        }
        protected void gv_rw_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(gv_rw.Rows[e.RowIndex].Cells[2].Text);
            tbdr.RemoveTask(ID);
            search();
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_time.Text != "" && tb_place.Text != "")
            {
                DetailItem item = new DetailItem();
                item.dTime = tb_time.Text + "  " + dd_time.SelectedItem.Text;
                item.dSpot = dd_spot.SelectedItem.Text + "-" + tb_place.Text;
                item.dCourse = tb_course.Text;
                tbde.Contents.Add(item);
                GridView1.DataSource = tbde.Contents;
                GridView1.DataBind();
            }
            else
            {
                lb_info.Text = "请添加录入信息";
                lb_info.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void bt_tj_Click(object sender, EventArgs e)
        {
            Find_Messages mess = new Find_Messages();

            tbde.TaskID = Convert.ToInt32(Session["taskid"]);
            tbde.Teacher = tb_teacherName.Text;
            tbde.TeacherType = dd_type.SelectedItem.Text;
            tbde.taskDate = Convert.ToInt32(dd_month.SelectedValue);
            //for (int i = 0; i < ListBox1.Items.Count; i++)
            //{
            //    DetailItem d = new DetailItem();
            //    String[] str = ListBox1.Items[i].Text.Split('|');
            //    d.dTime = str[0];
            //    d.dSpot = str[1];
            //    d.dCourse = str[2];
            //    task.Contents.Add(d);
            //}
            search();
            if (tbdr.UpdateTask(tbde))
            {
                //Tools.addTip(lb_info, "添加成功！", System.Drawing.Color.Green);
                mess.FinalMessage("修改成功！正在自动跳转...", "TaskManager_new.aspx", 1);
            }
            else
            {
                //addTip(lb_info, "添加失败！", System.Drawing.Color.Red);
                mess.FinalMessage("修改失败！请重新添加...", "TaskManager_new.aspx", 0);
            }
            search();
        }

        void search()
        {
            List<TaskByDetailEntity> tbte = new List<TaskByDetailEntity>();
            String post = "";
            if (dd_type0.SelectedItem.Text != "全部")
            {
                post = dd_type0.SelectedItem.Text;
            }
            tbte = tbdr.GetTaskByNameAndPost(tb_name.Text.Replace("[", "/["), post, dd_college.SelectedValue);

            tbte = tbte.FindAll(delegate(TaskByDetailEntity p) { return Convert.ToString(p.taskDate) == dd_month0.SelectedValue && Convert.ToString(p.PublishTime.Year) == dd_year.SelectedValue; });
            Session["TaskByDetailEntityExcel"] = tbte;
            gv_rw.DataSource = tbte;
            gv_rw.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tbde.Contents.RemoveAt(e.RowIndex);
            GridView1.DataSource = tbde.Contents;
            GridView1.DataBind();
        }

        protected void tb_time_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(tb_time.Text);
            lb_week.Text = Tools.DaysoOfTheWeek(Convert.ToDateTime(tb_time.Text));
            dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, dt.Month.ToString());
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            String records = "";
            //for (int i = 0; i < gv_rw.Rows.Count; i++)
            //{
            //    records += gv_rw.Rows[i].Cells[2].Text + "|";
            //}
            if (Session["TaskByDetailEntityExcel"] != null)
            {
                List<TaskByDetailEntity> tbte_excel = (List<TaskByDetailEntity>)Session["TaskByDetailEntityExcel"];
                for (int i = 0; i < tbte_excel.Count; i++)
                {
                    records += tbte_excel[i].TaskID + "|";
                }
            }

            if (records.Length > 0)
            {
                records = records.Substring(0, records.Length - 1);
            }
            Response.Redirect("~/Reports.aspx?recordsID=" + records + "");
        }

        protected void gv_rw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_rw.PageIndex = e.NewPageIndex;//更改当前页
            search();
        }

    }
}