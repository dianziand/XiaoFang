<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="code1.aspx.cs" ValidateRequest="false" Inherits="WebBeijingFire.code1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <div style="text-align:center">
    
        动软生成的代码进行再处理Entity<br />
        <br />
        输入：<br />
        <asp:TextBox ID="TxtInput" runat="server" Height="361px" TextMode="MultiLine" 
            Width="838px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="生成DAL" 
            Width="180px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="生成BLL" 
            Width="180px" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        输出：<br />
        <asp:TextBox ID="TxtOutput" runat="server" Height="361px" TextMode="MultiLine" 
            Width="838px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
