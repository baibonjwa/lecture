<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordEdit.aspx.cs" Inherits="lecture.RecordEdit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <script src="Controls/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Content/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script type='text/javascript' src="Scripts/jquery.autocomplete.js"></script>
    <script type="text/javascript" charset="utf-8" src="Controls/ueditor/editor_config.js"></script>
    <!--使用版-->
    <script type="text/javascript" charset="utf-8" src="Controls/ueditor/editor_all.js"></script>
    <link rel="stylesheet" type="text/css" href="Controls/ueditor/themes/default/ueditor.css" />
    <script type="text/javascript">
        function Add(txt) {
            var elemSel = document.getElementById("listbox_MajorClass");
            var Num = elemSel.options.length;
            elemSel.options[Num] = new Option(txt, txt);
        }

        function Remove() {
            var lst2 = document.getElementById("listbox_MajorClass");
            var length = lst2.options.length;
            for (var i = length; i > 0; i--) {
                lst2.options.remove(i - 1);
            }
        }
        function refresh() {
            var num;
            var results;
            //alert('hello！');
            Remove();
            num = lecture.RecordAdd.GetClassNum(document.getElementById('tb_CourseName').value).value;
            results = lecture.RecordAdd.GetResults(num).value;
            n = lecture.RecordAdd.GetNumber(num).value;

            ch = new Array;
            ch = results.split("|");
            for (i = 0; i < n; i++) {
                Add(ch[i]);
            }
            document.getElementById('tb_teacher').value = ch[n];

            var DropDownListCurrencyNew = document.getElementById("dd_CourseClass");
            for (i = 0; i < DropDownListCurrencyNew.options.length; i++) {
                if (DropDownListCurrencyNew.options[i].text == ch[n + 1]) {
                    DropDownListCurrencyNew.options[i].selected = true;
                }
            }
        }
        function findValue(li) {
            if (li == null) return alert("No match!");
            if (!!li.extra)
                var sValue = li.extra[0];
        }
        function selectItem(li) {
            findValue(li);
        }
        function lookupLocal() {
            var oSuggest = $(".ajaxinput")[0].autocompleter;
            oSuggest.findValue();
            return false;
        }
        //        $(document).ready(function () {
        //            $("#tb_CourseName").autocomplete("Controls/AutoCompleteDataCourse.aspx", {
        //                delay: 10,
        //                minChars: 1,
        //                matchSubset: 1,
        //                cacheLength: 1,
        //                onItemSelect: selectItem,
        //                onFindValue: findValue,
        //                autoFill: true,
        //                maxItemsToShow: 20
        //            });

        //        }); 
    </script>
    <style type="text/css">
        table.MsoNormalTable
        {
            font-size: 10.0pt;
            font-family: "Times New Roman";
        }
        p.MsoNormal
        {
            margin-bottom: .0001pt;
            text-align: justify;
            text-justify: inter-ideograph;
            font-size: 10.5pt;
            font-family: Calibri;
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <asp:Label ID="Label1" runat="server" Text="辽宁工程技术大学葫芦岛校区学生工作人员听课表" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="注：带有**的为必填项" Font-Size="Small" ForeColor="Red"></asp:Label>
        <br />
        <table border="1" cellpadding="0" cellspacing="0" class="MsoNormalTable" width="100%">
            <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; height: 23.5pt">
                <td colspan="2" style="width: 18.02%; border: solid black 1.0pt; mso-border-alt: solid black .5pt;
                    padding: 0cm 5.4pt 0cm 5.4pt; height: 23.5pt" width="18%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">周次<span style="font-size: 9.0pt; line-height: 150%;
                                font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri"><asp:Label
                                    ID="Label3" runat="server" Text="**" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </span></span>
                    </p>
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">(填数字,如:1)</span></p>
                </td>
                <td style="width: 14.8%; border: solid black 1.0pt; border-left: none; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 23.5pt"
                    width="14%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_WeekNumber" runat="server" Width="120px" onkeypress="if (event.keyCode<48 || event.keyCode>57) event.returnValue=false;"></asp:TextBox></span>
                        <span lang="EN-US" style="font-size: 9.0pt; line-height: 150%">
                            <o:p></o:p>
                        </span>
                    </p>
                </td>
                <td style="width: 13.02%; border: solid black 1.0pt; border-left: none; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 23.5pt"
                    width="13%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">日期</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p><asp:Label ID="Label5" runat="server" 
                            Font-Size="Small" ForeColor="Red" Text="**"></asp:Label>
                        </o:p></span></p>
                </td>
                <td colspan="3" style="width: 14.82%; border: solid black 1.0pt; border-left: none;
                    mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 23.5pt" width="14%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_date" runat="server" Width="120px" onclick="WdatePicker()"></asp:TextBox></span><span
                                lang="EN-US" style="font-size: 9.0pt; line-height: 150%"><o:p></o:p>
                            </span>
                    </p>
                </td>
                <td colspan="3" style="width: 18.86%; border: solid black 1.0pt; border-left: none;
                    mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 23.5pt" width="18%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">时间<span lang="EN-US" style="font-size: 9.0pt; line-height: 150%"><asp:Label
                                ID="Label6" runat="server" Font-Size="Small" ForeColor="Red" Text="**"></asp:Label>
                            </span></span>
                    </p>
                </td>
                <td colspan="2" style="width: 20.48%; border: solid black 1.0pt; border-left: none;
                    mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 23.5pt" width="20%">
                    <p align="center" class="MsoNormal">
                        <span lang="EN-US" style="font-size: 9.0pt; line-height: 150%">
                            <o:p></o:p>
                            <asp:DropDownList ID="dd_time" runat="server">
                                <asp:ListItem>第一小节</asp:ListItem>
                                <asp:ListItem>第二小节</asp:ListItem>
                                <asp:ListItem>第三小节</asp:ListItem>
                                <asp:ListItem>第四小节</asp:ListItem>
                                <asp:ListItem>第五小节</asp:ListItem>
                                <asp:ListItem>第六小节</asp:ListItem>
                                <asp:ListItem>第七小节</asp:ListItem>
                                <asp:ListItem>第八小节</asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 1; height: 22.8pt">
                <td colspan="2" style="width: 18.02%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="18%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">地点</span><span lang="EN-US"><o:p><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><asp:Label ID="Label7" runat="server" 
                            Font-Size="Small" ForeColor="Red" Text="**"></asp:Label>
                        </span></o:p></span></p>
                </td>
                <td style="width: 14.8%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="14%">
                    <p align="center" class="MsoNormal">
                        <span lang="EN-US">
                            <o:p>
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                                                <asp:DropDownList ID="dd_spot" runat="server"   Width="100px" >
                                                    <asp:ListItem>尔雅楼</asp:ListItem>
                                                    <asp:ListItem>耘慧楼</asp:ListItem>
                                                    <asp:ListItem>静远楼</asp:ListItem>
                                                </asp:DropDownList>
                            </span></o:p>
                        </span>
                    </p>
                    <p align="center" class="MsoNormal">
                        <o:p>
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_place" runat="server" Width="80px"></asp:TextBox>室</o:p>
                    </p>
                </td>
                <td style="width: 13.02%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">专业班级</span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="width: 14.82%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="14%">
                    <p align="center" class="MsoNormal">
                        <span lang="EN-US">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="listbox_MajorClass" runat="server" Width="120px" Height="57px" CssClass="style3">
                                    </asp:ListBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lbtn_classAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lbtn_classDel" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </span>
                    <p align="center" class="MsoNormal">
                        <asp:TextBox ID="tb_class" runat="server" Width="120px"></asp:TextBox>
                    </p>
                    <p align="center" class="MsoNormal">
                        <asp:LinkButton ID="lbtn_classAdd" runat="server" OnClick="lbtn_classAdd_Click">添加班级</asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lbtn_classDel" runat="server" OnClick="lbtn_classDel_Click">删除班级</asp:LinkButton>
                    </p>
                </td>
                <td colspan="3" style="width: 18.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="18%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">授课教师</span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 20.48%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="20%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_teacher" runat="server" Width="120px"></asp:TextBox></span><span
                                lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 2; height: 22.8pt">
                <td colspan="4" style="width: 45.84%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="45%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            课程类别</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="8" style="width: 54.16%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="54%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:DropDownList ID="dd_CourseClass" runat="server" Width="125px">
                                <asp:ListItem Value="基础课">基础课</asp:ListItem>
                                <asp:ListItem Value="专业基础课">专业基础课</asp:ListItem>
                                <asp:ListItem Value="专业课">专业课</asp:ListItem>
                            </asp:DropDownList>
                        </span><span lang="EN-US" style="font-size: 9.0pt">
                            <o:p></o:p>
                        </span>
                    </p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 3; height: 22.8pt">
                <td colspan="4" style="width: 45.84%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="45%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">课程名称</span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="8" style="width: 54.16%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="54%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_CourseName" runat="server"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 4; height: 22.8pt">
                <td rowspan="3" style="width: 16.06%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">学生出勤情况</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">迟到</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="67%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_late" runat="server"></asp:TextBox></span><span lang="EN-US"
                                style="font-size: 9.0pt; line-height: 150%"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 5; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">早退</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="67%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_LeaveEarly" runat="server"></asp:TextBox></span><span lang="EN-US"
                                style="font-size: 9.0pt; line-height: 150%"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 6; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">旷课</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.02%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_CutSchool" runat="server" Width="50px"></asp:TextBox></span></p>
                </td>
                <td colspan="5" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; border-left-style: none;
                    border-left-color: inherit; border-left-width: medium; border-top-style: none;
                    border-top-color: inherit; border-top-width: medium;" class="style2">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">应到</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span><span style="font-family: 宋体; mso-ascii-font-family: Calibri;
                                    mso-hansi-font-family: Calibri">
                                    <asp:TextBox ID="tb_should" runat="server" Width="50px"></asp:TextBox></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">实到</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p align="center" class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_real" runat="server"></asp:TextBox></span><span lang="EN-US"
                                style="font-size: 9.0pt; line-height: 150%"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 7; height: 22.8pt">
                <td rowspan="5" style="width: 16.06%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">听课状态</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">参与互动教学</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt;
                    border-left-style: none; border-left-color: inherit; border-left-width: medium;
                    border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_interact" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="3" rowspan="5" style="width: 10.56%; border-top: none; border-left: none;
                    border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt;
                    mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.8pt" width="10%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            课堂环境</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            教室卫生</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_ClassHealth" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 8; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">主动回答问题</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt;
                    border-left-style: none; border-left-color: inherit; border-left-width: medium;
                    border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_AnswerTheQuestion" runat="server" TextMode="MultiLine"></asp:TextBox></span><span
                                lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            教室桌椅</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_ClassChair" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 9; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">课堂笔记</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt;
                    border-left-style: none; border-left-color: inherit; border-left-width: medium;
                    border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_ClassNote" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            投影仪</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_projector" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 10; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">上课带教材</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt;
                    border-left-style: none; border-left-color: inherit; border-left-width: medium;
                    border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_books" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            音响</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_sound" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 11; height: 22.8pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; line-height: 150%; font-family: 宋体; mso-ascii-font-family: Calibri;
                            mso-hansi-font-family: Calibri">其他</span><span lang="EN-US" style="font-size: 9.0pt;
                                line-height: 150%"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="border-bottom: solid black 1.0pt; border-right: solid black 1.0pt;
                    mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt;
                    border-left-style: none; border-left-color: inherit; border-left-width: medium;
                    border-top-style: none; border-top-color: inherit; border-top-width: medium;">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_ListeningStateOther" runat="server" 
                            TextMode="MultiLine"></asp:TextBox></span><span
                                lang="EN-US"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 17.86%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="17%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            其他</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td style="width: 13.28%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.8pt"
                    width="13%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_ClassSetting" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 12; height: 23.5pt">
                <td rowspan="6" style="width: 16.06%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 23.5pt" width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            课堂秩序</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 23.5pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            吃东西情况</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 23.5pt"
                    width="67%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_eat" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 13; height: 22.9pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.9pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            说笑情况</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.9pt"
                    width="67%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_joke" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 14; height: 22.9pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.9pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            随意走动情况</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.9pt"
                    width="67%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_move" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 15; height: 22.3pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            睡觉情况</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="67%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_sleep" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 16; height: 22.3pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            摆弄手机情况</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="67%">
                    <p class="MsoNormal">
                        <span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:TextBox ID="tb_play" runat="server" TextMode="MultiLine"></asp:TextBox></span><span lang="EN-US"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 17; height: 22.3pt">
                <td colspan="2" style="width: 16.76%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="16%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            其他</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="9" style="width: 67.2%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.3pt"
                    width="67%">
                    <p class="MsoNormal">
                        <asp:TextBox ID="tb_ClassOrderOther" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <span lang="EN-US">
                            <o:p></o:p>
                        </span>
                    </p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 18; height: 93.2pt">
                <td colspan="12" style="width: 100.0%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 93.2pt" valign="top" width="100%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            其它情况：</span><span style="font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri"><asp:TextBox
                                ID="tb_others" runat="server" Height="120px" TextMode="MultiLine" Width="90%"></asp:TextBox></span><span
                                    lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 19; height: 22.9pt">
                <td colspan="12" style="width: 100.0%; border: solid black 1.0pt; border-top: none;
                    mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt;
                    height: 22.9pt" width="100%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            听课图片上传：</span></p>
                    <div style="text-align: left;">
                        <textarea id="content" runat="server" datatype="LimitT" min="5" msg="您发布的内容过短，正文需5字以上"
                            name="content" style="overflow: auto; font-size: 14px; padding-left: 2; padding-right: 5px;
                            padding-top: 5px; padding-bottom: 5px;" cols="20" rows="1"></textarea>
                    </div>
                </td>
            </tr>
            <tr style="mso-yfti-irow: 20; mso-yfti-lastrow: yes; height: 30.3pt">
                <td style="width: 16.06%; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.3pt"
                    width="16%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            听课人</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="4" style="width: 39.94%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.3pt"
                    width="39%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:Label ID="lb_ListenPerson" runat="server"></asp:Label></span><span lang="EN-US"
                                style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="3" style="width: 8.64%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.3pt"
                    width="8%">
                    <p align="center" class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            单位</span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
                <td colspan="4" style="width: 35.36%; border-top: none; border-left: none; border-bottom: solid black 1.0pt;
                    border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt;
                    mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.3pt"
                    width="35%">
                    <p class="MsoNormal">
                        <span style="font-size: 9.0pt; font-family: 宋体; mso-ascii-font-family: Calibri; mso-hansi-font-family: Calibri">
                            <asp:Label ID="lb_unit" runat="server"></asp:Label></span><span lang="EN-US" style="font-size: 9.0pt"><o:p></o:p></span></p>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btn_Save" CssClass="btn1" runat="server" Text="保存" OnClick="btn_Save_Click" />
        &nbsp;
        <asp:Button ID="btn_cancle" runat="server" Text="取消" CssClass="btn1" OnClick="btn_cancle_Click" />
        <p class="MsoNormal">
            &nbsp;</p>
    </div>
    </form>
    <script type="text/javascript">
        // 自定义的编辑器配置项,此处定义的配置项将覆盖editor_config.js中的同名配置
        var editorOption = {
            //这里可以选择自己需要的工具按钮名称,此处仅选择如下五个
            toolbars: [['InsertImage']],
            //关闭字数统计
            wordCount: false,
            //关闭elementPath
            elementPathEnabled: false
            //更多其他参数，请参考editor_config.js中的配置项
        };
        var editor_a = new baidu.editor.ui.Editor(editorOption);
        editor_a.render('<%=content.ClientID %>');
    </script>
</body>
</html>
