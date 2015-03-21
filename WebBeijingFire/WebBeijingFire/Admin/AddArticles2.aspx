<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArticles2.aspx.cs" ValidateRequest="false" Inherits="WebBeijingFire.Admin.AddArticles2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加信息</title>
    <script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="/UEditor/lang/zh-cn/zh-cn.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="880" border="0" align="center">
            <tr>
                <td colspan="2" align="center">
                    添加信息
                </td>
            </tr>
            <tr>
                <td align="right">
                    标题：
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="TxtTitle" runat="server" Width="475px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTitle"
                        ErrorMessage="请输入标题">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    优先级：
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="TxtShowLevel" runat="server" Width="73px">100</asp:TextBox>越小排在越前面
                </td>
            </tr>
            <tr>
                <td align="right">
                    所属分类：&nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:DropDownList ID="DrpArticleClass1ID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpArticleClass1ID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DrpArticleClass2ID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    添加时间：&nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="TxtAddDate" runat="server" Width="245px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    初始点击数：&nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="TxtHits" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    上传图片：
                </td>
                <td align="left">
                    &nbsp;
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="超过100K自动压缩图片" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    是否链接：&nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:DropDownList ID="DrpIsUrl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpIsUrl_SelectedIndexChanged">
                        <asp:ListItem Value="0">非链接</asp:ListItem>
                        <asp:ListItem Value="1">链接</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <asp:Panel ID="PanelUrl" runat="server" Visible="false">
                <tr>
                    <td align="right">
                        链接地址：&nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                        <asp:TextBox ID="TxtUrl" runat="server" Width="475px">http://</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        简介：&nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                        <asp:TextBox ID="TxtContent" runat="server" Width="475px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="PanelContent" runat="server">
                <tr>
                    <td align="center" colspan="2">
                        <textarea runat="server" id="myEditor" style="width:800px"></textarea>
                        <script type="text/javascript">
                            var editor = new baidu.editor.ui.Editor();
                            editor.render("myEditor");
                        </script>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添 加" Width="159px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
