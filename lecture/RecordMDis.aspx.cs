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
    public partial class RecordMDis : System.Web.UI.Page
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
            if(!IsPostBack)
            {
                BindInfo();
            }
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecordFinish.aspx");
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
                mess.FinalMessage("请选择一条听课记录进行查看！", "RecordFinish.aspx", 0);
            }

        }


    }
}