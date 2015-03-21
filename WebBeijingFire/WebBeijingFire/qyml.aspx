<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qyml.aspx.cs" Inherits="WebBeijingFire.qyml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>企业名录</title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        body {
            background: #FFF;
            color: #333;
        }

        #hotnews ul li a {
            color: #fff;
            text-decoration: none;
        }

        #hotnews a:hover {
            text-decoration: underline;
        }

        #hotnews ul, li {
            list-style: none;
        }

        #hotnews li {
            float: left;
            width: 230px;
        }

        .wrap {
            width: 697px;
            margin: 0 auto;
            line-height: 25px;
            font-size: 12px;
        }

        #hotnews h1 {
            text-align: center;
            margin-top: 50px;
        }

        #hotnews {
            position: relative;
            width: 697px;
            margin: 0 auto;
            height: 218px;
            margin-top: 0px;
            border-left: 1px #a5d4ff solid;
            border-top: 1px #a5d4ff solid;
            border-right: 1px #a5d4ff solid;
            border-bottom: 1px #a5d4ff solid;
        }

            #hotnews h2 {
                display: block;
                float: left;
                width: 80px;
                margin-right: 2px;
                font-size: 12px;
                font-weight: normal;
                text-align: center;
                cursor: pointer;
            }

            #hotnews .title_normal {
                background: #b8ceff;
            }

            #hotnews .title_current {
                background: #0193df;
                color: #FFF;
            }

            #hotnews ul {
                position: absolute;
                left: 0px;
                top: 25px;
                width: 693px;
                height: 185px;
                padding: 8px 0 0 5px;
                border-top: 3px solid #0193df;
                font-size: 14px;
                background-image: url(/images/reght_9.gif);
                solid;
                border-bottom: 1px #a5d4ff solid;
                background-repeat: repeat-x;
            }
    </style>
</head>
<body>
    <div class="wrap">
        <div id="hotnews">
            <h2>企业名录</h2>
            <ul>
                <asp:Repeater ID="RepeaterQYML" runat="server">
                    <ItemTemplate>
                        <li><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>" target="_blank">
                            <%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                <li style="width: 100%; text-align: right;"><a href="list.aspx?c1=3&c2=0" target="_blank">更多>></a></li>
            </ul>
            <asp:Repeater ID="RepeaterQYMLList" runat="server" OnItemDataBound="RepeaterQYMLList_ItemDataBound">
                <ItemTemplate>
                    <h2><%#DataBinder.Eval(Container.DataItem, "ArticleClass2Name")%></h2>
                    <ul>
                        <asp:Repeater ID="repeaterQYMLDetail" runat="server">
                            <ItemTemplate>
                                <li><a href="<%#DataBinder.Eval(Container.DataItem, "Url")%>" target="_blank">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li style="width: 100%; text-align: right;"><a href="list.aspx?c1=<%#DataBinder.Eval(Container.DataItem, "ArticleClass1ID")%>&c2=<%#DataBinder.Eval(Container.DataItem, "ArticleClass2ID")%>" target="_blank">更多>></a></li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <script>
        function $(id) { return document.getElementById(id); }
        function $tag(id, tagName) { return $(id).getElementsByTagName(tagName) }
        var onum = 0; //用于控制默认打开的标签
        var Ds = $tag("hotnews", "ul");
        var Ts = $tag("hotnews", "h2");
        for (var i = 0; i < Ds.length; i++) {
            if (i == onum) {
                Ds[i].style.display = "block";
                Ts[i].className = "title_current";
            }
            else {
                Ds[i].style.display = "none";
                Ts[i].className = "title_normal";
            }
            Ts[i].value = i;
            Ts[i].onmouseover = function () {
                if (onum == this.value) { return false; };
                Ts[onum].className = "title_normal";
                Ts[this.value].className = "title_current";
                Ds[onum].style.display = "none";
                Ds[this.value].style.display = "block";
                onum = this.value;
            }
        }
    </script>
</body>
</html>
