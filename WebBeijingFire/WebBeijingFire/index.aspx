<%@ Page Title="" Language="C#" MasterPageFile="~/TopBottom.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="WebBeijingFire.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">
        <div id="left_1">
            <span class="STYLE4">通知公告</span><span class="right"><a href="list.aspx?c2=1">更多>></a></span>
            <ul>
                <asp:Repeater ID="RepeaterTZGG" runat="server">
                    <ItemTemplate>
                        <li class="catno">
                            <img src="images/left_6.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div id="left_2">
            <table width="226" height="36" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="151">
                        <label>
                            <input name="textfield" type="text" size="20" style="border-bottom: 1px #4789bd  solid;
                                border-left: 1px #4789bd  solid; border-top: 1px #4789bd  solid; border-right: 1px #4789bd  solid;" />
                        </label>
                    </td>
                    <td width="75">
                        <label>
                            <input type="image" name="imageField" src="images/left_7.gif" />
                        </label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="left_3">
            <span class="STYLE5">协会动态</span>
            <ul style="margin-bottom: 0px;">
                <asp:Repeater ID="RepeaterXHDT" runat="server">
                    <ItemTemplate>
                        <li class="catno">
                            <img src="images/left_8.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div style="background-image: url(images/left_9.gif); margin-top: 0px; padding-top: 12px;">
                <span class="STYLE6">常务理事单位</span><span class="right00"><a href="list.aspx?c2=4">更多>></a></span></div>
            <ul style="margin-bottom: 0px;">
                <asp:Repeater ID="RepeaterCWLSDW" runat="server">
                    <ItemTemplate>
                        <li class="catno">
                            <img src="images/left_8.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div style="background-image: url(images/left_9.gif); margin-top: 0px; padding-top: 12px;">
                <span class="STYLE6">理事单位</span><span class="right02"><a href="list.aspx?c2=5">更多>></a></span></div>
            <ul style="margin-bottom: 0px;">
                <asp:Repeater ID="RepeaterLSDW" runat="server">
                    <ItemTemplate>
                        <li class="catno">
                            <img src="images/left_8.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div style="background-image: url(images/left_9.gif); margin-top: 0px; padding-top: 12px;">
                <span class="STYLE6">会员单位</span><span class="right02"><a href="list.aspx?c2=6">更多>></a></span></div>
            <ul style="margin-bottom: 0px;">
                <asp:Repeater ID="RepeaterHYDW" runat="server">
                    <ItemTemplate>
                        <li class="catno">
                            <img src="images/left_8.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div style="background-image: url(images/left_10.gif); margin-top: 0px; padding-top: 0px;
                height: 13px;">
            </div>
            <div id="left_4">
                <ol>
                    <li>
                        <img src="images/ga1.jpg" border="0" width="240" />
                        </li>
                    <li>
                        <img src="images/ga2.jpg" border="0" /></li>
                    <li>
                        <img src="images/ga3.jpg" border="0" /></li>
                    <li>
                        <img src="images/ga4.jpg" border="0" /></li>
                </ol>
            </div>
        </div>
    </div>
    <!--左列结束---------------------------------------------------------------->
    <!--右列开始---------------------------------------------------------------->
    <div id="main">
        <!----------------------右一头-------------------------------------------->
        <div id="main1">
            <div class="main1_1">
                <script language="javascript" src="js/MSClass.js"></script>
                <script type="text/javascript">


                    var focus_width = 308
                    var focus_height = 199
                    var text_height = 16
                    var swf_height = focus_height + text_height

                    var pics = '<%=pics %>'
                    var links = '<%=links %>'
                    var texts = '<%=texts %>'

                    document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
                    document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="images/info_ad.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
                    document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
                    document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
                    document.write('<embed src="images/info_ad.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#ffffff" quality="high" width="' + focus_width + '" height="' + swf_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); document.write('</object>');


                </script>
            </div>
            <div class="main1_2">
                <div style="margin-top: 0px; padding-top: 0px; padding-bottom: 8px;">
                    <span class="STYLE7">北京消防新闻</span><span class="right03"><a href="list.aspx?c2=7">更多>></a></span></div>
                <ul style="margin-bottom: 8px;">
                    <asp:Repeater ID="RepeaterBJXFXW" runat="server">
                        <ItemTemplate>
                            <li class="tt">
                                <img src="images/reght_2.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                    target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!-----------------------右一尾------------------------------------------->
        <!-----------------------右二头------------------------------------------->
        <div class="main2">            
            <EMBED height="100" pluginspage="http://www.macromedia.com/go/getflashplayer" src="468_60.swf" type=application/x-shockwave-flash width="690" wmode="transparent" quality="high"></EMBED><br / >
            <a href='http://www.bjhatd.com/' target="_blank" style='display:block;width:690px;height:100px;position:absolute;margin-top:-100px; z-index:999;background:#000;filter:alpha(opacity=0);-moz-opacity:0;opacity: 0' title='北京华安泰达科技有限公司'></a>
        </div>
        <!-----------------------右二尾------------------------------------------->
        <!-----------------------右三头------------------------------------------->
        <div id="main3">
            <div class="main3_1">
                <div style="margin-top: 0px; padding-top: 0px; padding-bottom: 8px;">
                    <span class="STYLE7">国内消防新闻 </span><span class="right04"><a href="list.aspx?c2=8">更多>></a></span></div>
                <div class="imgg">
                    <asp:Literal ID="literalGNXFXWPIC" runat="server"></asp:Literal></div>
                <ul style="margin-bottom: 8px;">
                    <asp:Repeater ID="RepeaterGNXFXW" runat="server">
                        <ItemTemplate>
                            <li class="ttt">
                                <img src="images/reght_4.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                    target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="main3_2">
                <div style="margin-top: 0px; padding-top: 0px; padding-bottom: 8px;">
                    <span class="STYLE7">国际消防新闻</span><span class="right04"><a href="list.aspx?c2=9"> 更多>></a></span></div>
                <div class="imgg">
                    <asp:Literal ID="literalGJXFXWPIC" runat="server"></asp:Literal>
                </div>
                <ul style="margin-bottom: 8px;">
                    <asp:Repeater ID="RepeaterGJXFXW" runat="server">
                        <ItemTemplate>
                            <li class="ttt">
                                <img src="images/reght_4.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                    target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!-----------------------右三尾------------------------------------------->
        <div class="main2">
            <table>
                <tr>
                    <td>
                        <a href="http://www.bjlhc.com.cn" target="_blank"><img src="images/lhcxf1.gif" height="80" width="350" border="0" /></a>
                    </td>
                    <td  align="center" width="350">
                    </td>
                </tr>
            </table>
        </div>
        <div id="main5">
            <iframe src="qyml.aspx" width="702" marginwidth="0" height="222" marginheight="0"
                align="middle" scrolling="no" frameborder="0"></iframe>
        </div>
        <div class="main2">
            <table>
                <tr>
                    <td>
                        <a href="http://xbcs.fire.net.cn/" target="_blank"><img src="images/xbcs.jpg" height="120" border="0" /></a>
                    </td>
                </tr>
            </table>
        </div>
        <!-----------------------右六头------------------------------------------->
        <div id="main6">
            <div class="main6_1">
                <div style="margin-top: 0px; padding-top: 0px; padding-bottom: 8px; padding-left: 18px;">
                    <span class="STYLE7">学术园地</span><span class="right05"><a href="list.aspx?c1=4">更多>></a></span></div>
                <ul style="margin-bottom: 8px;">
                    <asp:Repeater ID="RepeaterXSYD" runat="server">
                        <ItemTemplate>
                            <li class="ttt">
                                <img src="images/reght_4.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                    target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="main6_2">
                <div style="margin-top: 0px; padding-top: 0px; padding-bottom: 8px; padding-left: 18px;">
                    <span class="STYLE7">消防科普</span><span class="right05"><a href="list.aspx?c1=5"> 更多>></a></span></div>
                <ul style="margin-bottom: 8px;">
                    <asp:Repeater ID="RepeaterXFKP" runat="server">
                        <ItemTemplate>
                            <li class="ttt">
                                <img src="images/reght_4.gif" /><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>"
                                    target="_blank"><%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div id="main7">
            <script src="js/MSClasss.js" language="javascript"></script>
            <div id="marqueediv1" style="margin-top: 14px; padding-left: 2px; margin-left: 0px;
                overflow: hidden; width: 630px; height: 160px;">
                <asp:Repeater ID="RepeaterCPTJ" runat="server">
                    <ItemTemplate>
                        <a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>" target="_blank">
                            <img class="bian2" height="128" src="<%#DataBinder.Eval(Container.DataItem, "sPic")%>"
                                onload="javascript:resizepic300(this);" border="0" style="margin-right: 12px;"></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <script>
                new Marquee("marqueediv1", 2, 1, 650, 160, 20, 0, 0)
            </script>
        </div>
        <!-----------------------右六尾------------------------------------------->
    </div>
    <!--右列结束---------------------------------------------------------------->
</asp:Content>
