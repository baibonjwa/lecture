<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="lecture.Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="teacher" HeaderText="听课教师" />
                <asp:BoundField DataField="dTime" HeaderText="听课时间" />
                <asp:BoundField DataField="dSpot" HeaderText="听课地点" />
                <asp:BoundField DataField="dCourse" HeaderText="听课课程" />
                <asp:BoundField DataField="taskDate" HeaderText="任务月份" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btn_download" runat="server" onclick="btn_download_Click" 
            Text="下载该报表" />
    </div>
    </form>
</body>
</html>
