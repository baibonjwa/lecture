<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidCode.ascx.cs" Inherits="ValidCode" %>
<style>
    .VCode *
    {
        vertical-align: middle;
    }
    .VCode
    {
        float:left;
    }
</style>
<div class="VCode" style="width: 250px; vertical-align: middle;">
    <asp:Image ID="imgVCode" runat="server" AlternateText="验证码图片" Height="22px" ImageUrl="~/ValidCode.ashx"
        Width="70px" />
    <a href="#" style=" color:White;" onclick="document.getElementById('<%=imgVCode.ClientID %>').src='ValidCode.ashx?id=' + Math.random(); return false">
        看不清楚，换一张</a></div>
