<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditArticleClass1.aspx.cs" Inherits="WebBeijingFire.Admin.EditArticleClass1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改大类</title>

    <script src="/js/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="/js/formValidator.js" type="text/javascript" charset="UTF-8"></script>

    <link href="/style/validatorAuto.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {
            $.formValidator.initConfig({ autotip: true, onerror: function (msg) { alert(msg) } });
            $("#<%=txtArticleClass1Name.ClientID %>").formValidator({ onfocus: "标题至少2个字符,最多50个字符", oncorrect: " " }).inputValidator({ min: 2, max: 50, onerror: "大类名称长度非法!" });

            $("#<%=txtShowLevel.ClientID %>").formValidator({ tipcss: { "left": "148px", "width": "100px" }, onfocus: "只能输入数字！", oncorrect: " " }).inputValidator({ min: 1, max: 6, onerror: "优先级长度非法！" }).regexValidator({ regexp: "^[0-9]*$", onerror: "优先级错误！" });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" border="0" align="center">
            <tr>
                <td colspan="2" align="center">
                    修改大类
                </td>
            </tr>
            <tr>
                <td width="235" align="right">
                    大类名称：
                </td>
                <td width="455" align="left">
                    &nbsp;
                    <asp:TextBox ID="txtArticleClass1Name" runat="server" Width="305px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    优先级：
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtShowLevel" runat="server" Width="73px">100</asp:TextBox>越小排在越前面
                </td>
            </tr>
            <tr>
                <td  align="right">
                    说明：
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtWords" runat="server" Width="400px" Height="86px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="修 改" Width="159px" />
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



