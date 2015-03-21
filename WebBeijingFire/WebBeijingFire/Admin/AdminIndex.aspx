<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="WebBeijingFire.Admin.AdminIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理</title>
</head>
<frameset cols="201,*" frameborder="YES" border="2" framespacing="2" rows="*" bordercolor="#ffffff">
		<frame name="leftFrame" scrolling="auto" src="AdminLeftMenu.aspx" frameborder="YES" bordercolor="#ffe6bf"
			borderColorDark="#ffffff" bgColor="#fff3e1" borderColorLight="#ffb766">
		<frame name="mainFrame" src="AdminMain.aspx" frameborder="YES" scrolling="auto" bordercolor="#ffffff">
	</frameset>
<noframes>
</noframes>
</html>
