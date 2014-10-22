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
    public partial class RecordFinish : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem RDAL { get; set; }
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ITargetRepository itr { set; get; }
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public IDepartmentRepository idr { get; set; }

        static List<LessionRecord> listExcel = new List<LessionRecord>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_info.Text = "";
            User u = (User)Session["User"];
            if (!IsPostBack)
            {
                gv_Del.Attributes.Add("style", "word-break:keep-all;word-wrap:keep-all");
                Tools.bind_DropDownList(dd_college, idr.GetAllDepartment(), "DepName", "DepId");
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

                //dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, DateTime.Now.Month.ToString());
                Tools.add_year(dd_year);
                dd_year.SelectedIndex = Tools.SelectDD_Value(dd_year, DateTime.Now.Year.ToString());
                dd_month.SelectedIndex = Tools.SelectDD_Value(dd_month, DateTime.Now.Month.ToString());
                dd_time.SelectedIndex = 1;
                //这里计算总条数
            }
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
                Response.Redirect("RecordMDis.aspx");
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

        protected void bt_search_Click(object sender, EventArgs e)
        {
            search();
        }
        void search()
        {
            User nu = new User();
            if (Session["User"] != null)
            {
                //nu = iurr.GetUserByRealName(tb_name.Text);
                //if (nu != null)
                //{
                //List<LessionRecord> list=RDAL.GetRecordsByUserId(nu.UserId);
                List<LessionRecord> list = RDAL.GetRecordsByYearAndMonth(dd_year.SelectedItem.Value, dd_month.SelectedItem.Value);
                // list = list.FindAll(delegate(LessionRecord p) { return Convert.ToString(p.RecordDate.Month) == dd_month.SelectedValue && Convert.ToString(p.RecordDate.Year) == dd_year.SelectedValue; });
                list = list.FindAll(delegate(LessionRecord p) { return p.Listener.UserDepartment.DepId == Convert.ToInt32(dd_college.SelectedValue); });
                if (tb_name.Text != "")
                {
                    list = list.FindAll(delegate(LessionRecord p) { return p.Listener.RealName == tb_name.Text; });
                }
                if (dd_time.Text != "0")
                {
                    switch (dd_time.SelectedValue)
                    {
                        case "1":
                            list = list.FindAll(delegate(LessionRecord p) { return p.RecordDate > DateTime.Now.AddDays(-7); });
                            break;
                        case "2":
                            list = list.FindAll(delegate(LessionRecord p) { return p.RecordDate > DateTime.Now.AddDays(-14); });
                            break;
                        case "3":
                            list = list.FindAll(delegate(LessionRecord p) { return p.RecordDate > DateTime.Now.AddDays(-21); });
                            break;
                    }
                }
                listExcel = list;
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
                gv_Del.DataSource = list;
                gv_Del.DataBind();
                //}
                //else
                //{
                //    Tools.addTip(lb_info, "未找到该教师听课记录，请确认姓名是否正确！", System.Drawing.Color.Red);
                //}
            }
            else
            {
                Find_Messages m = new Find_Messages();
                m.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
            }
        }

        protected void btn_excel_Click(object sender, EventArgs e)
        {
            String[] items = new String[32];
            items[0] = "周次";
            items[1] = "日期";
            items[2] = "时间";
            items[3] = "地点";
            items[4] = "专业班级";
            items[5] = "授课教师";
            items[6] = "课程类别";
            items[7] = "课程名称";
            items[8] = "迟到";
            items[9] = "早退";
            items[10] = "旷课";
            items[11] = "应到";
            items[12] = "实到";
            items[13] = "参与互动教学";
            items[14] = "主动回答问题";
            items[15] = "课堂笔记";
            items[16] = "上课带教材";
            items[17] = "其他";
            items[18] = "教室卫生";
            items[19] = "教师桌椅";
            items[20] = "投影仪";
            items[21] = "音响";
            items[22] = "其他";
            items[23] = "吃东西情况";
            items[24] = "说笑情况";
            items[25] = "随意走动情况";
            items[26] = "睡觉情况";
            items[27] = "摆弄手机情况";
            items[28] = "其他";
            items[29] = "其它情况";
            items[30] = "听课人";
            items[31] = "单位";
            Tools.ListToExcel(listExcel, "temp.xls", items);
            listExcel = null;
        }

        protected void gv_Del_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Del.PageIndex = e.NewPageIndex;//更改当前页
            search();
        }


    }
}