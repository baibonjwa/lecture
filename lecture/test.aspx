<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="lecture.test" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
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
        .style1
        {
            width: 100.0%;
            border-collapse: collapse;
            font-size: 10.0pt;
            font-family: "Times New Roman";
            border-style: none;
            border-color: inherit;
            border-width: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:DropDownList ID="dd_years" runat="server">
        </asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        </asp:CheckBoxList>
    </div>
    </form>
</body>
</html>
