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
    public partial class RecordEdit : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem ILR { get; set; }
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public ICourse ic { get; set; }
        [Inject]
        public IItemTypeRepository iitr { get; set; }


        Find_Messages mess = new Find_Messages();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            LessionRecord lr = new LessionRecord();
            if (tb_WeekNumber.Text == "")
            {
                mess.FinalMessage("请输入周次！正在自动返回...", "RecordAdd.aspx", 1);
            }
            else if (Convert.ToInt32(tb_WeekNumber.Text) < 1 || Convert.ToInt32(tb_WeekNumber.Text) > 25)
            {
                mess.FinalMessage("输入的周次不合法！正在自动返回...", "RecordAdd.aspx", 1);
            }
            else if (tb_place.Text == "")
            {
                mess.FinalMessage("请输入地点！正在自动返回...", "RecordAdd.aspx", 1);
            }
            else
            {
                lr.Id = Convert.ToInt32(Session["id"]);
                lr.WeekNumber = Convert.ToInt32(tb_WeekNumber.Text);
                lr.RecordDate = Convert.ToDateTime(tb_date.Text);
                lr.RecordTime_Str = dd_time.SelectedItem.Text;
                lr.ClassSpot = dd_spot.SelectedItem + "|" + tb_place.Text;


                string classStr = "";
                for (int i = 0; i < listbox_MajorClass.Items.Count; i++)
                {
                    classStr += listbox_MajorClass.Items[i].Text + "|";
                }
                if (listbox_MajorClass.Items.Count != 0)
                {
                    classStr = classStr.Substring(0, classStr.Length - 1);
                }
                else
                {
                    classStr = "未添加";
                }
                lr.Class_Str = classStr;
                lr.CourseTeacher_Str = tb_teacher.Text;
                lr.CourseType_Str = dd_CourseClass.SelectedItem.Text;
                lr.Course_Str = tb_CourseName.Text;
                lr.filePath_Str = content.Value;
                lr.Listener = (User)Session["User"];


                RecordItem[] ri = new RecordItem[22];

                //ri[0] = new RecordItem();
                //ri[0].ItemContent = tb_late.Text;
                //ri[0].ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "迟到").ItemTypeID;
                //lr.AddContent(ri[0]);

                //ri[1] = new RecordItem();
                //ri[1].ItemContent = tb_LeaveEarly.Text;
                //ri[1].ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "早退").ItemTypeID;
                //lr.AddContent(ri[1]);

                //ri[2] = new RecordItem();
                //ri[2].ItemContent = tb_CutSchool.Text;
                //ri[2].ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "旷课").ItemTypeID;
                //lr.AddContent(ri[2]);

                //ri[3] = new RecordItem();
                //ri[3].ItemContent = tb_should.Text;
                //ri[3].ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "应到").ItemTypeID;
                //lr.AddContent(ri[3]);

                //ri[4] = new RecordItem();
                //ri[4].ItemContent = tb_real.Text;
                //ri[4].ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "实到").ItemTypeID;
                //lr.AddContent(ri[4]);

                //ri[5] = new RecordItem();
                //ri[5].ItemContent = tb_interact.Text;
                //ri[5].ItemTypeID = iitr.GetItemTypeByTypeAndName("听课状态", "参与互动教学").ItemTypeID;
                //lr.AddContent(ri[5]);

                //ri[6] = new RecordItem();
                //ri[6].ItemContent = tb_AnswerTheQuestion.Text;
                //ri[6].ItemTypeID = iitr.GetItemTypeByTypeAndName("听课状态", "主动回答问题").ItemTypeID;
                //lr.AddContent(ri[6]);

                //ri[7] = new RecordItem();
                //ri[7].ItemContent = tb_ClassNote.Text;
                //ri[7].ItemTypeID = iitr.GetItemTypeByTypeAndName("听课状态", "课堂笔记").ItemTypeID;
                //lr.AddContent(ri[7]);

                //ri[8] = new RecordItem();
                //ri[8].ItemContent = tb_books.Text;
                //ri[8].ItemTypeID = iitr.GetItemTypeByTypeAndName("听课状态", "上课带教材").ItemTypeID;
                //lr.AddContent(ri[8]);

                //ri[9] = new RecordItem();
                //ri[9].ItemContent = tb_ListeningStateOther.Text;
                //ri[9].ItemTypeID = iitr.GetItemTypeByTypeAndName("听课状态", "其他").ItemTypeID;
                //lr.AddContent(ri[9]);

                //ri[10] = new RecordItem();
                //ri[10].ItemContent = tb_ClassHealth.Text;
                //ri[10].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂环境", "教室卫生").ItemTypeID;
                //lr.AddContent(ri[10]);

                //ri[11] = new RecordItem();
                //ri[11].ItemContent = tb_ClassChair.Text;
                //ri[11].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂环境", "教室桌椅").ItemTypeID;
                //lr.AddContent(ri[11]);

                //ri[12] = new RecordItem();
                //ri[12].ItemContent = tb_projector.Text;
                //ri[12].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂环境", "投影仪").ItemTypeID;
                //lr.AddContent(ri[12]);

                //ri[13] = new RecordItem();
                //ri[13].ItemContent = tb_sound.Text;
                //ri[13].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂环境", "音响").ItemTypeID;
                //lr.AddContent(ri[13]);

                //ri[14] = new RecordItem();
                //ri[14].ItemContent = tb_ClassSetting.Text;
                //ri[14].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂环境", "其他").ItemTypeID;
                //lr.AddContent(ri[14]);

                //ri[15] = new RecordItem();
                //ri[15].ItemContent = tb_eat.Text;
                //ri[15].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "吃东西情况").ItemTypeID;
                //lr.AddContent(ri[15]);

                //ri[16] = new RecordItem();
                //ri[16].ItemContent = tb_joke.Text;
                //ri[16].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "说笑情况").ItemTypeID;
                //lr.AddContent(ri[16]);

                //ri[17] = new RecordItem();
                //ri[17].ItemContent = tb_move.Text;
                //ri[17].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "随意走动情况").ItemTypeID;
                //lr.AddContent(ri[17]);

                //ri[18] = new RecordItem();
                //ri[18].ItemContent = tb_sleep.Text;
                //ri[18].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "睡觉情况").ItemTypeID;
                //lr.AddContent(ri[18]);

                //ri[19] = new RecordItem();
                //ri[19].ItemContent = tb_play.Text;
                //ri[19].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "摆弄手机情况").ItemTypeID;
                //lr.AddContent(ri[19]);

                //ri[20] = new RecordItem();
                //ri[20].ItemContent = tb_ClassOrderOther.Text;
                //ri[20].ItemTypeID = iitr.GetItemTypeByTypeAndName("课堂秩序", "其他").ItemTypeID;
                //lr.AddContent(ri[20]);

                //ri[21] = new RecordItem();
                //ri[21].ItemContent = tb_ClassOrderOther.Text;
                //ri[21].ItemTypeID = iitr.GetItemTypeByTypeAndName("其它情况", "").ItemTypeID;
                ri[0] = new RecordItem();
                ri[0].ItemContent = tb_late.Text;
                ri[0].ItemTypeID = 1;
                lr.AddContent(ri[0]);

                ri[1] = new RecordItem();
                ri[1].ItemContent = tb_LeaveEarly.Text;
                ri[1].ItemTypeID = 2;
                lr.AddContent(ri[1]);

                ri[2] = new RecordItem();
                ri[2].ItemContent = tb_CutSchool.Text;
                ri[2].ItemTypeID = 3;
                lr.AddContent(ri[2]);

                ri[3] = new RecordItem();
                ri[3].ItemContent = tb_should.Text;
                ri[3].ItemTypeID = 4;
                lr.AddContent(ri[3]);

                ri[4] = new RecordItem();
                ri[4].ItemContent = tb_real.Text;
                ri[4].ItemTypeID = 5;
                lr.AddContent(ri[4]);

                ri[5] = new RecordItem();
                ri[5].ItemContent = tb_interact.Text;
                ri[5].ItemTypeID = 6;
                lr.AddContent(ri[5]);

                ri[6] = new RecordItem();
                ri[6].ItemContent = tb_AnswerTheQuestion.Text;
                ri[6].ItemTypeID = 7;
                lr.AddContent(ri[6]);

                ri[7] = new RecordItem();
                ri[7].ItemContent = tb_ClassNote.Text;
                ri[7].ItemTypeID = 8;
                lr.AddContent(ri[7]);

                ri[8] = new RecordItem();
                ri[8].ItemContent = tb_books.Text;
                ri[8].ItemTypeID = 9;
                lr.AddContent(ri[8]);

                ri[9] = new RecordItem();
                ri[9].ItemContent = tb_ListeningStateOther.Text;
                ri[9].ItemTypeID = 10;
                lr.AddContent(ri[9]);

                ri[10] = new RecordItem();
                ri[10].ItemContent = tb_ClassHealth.Text;
                ri[10].ItemTypeID = 11;
                lr.AddContent(ri[10]);

                ri[11] = new RecordItem();
                ri[11].ItemContent = tb_ClassChair.Text;
                ri[11].ItemTypeID = 12;
                lr.AddContent(ri[11]);

                ri[12] = new RecordItem();
                ri[12].ItemContent = tb_projector.Text;
                ri[12].ItemTypeID = 13;
                lr.AddContent(ri[12]);

                ri[13] = new RecordItem();
                ri[13].ItemContent = tb_sound.Text;
                ri[13].ItemTypeID = 14;
                lr.AddContent(ri[13]);

                ri[14] = new RecordItem();
                ri[14].ItemContent = tb_ClassSetting.Text;
                ri[14].ItemTypeID = 15;
                lr.AddContent(ri[14]);

                ri[15] = new RecordItem();
                ri[15].ItemContent = tb_eat.Text;
                ri[15].ItemTypeID = 16;
                lr.AddContent(ri[15]);

                ri[16] = new RecordItem();
                ri[16].ItemContent = tb_joke.Text;
                ri[16].ItemTypeID = 17;
                lr.AddContent(ri[16]);

                ri[17] = new RecordItem();
                ri[17].ItemContent = tb_move.Text;
                ri[17].ItemTypeID = 18;
                lr.AddContent(ri[17]);

                ri[18] = new RecordItem();
                ri[18].ItemContent = tb_sleep.Text;
                ri[18].ItemTypeID = 19;
                lr.AddContent(ri[18]);

                ri[19] = new RecordItem();
                ri[19].ItemContent = tb_play.Text;
                ri[19].ItemTypeID = 20;
                lr.AddContent(ri[19]);

                ri[20] = new RecordItem();
                ri[20].ItemContent = tb_ClassOrderOther.Text;
                ri[20].ItemTypeID = 21;
                lr.AddContent(ri[20]);

                ri[21] = new RecordItem();
                ri[21].ItemContent = tb_ClassOrderOther.Text;
                ri[21].ItemTypeID = 22;
                lr.AddContent(ri[21]);

                if (ILR.UpdateRecord(lr))
                {
                    //Response.Write("我是天才！！");
                    Find_Messages mess = new Find_Messages();
                    mess.FinalMessage("修改成功，正在自动跳转...", "RecordDel.aspx", 0);
                }
            }
        }

        protected void lbtn_classDel_Click(object sender, EventArgs e)
        {
            listbox_MajorClass.Items.Remove(listbox_MajorClass.SelectedItem);
        }

        protected void lbtn_classAdd_Click(object sender, EventArgs e)
        {
            listbox_MajorClass.Items.Add(tb_class.Text);
        }
        protected void BindInfo()
        {
            int id = Convert.ToInt32(Session["id"]);
            if (Session["id"] != null)
            {
                LessionRecord LR = new LessionRecord();
                LR = ILR.SelectRecord(id);

                tb_WeekNumber.Text = LR.WeekNumber.ToString();
                tb_date.Text = LR.RecordDate.ToShortDateString();
                dd_time.SelectedIndex = Tools.SelectDD_Text(dd_time, LR.RecordTime_Str.ToString());
                string[] temp = LR.ClassSpot.Split('|');
                if (temp.Length > 1)
                {
                    dd_spot.SelectedIndex = Tools.SelectDD_Text(dd_spot, temp[0]);
                    tb_place.Text = temp[1];
                }
                else
                {
                    dd_spot.SelectedIndex = Tools.SelectDD_Text(dd_spot, temp[0]);
                }

                string[] ParameterArray = LR.Class_Str.Split('|');
                if (LR.Class_Str != null && ParameterArray.Length > 0)
                {
                    for (int i = 0; i < ParameterArray.Length; i++)
                    {
                        listbox_MajorClass.Items.Add(ParameterArray[i].ToString());
                    }
                }
                dd_CourseClass.SelectedIndex = Tools.SelectDD_Text(dd_CourseClass, LR.CourseType_Str);
                tb_teacher.Text = LR.CourseTeacher_Str;
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
                mess.FinalMessage("请选择一条听课记录进行修改！", "RecordDel.aspx", 0);
            }
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
    }
}