<%@ Page Title="" Language="C#" MasterPageFile="~/TopBottom.Master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="WebBeijingFire.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/style/page.css" rel="stylesheet" type="text/css" />
    <div class="center">
        <div class="zxggy_left">
            <div class="news1">
                <div class="news_list_title">
                    您当前的位置：<asp:Literal ID="LtDaoHang" runat="server"></asp:Literal></div>
                <div class="news1_bottom">
                </div>
                <div class="PicPage070129" >
                    <div class="Pagediv070129">
                        页次:
                        <asp:Literal ID="LtPage1" runat="server"></asp:Literal>
                        /<asp:Literal ID="LtTotalPage1" runat="server"></asp:Literal>&nbsp; 每页:<asp:Literal
                            ID="LtPageSize1" runat="server"></asp:Literal>
                        &nbsp; 共:<asp:Literal ID="AllCount1" runat="server"></asp:Literal>条 &nbsp;<asp:Literal
                            ID="AllPage1" runat="server"></asp:Literal>
                    </div>
                </div>
                <div>
                    <ul style="width: 100%">
                        <asp:Repeater ID="RepeaterNewsList" runat="server">
                            <ItemTemplate>
                                <li style="margin-left: 5px; margin-top: 6px;">·<a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>" target="_blank">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
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
            </div>
        </div>
        <div class="zxggy_right">
            &nbsp;<div class="news_more">
                <div class="news_more_news">
                    <ul>
                        <asp:Repeater ID="RepeaterRightZX" runat="server">
                            <ItemTemplate>
                                <li style="margin-left: 5px">·<a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>" target="_blank">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
