<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebBeijingFire.Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统管理员登陆</title>

    <script src="/js/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="/js/formValidator.js" type="text/javascript" charset="UTF-8"></script>

    <link href="/style/validatorAuto.css" rel="stylesheet" type="text/css" />

    <script src="/js/formValidatorRegex.js" type="text/javascript" charset="UTF-8"></script>

    <script type="text/javascript">

        $("#<%=txtAdminName.ClientID%>").focus();

        $(document).ready(function () {
            $.formValidator.initConfig({ autotip: true, onerror: function (msg) { alert(msg) } });

            $("#<%=txtAdminName.ClientID %>").formValidator({ onfocus: "请输入用户名！", oncorrect: " " }).inputValidator({ min: 2, max: 20, onerror: "用户名长度非法!" });
            $("#<%=txtAdminPwd.ClientID %>").formValidator({ onfocus: "请输入密码！", oncorrect: " " }).inputValidator({ min: 2, max: 30, onerror: "密码长度非法!" });

        });
    </script>

</head>
<body bgcolor="#EFF0F4" text="#333333" topmargin="100" onload="javascript:document.getElementById('txtAdminName').focus()">
    <form id="form1" runat="server">
    <table width="755" height="350" border="0" align="center" cellpadding="0" cellspacing="0"
        style="background: url('/Images/login.jpg'); background-repeat: no-repeat">
        <tr>
            <td height="100">
            </td>
        </tr>
        <tr>
            <td height="200">
                <table width="500" height="200" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right" valign="middle">
                            <img imageurl="/Images//lgline.gif" width="402" height="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <table width="460" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table border="0" bordercolor="#111111" cellpadding="0" cellspacing="0" height="118"
                                            style="border-collapse: collapse" width="276" align="center">
                                            <tbody>
                                                <tr>
                                                    <td height="16" width="113">
                                                        <p align="right" class="style4">
                                                            <font color="#7B8AC3">管理员账号：</font></p>
                                                    </td>
                                                    <td align="left" height="16" width="171">
                                                        <asp:TextBox ID="txtAdminName" runat="server" CssClass="ipt"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr align="middle" valign="center">
                                                    <td height="34" width="113">
                                                        <p align="right" class="style4">
                                                            <font color="#7B8AC3">管理员密码：</font></p>
                                                    </td>
                                                    <td align="left" height="34" width="171">
                                                        <asp:TextBox ID="txtAdminPwd" runat="server" TextMode="Password" CssClass="ipt"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr align="center" valign="center">
                                                    <td width="113" height="13">
                                                        <div align="right">
                                                            <asp:ImageButton ID="btnSubmit" ImageUrl="/Images/loginok.gif" runat="server" OnClientClick="return checkData()"
                                                                OnClick="btnSubmit_Click" />
                                                        </div>
                                                    </td>
                                                    <td width="171" height="13">
                                                        <div align="center">
                                                            <a onclick="document.form1.reset()" href="#">
                                                                <img height="27" src="/Images/loginre.gif" width="84" border="0" alt="" /></a></div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="50">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
