<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLeftMenu.aspx.cs" Inherits="WebBeijingFire.Admin.AdminLeftMenu" %>

<html>

<script language="javascript">
    function RegiscteFrame(path) {
        parent.mainFrame.location.href = path;
    }
</script>

<style type="text/css">
    BODY
    {
        scrollbar-face-color: #c6ebde;
        background: #39867b;
        margin: 0px;
        font: 9pt 宋体;
        scrollbar-highlight-color: #ffffff;
        scrollbar-shadow-color: #39867b;
        scrollbar-3dlight-color: #39867b;
        scrollbar-arrow-color: #330000;
        scrollbar-track-color: #e2f3f1;
        scrollbar-darkshadow-color: #ffffff;
        text-decoration: none;
    }
    TABLE
    {
        border-right: 0px;
        border-top: 0px;
        border-left: 0px;
        border-bottom: 0px;
    }
    TD
    {
        font: 12px 宋体;
    }
    IMG
    {
        border-right: 0px;
        border-top: 0px;
        vertical-align: bottom;
        border-left: 0px;
        border-bottom: 0px;
    }
    A
    {
        font: 12px 宋体;
        color: #000000;
        text-decoration: none;
    }
    A:hover
    {
        color: #cc0000;
        text-decoration: underline;
    }
    .sec_menu
    {
        border-right: white 1px solid;
        background: #c6ebde;
        overflow: hidden;
        border-left: white 1px solid;
        border-bottom: white 1px solid;
    }
    .menu_title
    {
    }
    .menu_title SPAN
    {
        font-weight: bold;
        left: 8px;
        color: #39867b;
        position: relative;
        top: 2px;
    }
    .menu_title2
    {
    }
    .menu_title2 SPAN
    {
        font-weight: bold;
        left: 8px;
        color: #428eff;
        position: relative;
        top: 2px;
    }
</style>

<script language="javascript1.2">
function showsubmenu(sid)
{
whichEl = eval("submenu" + sid);
if (whichEl.style.display == "none")
{
eval("submenu" + sid + ".style.display=\"\";");
}
else
{
eval("submenu" + sid + ".style.display=\"none\";");
}
}
</script>

<body leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="left">
        <tr>
            <td valign="top">
                <table cellspacing="0" cellpadding="0" width="158" align="center">
                    <tr>
                        <td class="menu_title" id="menuTitle8" onmouseover="this.className='menu_title2';"
                            onclick="showsubmenu(1)" onmouseout="this.className='menu_title';" background="/images/Admin_left_1.gif"
                            height="25">
                            <span>自我管理</span>
                        </td>
                    </tr>
                    <tr>
                        <td id="submenu1">
                            <div class="sec_menu" style="width: 158px">
                                <table cellspacing="0" cellpadding="0" width="130" align="center">
                                    <tr>
                                        <td height="20">
                                            <a href="AdminLogout.aspx" target="mainFrame">(1)退出</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20">
                                            <a href="EditMyInfo.aspx" target="mainFrame">(2)修改自我信息</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 158px">
                                <table cellspacing="0" cellpadding="0" width="130" align="center">
                                    <tr>
                                        <td height="20">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="PanelManageAdmin" runat="server" Visible="false">
                    <table cellspacing="0" cellpadding="0" width="158" align="center">
                        <tr>
                            <td class="menu_title" id="Td2" onmouseover="this.className='menu_title2';" onclick="showsubmenu(2)"
                                onmouseout="this.className='menu_title';" background="/images/Admin_left_1.gif"
                                height="25">
                                <span>管理员管理</span>
                            </td>
                        </tr>
                        <tr>
                            <td id="submenu2">
                                <div class="sec_menu" style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                                <a href="ManageAdmins.aspx" target="mainFrame">(1)管理管理员</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddAdmin.aspx" target="mainFrame">(2)添加管理员</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="ManageAdminGroups.aspx" target="mainFrame">(3)管理管理组</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddAdminGroup.aspx" target="mainFrame">(4)添加管理组</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelNews" runat="server">
                    <table cellspacing="0" cellpadding="0" width="158" align="center">
                        <tr>
                            <td class="menu_title" id="Td5" onmouseover="this.className='menu_title2';" onclick="showsubmenu(4)"
                                onmouseout="this.className='menu_title';" background="/images/Admin_left_1.gif"
                                height="25">
                                <span>信息管理</span>
                            </td>
                        </tr>
                        <tr>
                            <td id="submenu4">
                                <div class="sec_menu" style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                                <a href="ManageArticles.aspx" target="mainFrame">(5)管理资讯</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddArticles.aspx" target="mainFrame">(6)添加资讯</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelArticleClass12" runat="server">
                    <table cellspacing="0" cellpadding="0" width="158" align="center">
                        <tr>
                            <td class="menu_title" id="Td1" onmouseover="this.className='menu_title2';" onclick="showsubmenu(7)"
                                onmouseout="this.className='menu_title';" background="/images/Admin_left_1.gif"
                                height="25">
                                <span>类别管理</span>
                            </td>
                        </tr>
                        <tr>
                            <td id="submenu7">
                                <div class="sec_menu" style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                                <a href="ManageArticleClass1s.aspx" target="mainFrame">(1)管理大类</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddArticleClass1.aspx" target="mainFrame">(2)添加大类</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="ManageArticleClass2s.aspx" target="mainFrame">(3)管理小类</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddArticleClass2.aspx" target="mainFrame">(4)添加小类</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="158" align="center" style="display:none">
                        <tr>
                            <td class="menu_title" id="Td3" onmouseover="this.className='menu_title2';" onclick="showsubmenu(8)"
                                onmouseout="this.className='menu_title';" background="/images/Admin_left_1.gif"
                                height="25">
                                <span>类型管理</span>
                            </td>
                        </tr>
                        <tr>
                            <td id="submenu8">
                                <div class="sec_menu" style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                                <a href="ManageBigTypes.aspx" target="mainFrame">(1)管理大类型</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddBigTypes.aspx" target="mainFrame">(2)添加大类型</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="ManageLittleTypes.aspx" target="mainFrame">(3)管理小类型</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                                <a href="AddLittleTypes.aspx" target="mainFrame">(4)添加小类型</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 158px">
                                    <table cellspacing="0" cellpadding="0" width="130" align="center">
                                        <tr>
                                            <td height="20">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</body>
</html>
