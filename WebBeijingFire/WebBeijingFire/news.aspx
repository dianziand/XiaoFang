<%@ Page Title="" Language="C#" MasterPageFile="~/TopBottom.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="WebBeijingFire.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/global.css" rel="stylesheet" type="text/css" />
 <div class="center">
        <div class="zxggy_left">
            <div class="news1">
                <div class="news_list_title">
                    您当前的位置：<asp:Literal ID="LtDaoHang" runat="server"></asp:Literal></div>
                <div class="news1_bottom">
                </div>
                <div class="news1_bottom_top">
                    <b>
                        <asp:Literal ID="LtTitle" runat="server"></asp:Literal></b>
                    <asp:Literal ID="LtSource" runat="server"></asp:Literal>&nbsp;&nbsp;
                    <asp:Literal ID="LtAddDate" runat="server"></asp:Literal>&nbsp;&nbsp;点击：<asp:Literal
                        ID="LtHits" runat="server"></asp:Literal>
                </div>
                <div class="news1_bottom_news">
                    <p>
                        <asp:Literal ID="LtContent" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <div class="zxggy_right">
            &nbsp;<div class="news_more">
                <div class="news_more_news">
                    <ul>
                        <asp:Repeater ID="RepeaterRightZX" runat="server">
                            <ItemTemplate>
                                <li style="margin-left: 5px">·<a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

