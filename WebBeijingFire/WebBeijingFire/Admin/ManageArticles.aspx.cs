﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Entity;
using Business;

namespace WebBeijingFire.Admin
{
    public partial class ManageArticles : System.Web.UI.Page
    {
        private int page = 1;
        private int TotalPage = 0;
        private int totalRecord = 0;
        private int PageSize = 40;

        string url = "ManageArticles.aspx";
        private int TotalPageLinkButton = 20;


        string Key = "";

        int ArticleID = 0;
        int ArticleClass1ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }


            getTheParam();

            if (!IsPostBack)
            {


                DrpArticleClass1ID.DataSource = WebClass.GetArticleClass1sEntityList();
                DrpArticleClass1ID.DataTextField = "ArticleClass1Name";
                DrpArticleClass1ID.DataValueField = "ArticleClass1ID";
                DrpArticleClass1ID.DataBind();
                DrpArticleClass1ID.Items.Insert(0, new ListItem("全部", "0"));

                txtKey.Text = Server.UrlDecode(Key);


                bindInfoListData(page);

            }


        }

        void getTheParam()
        {

            try
            {
                if (Request.QueryString["page"] == null)
                {
                    page = 1;
                }
                else
                {
                    page = int.Parse(Request.QueryString["page"].ToString());
                }
            }
            catch
            {
                page = 1;
            }

            try
            {
                if (Request.QueryString["ArticleClass1ID"] == null)
                {
                    ArticleClass1ID = 0;
                }
                else
                {
                    ArticleClass1ID = int.Parse(Request.QueryString["ArticleClass1ID"].ToString());
                }
            }
            catch
            {
                ArticleClass1ID = 0;
            }


            try
            {
                if (Request.QueryString["ArticleID"] == null)
                {
                    ArticleID = 0;
                }
                else
                {
                    ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                }
            }
            catch
            {
                ArticleID = 0;
            }


            try
            {
                if (Request.QueryString["Key"] == null)
                {
                    Key = "";
                }
                else
                {
                    Key = Request.QueryString["Key"].ToString();
                }
            }
            catch
            {
                Key = "";
            }


        }

        protected void LBDelete_Command(object sender, CommandEventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            int id = Convert.ToInt32(lb.ToolTip);
            WebClass.DeleteArticlesEntity(id);


            Key = txtKey.Text.Trim();

            ArticleClass1ID = Convert.ToInt32(DrpArticleClass1ID.SelectedValue);

            bindInfoListData(page);
        }


        protected void List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((LinkButton)e.Item.FindControl("LBDelete")).Attributes["onclick"] = "return confirm('确认要删除么？')";
            }
        }

        void bindInfoListData(int _page)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            if (Key.Trim().Length > 0)
            {
                strWhere.Append(" and Title like '%").Append(Key).Append("%' ");
            }

            if (ArticleID > 0)
            {
                strWhere.Append(" and ArticleID=").Append(ArticleID).Append(" ");
            }

            if (ArticleClass1ID > 0)
            {
                strWhere.Append(" and ArticleClass1ID=").Append(ArticleClass1ID).Append(" ");
            }


            DataView dv = WebClass.GetResultSP_Page2000(" Articles act ", " *,(select ArticleClass1Name from ArticleClass1s where ArticleClass1ID=act.ArticleClass1ID) as ArticleClass1Name,(select ArticleClass2Name from ArticleClass2s where ArticleClass2ID=act.ArticleClass2ID) as ArticleClass2Name,(select AdminName from Admins where AdminID=act.AdminID) as AdminName ", PageSize, page, out TotalPage, out totalRecord, "ArticleID", 1, strWhere.ToString(), "ArticleID", 0).DefaultView;

            foreach (DataRowView drv in dv)
            {
                if (drv["IsUrl"].ToString() == "0")
                {
                    drv["Url"] = "/News.aspx?ID=" + drv["ArticleID"];
                }
            }

            ArticleRepeater.DataSource = dv;
            ArticleRepeater.DataBind();

            TotalPage = totalRecord / PageSize;

            if (totalRecord % PageSize > 0) //多一个就多一页
            {
                TotalPage++;
            }

            if (_page > TotalPage)
            {
                _page = TotalPage;
            }


            int temp = TotalPageLinkButton / 2;

            int start = _page - temp;
            int end = _page + temp;
            if (start < 0)
            {
                start = 1;
                end = TotalPageLinkButton;
            }

            if (end > TotalPage)
            {
                end = TotalPage;
                start = TotalPage - TotalPageLinkButton + 1;
            }
            if (start < 1) start = 1;

            StringBuilder allpage = new StringBuilder();

            if (_page >= 1)
            {
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&ArticleID=").Append(ArticleID).Append("&ArticleClass1ID=").Append(ArticleClass1ID).Append("&page=1>首页</a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&ArticleID=").Append(ArticleID).Append("&ArticleClass1ID=").Append(ArticleClass1ID).Append("&page=").Append(_page - 1).Append("><<上一页</a></div>");
            }
            allpage.Append("<span>");
            for (int i = start; i <= end; i++)
            {
                if (i != _page)
                {
                    allpage.Append("<a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&ArticleID=").Append(ArticleID).Append("&ArticleClass1ID=").Append(ArticleClass1ID).Append("&page=").Append(i).Append(">").Append(i).Append("</a>");
                }
                else
                {
                    allpage.Append("<b>").Append(i).Append("</b>");
                }
            }

            allpage.Append("</span>");
            if (_page <= TotalPage)
            {
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&ArticleID=").Append(ArticleID).Append("&ArticleClass1ID=").Append(ArticleClass1ID).Append("&page=").Append(_page + 1).Append(">下一页>></a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&ArticleID=").Append(ArticleID).Append("&ArticleClass1ID=").Append(ArticleClass1ID).Append("&page=").Append(TotalPage).Append(">尾页</a></div>");
            }


            LtPage1.Text = _page.ToString();// +"/" + TotalPage.ToString() + " 共" + totalRecord.ToString() + "条记录";
            LtTotalPage1.Text = TotalPage.ToString(); //总页数        


            AllCount1.Text = totalRecord.ToString(); //所有记录数

            AllPage1.Text = allpage.ToString();

            LtPageSize1.Text = PageSize.ToString();

            LtPage2.Text = LtPage1.Text;
            LtTotalPage2.Text = LtTotalPage1.Text;
            AllCount2.Text = AllCount1.Text;
            AllPage2.Text = AllPage1.Text;
            LtPageSize2.Text = LtPageSize1.Text;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Key = txtKey.Text.Trim();

            if (TxtArticleID.Text.Trim().Length > 0)
            {
                ArticleID = Convert.ToInt32(TxtArticleID.Text);
            }
            ArticleClass1ID = Convert.ToInt32(DrpArticleClass1ID.SelectedValue);

            bindInfoListData(1);
        }

    }
}
