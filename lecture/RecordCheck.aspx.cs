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
    public partial class RecordCheck : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem ILR { get; set; }
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public ICourse ic { get; set; }
        [Inject]
        public IItemTypeRepository iitr { get; set; }
        [Inject]
        public ILessionRecordRepository ILRR { get; set; }


        Find_Messages mess = new Find_Messages();

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_del.Attributes.Add("onclick", "return confirm('确认要删除吗？');");
            if (!IsPostBack)
            {      
                User u = (User)Session["User"];
                if (Session["User"] != null)
                {
                    if (u.UserType == "学生工作人员")
                    {
                        btn_update.Visible = true;
                        btn_go.Visible = false;
                        btn_del.Visible = false;
                    }
                    else if (u.UserType == "听课教师")
                    {
                        btn_update.Visible = true;
                        btn_go.Visible = false;
                        btn_del.Visible = false;
                    }
                }
                else
                {
                    mess.FinalMessage2("登录信息已失效，请重新登录！", "index.aspx", 0, 2);
                }
                BindInfo();
            }
        }
        protected void BindInfo()
        {
            int id = Convert.ToInt32(Session["id"]);
            if (Session["id"] != null)
            {
                LessionRecord LR = new LessionRecord();
                LR = ILR.SelectRecord(id);

                btn_del.Visible = false;
                switch (LR.State)
                {
                    case "正常":
                        lb_info.Text = "";
                        break;
                    case "待审核":
                        Tools.addTip(lb_info, "申请已提交，请等待管理人员的审核！", System.Drawing.Color.Green);
                        btn_go.Visible = false;
                        btn_update.Visible = false;
                        break;
                    case "通过审核":
                        Tools.addTip(lb_info, "已通过审核，可以点击修改按钮进行修改！", System.Drawing.Color.Green);
                        btn_go.Visible = true;
                        btn_update.Visible = false;
                        break;
                    case "审核未通过":
                        Tools.addTip(lb_info, "对不起，审核未通过，不能进行修改！", System.Drawing.Color.Red);
                        btn_go.Visible = false;
                        break;
                }

                tb_WeekNumber.Text = LR.WeekNumber.ToString();
                tb_date.Text = LR.RecordDate.ToShortDateString();
                dd_time.SelectedIndex = Tools.SelectDD_Text(dd_time, LR.RecordTime_Str.ToString());
                tb_place.Text = LR.ClassSpot.ToString();
                tb_teacher.Text = LR.CourseTeacher_Str.ToString();

                string[] ParameterArray = LR.Class_Str.Split('|');
                if (LR.Class_Str != null && ParameterArray.Length > 0)
                {
                    for (int i = 0; i < ParameterArray.Length; i++)
                    {
                        listbox_MajorClass.Items.Add(ParameterArray[i].ToString());
                    }
                }
                dd_CourseClass.SelectedIndex = Tools.SelectDD_Text(dd_CourseClass, LR.CourseType_Str);
                tb_CourseName.Text = LR.Course_Str.ToString();

                for (int i = 0; i < LR.Contents.Count; i++)
                {
                    switch (LR.Contents[i].ItemTypeID)
                    {
                        case 1:
                            tb_late.Text = LR.Contents[i].ItemContent;
                            break;
                        case 2:
                            tb_LeaveEarly.Text = LR.Contents[i].ItemContent;
                            break;
                        case 3:
                            tb_CutSchool.Text = LR.Contents[i].ItemContent;
                            break;
                        case 4:
                            tb_should.Text = LR.Contents[i].ItemContent;
                            break;
                        case 5:
                            tb_real.Text = LR.Contents[i].ItemContent;
                            break;
                        case 6:
                            tb_interact.Text = LR.Contents[i].ItemContent;
                            break;
                        case 7:
                            tb_AnswerTheQuestion.Text = LR.Contents[i].ItemContent;
                            break;
                        case 8:
                            tb_ClassNote.Text = LR.Contents[i].ItemContent;
                            break;
                        case 9:
                            tb_books.Text = LR.Contents[i].ItemContent;
                            break;
                        case 10:
                            tb_ListeningStateOther.Text = LR.Contents[i].ItemContent;
                            break;
                        case 11:
                            tb_ClassHealth.Text = LR.Contents[i].ItemContent;
                            break;
                        case 12:
                            tb_ClassChair.Text = LR.Contents[i].ItemContent;
                            break;
                        case 13:
                            tb_projector.Text = LR.Contents[i].ItemContent;
                            break;
                        case 14:
                            tb_sound.Text = LR.Contents[i].ItemContent;
                            break;
                        case 15:
                            tb_ClassSetting.Text = LR.Contents[i].ItemContent;
                            break;
                        case 16:
                            tb_eat.Text = LR.Contents[i].ItemContent;
                            break;
                        case 17:
                            tb_joke.Text = LR.Contents[i].ItemContent;
                            break;
                        case 18:
                            tb_move.Text = LR.Contents[i].ItemContent;
                            break;
                        case 19:
                            tb_sleep.Text = LR.Contents[i].ItemContent;
                            break;
                        case 20:
                            tb_play.Text = LR.Contents[i].ItemContent;
                            break;
                        case 21:
                            tb_ClassOrderOther.Text = LR.Contents[i].ItemContent;
                            break;
                        case 22:
                            tb_others.Text = LR.Contents[i].ItemContent;
                            break;

                    }
                }

                content.Value = LR.filePath_Str;
                lb_ListenPerson.Text = LR.Listener.RealName.ToString();
                lb_unit.Text = LR.Listener.UserDepartment.DepName.ToString();
            }

            else
            {
                mess.FinalMessage("请选择一条听课记录进行查看！", "RecordDel.aspx", 0);
            }

        }

        protected void btn_go_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["id"]);
            Response.Redirect("RecordEdit.aspx");
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["id"]);
            ILR.RemoveRecord(id);
            mess.FinalMessage("删除成功，自动跳转中...", "RecordDel.aspx", 0);
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            User u = (User)Session["User"];
            if (Session["User"] != null)
            {
                if (u.UserType == "学生工作人员")
                {
                    Response.Redirect("RecordFinish.aspx");
                }
                else if (u.UserType == "听课教师")
                {
                     Response.Redirect("RecordDel.aspx");
                }
            }
            else
            {
                mess.FinalMessage2("登录信息已失效，请重新登录！", "index.aspx", 0, 2);
            }
           
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            LessionRecord lr = new LessionRecord();
            lr.Id = Convert.ToInt32(Session["id"]);
            lr.State = "待审核";
            if (ILRR.UpdateRecordState(lr))
            {
                //Response.Write("我是天才！！");
                Find_Messages mess = new Find_Messages();
                mess.FinalMessage("申请已提交，请等待管理人员的审核...", "RecordDel.aspx", 0);
            }
        }
    }
}