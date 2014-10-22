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
    public partial class taskadd_sub : System.Web.UI.Page
    {
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ITaskByType itbt { get; set; }
        [Inject]
        public IUserRepository iur { get; set; }
        [Inject]
        public ITaskByDetail itbd { get; set; }
        //TaskByDetailEntity tbde = new TaskByDetailEntity();
        protected void Page_Load(object sender, EventArgs e)
        {

            lb_info.Text = "";
            if (!IsPostBack)
            {
                if (GridView1.Rows.Count == 0)
                {
                    bt_tj.Visible = false;
                }
                TaskByDetailEntity data = new TaskByDetailEntity();
                Session["data"] = data;
                Tools.bind_DropDownList<TeacherTypeInfo>(dd_type, irs.GetAllType(), "teacherType", "teacherTypeID");
                if (Session["User"] != null)
                {
                    User tea = (User)(Session["User"]);
                    if (tea.UserType == "听课教师")
                    {
                        tb_name.Text = tea.RealName + "[" + tea.UserName + "]";
                        tb_name.Enabled = false;
                        Teacher teach = iur.GetTeacherByID(tea.UserId);
                        dd_type.SelectedIndex = Tools.SelectDD_Text(dd_type, teach.teacherType.TeacherType);
                        dd_type.Enabled = false;
                    }
                }
                dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, DateTime.Now.Month.ToString());
            }
        }
        protected void bt_add_Click(object sender, EventArgs e)
        {
            lb_infotime.Text = "";
            lb_info.Text = "";
            lb_infocouse.Text = "";
            DateTime dTime = new DateTime();
            try
            {
                dTime = Convert.ToDateTime(tb_time.Text);
            }
            catch
            {
                dTime = DateTime.Now.AddDays(-100);
            }
            DateTime dt = DateTime.Now;
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
            if (tb_place.Text == "")
            {
                lb_info.Text = "请添加听课地点";
                lb_info.ForeColor = System.Drawing.Color.Red;
            }
            else if (tb_time.Text == "")
            {
                lb_infotime.Text = "请添加听课时间";
                lb_infotime.ForeColor = System.Drawing.Color.Red;
            }
            else if (tb_course.Text == "")
            {
                lb_infocouse.Text = "请添加课程名称";
                lb_infocouse.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                DetailItem item = new DetailItem();
                item.dTime = tb_time.Text + "  " + dd_time.SelectedItem.Text;
                item.dSpot = dd_spot.SelectedItem.Text + "-" + tb_place.Text;
                item.dCourse = tb_course.Text;

                TaskByDetailEntity data = (TaskByDetailEntity)Session["data"];
                data.Contents.Add(item);
                Session["data"] = data;
                GridView1.DataSource = data.Contents;
                GridView1.DataBind();
            }
            Tools.addTip(lb_mess, "添加的任务需要点击下方的提交按钮之后才能将上述信息提交到系统！", System.Drawing.Color.Red);
            if (GridView1.Rows.Count > 0)
            {
                bt_tj.Visible = true;
            }
            else
            {
                bt_tj.Visible = false;
            }
        }

        protected void bt_tj_Click(object sender, EventArgs e)
        {
            TeacherTypeInfo tti = new TeacherTypeInfo();
            TaskByDetailEntity tbde = new TaskByDetailEntity();
            CourseRepository cr = new CourseRepository();
            Find_Messages mess = new Find_Messages();

            tbde.Teacher = tb_name.Text;
            tbde.TeacherType = dd_type.SelectedItem.Text;
            tbde.IsStop = 0;
            tbde.PublishTime = DateTime.Now;
            tbde.taskDate = Convert.ToInt32(dd_month.SelectedValue);


            DetailItem[] di = new DetailItem[GridView1.Rows.Count];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                di[i] = new DetailItem();
                di[i].dTime = GridView1.Rows[i].Cells[0].Text;
                di[i].dSpot = GridView1.Rows[i].Cells[1].Text;
                di[i].dCourse = GridView1.Rows[i].Cells[2].Text;
                tbde.AddContent(di[i]);
            }
            if (tb_pwd.Text != "fluid")
            {
                mess.FinalMessage("添加失败！提交密码错误", "RecordTaskCheck.aspx", 0);
            }
            else if (itbd.AddTask(tbde))
            {
                //Tools.addTip(lb_info, "添加成功！", System.Drawing.Color.Green);
                mess.FinalMessage("添加成功！正在自动跳转...", "RecordTaskCheck.aspx", 0);
            }
            else
            {
                //Tools.addTip(lb_info, "添加失败！", System.Drawing.Color.Red);
                mess.FinalMessage("添加失败！请重新添加...", "taskadd_new.aspx", 0);
            }

        }

        protected void bt_remove_Click(object sender, EventArgs e)
        {
            //LB_contents.Items.Remove(LB_contents.SelectedItem);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TaskByDetailEntity data = (TaskByDetailEntity)Session["data"];
            data.Contents.RemoveAt(e.RowIndex);
            GridView1.DataSource = data.Contents;
            GridView1.DataBind();
        }

        protected void tb_time_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(tb_time.Text);

            lb_week.Text = Tools.DaysoOfTheWeek(Convert.ToDateTime(tb_time.Text));
            dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, dt.Month.ToString());
        }


    }
}