<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAdminGroups.aspx.cs" Inherits="WebBeijingFire.Admin.ManageAdminGroups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理管理组</title>
    <link href="../style/page.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script language="javascript">

        $(function () {
            $('#oTable tr:even').css('background-color', '#EEEEEE');
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" border="0" align="center">
            <tr>
                <td colspan="2" align="center">
                    管理管理组
                </td>
            </tr>
            <tr>
                <td width="235" align="right">
                    组名：
                </td>
                <td width="455" align="left">
                    &nbsp;
                    <asp:TextBox ID="txtKey" runat="server" Width="273px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="搜  索" Width="125px" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <center>
            <div class="PicPage070129">
                <div class="Pagediv070129">
                    页次:
                    <asp:Literal ID="LtPage1" runat="server"></asp:Literal>
                    /<asp:Literal ID="LtTotalPage1" runat="server"></asp:Literal>&nbsp; 每页:<asp:Literal
                        ID="LtPageSize1" runat="server"></asp:Literal>
                    &nbsp; 共:<asp:Literal ID="AllCount1" runat="server"></asp:Literal>条 &nbsp;<asp:Literal
                        ID="AllPage1" runat="server"></asp:Literal>
                </div>
            </div>
            <br />
            <table width="100%" id="oTable" border="1" cellpadding="10" cellspacing="0" bordercolor="#e4ecf9" style="border-collapse: collapse;">
                <tbody>
                    <tr style="background-color: #c9c9c9;">
                        <th>
                            编号
                        </th>
                        <th>
                            修改
                        </th>
                        <th style="width: 35%">
                            组名
                        </th>                       
                        <th>
                            删除
                        </th>
                    </tr>
                    <asp:Repeater ID="ArticleRepeater" runat="server"  OnItemDataBound="List_ItemDataBound">
                        <ItemTemplate>
                            <tr style="height:35px">
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem, "AdminGroupID")%>
                                </td>
                                <td>
                                    <a href="EditAdminGroup.aspx?AdminGroupID=<%#DataBinder.Eval(Container.DataItem, "AdminGroupID")%>"
                                        target="_blank">修改</a>
                                </td>
                                <td style="width: 35%; text-align: left">
                                        <%#DataBinder.Eval(Container.DataItem, "AdminGroupName")%>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LBDelete" ToolTip='<%#DataBinder.Eval(Container.DataItem,"AdminGroupID")%>'
                                        runat="server" ForeColor="red" OnCommand="LBDelete_Command">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="clear">
            </div>
            <div class="PicPage070129">
                <div class="Pagediv070129">
                    页次:
                    <asp:Literal ID="LtPage2" runat="server"></asp:Literal>
                    /<asp:Literal ID="LtTotalPage2" runat="server"></asp:Literal>&nbsp; 每页:<asp:Literal
                        ID="LtPageSize2" runat="server"></asp:Literal>
                    &nbsp; 共:<asp:Literal ID="AllCount2" runat="server"></asp:Literal>条 &nbsp;<asp:Literal
                        ID="AllPage2" runat="server"></asp:Literal>
                </div>
            </div>
        </center>
    </div>
    </form>
</body>
</html>

