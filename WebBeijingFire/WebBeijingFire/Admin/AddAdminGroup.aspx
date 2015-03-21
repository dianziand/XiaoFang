<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAdminGroup.aspx.cs" Inherits="WebBeijingFire.Admin.AddAdminGroup" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加管理组</title>

    <script src="/js/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="/js/formValidator.js" type="text/javascript" charset="UTF-8"></script>

    <link href="/style/validatorAuto.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {
            $.formValidator.initConfig({ autotip: true, onerror: function (msg) { alert(msg) } });
            $("#<%=txtAdminGroupName.ClientID %>").formValidator({ onfocus: "标题至少2个字符,最多50个字符", oncorrect: " " }).inputValidator({ min: 2, max: 50, onerror: "大类名称长度非法!" });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" border="0" align="center">
            <tr>
                <td colspan="2" align="center">
                    添加管理组
                </td>
            </tr>
            <tr>
                <td width="235" align="right">
                    组名：
                </td>
                <td width="455" align="left">
                    &nbsp;
                    <asp:TextBox ID="txtAdminGroupName" runat="server" Width="305px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添 加" Width="159px" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
