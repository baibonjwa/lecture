<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordIndicator.aspx.cs" Inherits="lecture.RecordIndicator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
    <style type="text/css">
        .style1
        {
            width: 25%;
        }
    </style>
 
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table style="width:100%; ">
             <tr>
                 <td colspan="2" align="center">
                    <asp:Label ID="Label3" runat="server" Text="听课任务指标" Font-Size="X-Large" 
                        ForeColor="#99CCFF"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td colspan="2">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td class="style1">
                     &nbsp;</td>
                 <td>
         1. 校区学生处、团工委科级以上干部每月听课两次。
 
         
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     &nbsp;</td>
                 <td>
        2．各学院主管学生工作的书记、副书记每月听课三次。
 
         
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     &nbsp;</td>
                 <td>
        3. 专兼职辅导员每月听课四次。
 
         
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     &nbsp;</td>
                 <td>
        4. 班导师每月听课两次。

     
                 </td>
             </tr>
             <tr>
                 <td class="style1">
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>

    </div>
    </form>
</body>
</html>
