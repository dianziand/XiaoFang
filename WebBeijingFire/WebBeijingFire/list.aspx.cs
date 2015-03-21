using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;
using System.Text;
using Business;
using System.Data;

namespace WebBeijingFire
{
    public partial class list : System.Web.UI.Page
    {
        public int ArticleClass1ID = 0, ArticleClass2ID = 0;

        private int page = 1;
        private int TotalPage = 0;
        private int totalRecord = 0;
        private int PageSize = 30;

        string url = "list.aspx";
        private int TotalPageLinkButton = 20;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Request.QueryString["c1"] == null)
                {
                    ArticleClass1ID = 0;
                }
                else
                {
                    ArticleClass1ID = int.Parse(Request.QueryString["c1"].ToString());
                }
            }
            catch
            {
                ArticleClass1ID = 0;
            }

            try
            {
                if (Request.QueryString["c2"] == null)
                {
                    ArticleClass2ID = 0;
                }
                else
                {
                    ArticleClass2ID = int.Parse(Request.QueryString["c2"].ToString());
                }
            }
            catch
            {
                ArticleClass2ID = 0;
            }


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



            if (!IsPostBack)
            {
                LtDaoHang.Text = "<a href=#>资讯</a> ";
                string title = "";
                if (ArticleClass1ID > 0)
                {
                    ArticleClass1sEntity ar1 = WebClass.GetArticleClass1sEntity(ArticleClass1ID);
                    LtDaoHang.Text = "> <a href=/list.aspx?C1=" + ArticleClass1ID + ">" + ar1.ArticleClass1Name + "</a>";
                    title = ar1.ArticleClass1Name;
                }
                if (ArticleClass2ID > 0)
                {
                    ArticleClass2sEntity ar2 = WebClass.GetArticleClass2sEntity(ArticleClass2ID);
                    LtDaoHang.Text += "> <a href=/list.aspx?C2=" + ArticleClass2ID + ">" + ar2.ArticleClass2Name + "</a>";
                    title = ar2.ArticleClass2Name;
                }
                Page.Title = title + " -- 北京消防网www.beijingfire.com";


                bindInfoListData(page);

                //右边资讯
                RepeaterRightZX.DataSource = WebClass.GetArticlesListDataView(15, 20, ArticleClass1ID, ArticleClass2ID, "1");
                RepeaterRightZX.DataBind();

            }
        }



        void bindInfoListData(int _page)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            if (ArticleClass1ID > 0)
            {
                strWhere.Append(" and ArticleClass1ID=").Append(ArticleClass1ID);
            }
            if (ArticleClass2ID > 0)
            {
                strWhere.Append(" and ArticleClass2ID=").Append(ArticleClass2ID);
            }
            DataView dv = WebClass.GetResultSP_Page2000(" Articles act ", "* ", PageSize, page, out TotalPage, out totalRecord, "ShowLevel asc,ArticleID", 1, strWhere.ToString(), "ArticleID", 0).DefaultView;
            foreach (DataRowView drv in dv)
            {
                if (drv["IsUrl"].ToString() == "0")
                {
                    drv["Url"] = "/news.aspx?ID=" + drv["ArticleID"];
                }
            }
            RepeaterNewsList.DataSource = dv;
            RepeaterNewsList.DataBind();

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
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?c1=").Append(ArticleClass1ID).Append("&c2=").Append(ArticleClass2ID).Append("&page=1>首页</a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?c1=").Append(ArticleClass1ID).Append("&c2=").Append(ArticleClass2ID).Append("&page=").Append(_page - 1).Append("><<上一页</a></div>");
            }
            allpage.Append("<span style=\"margin-top:-18px;\">");
            for (int i = start; i <= end; i++)
            {
                if (i != _page)
                {
                    allpage.Append("<a href=").Append(url).Append("?c1=").Append(ArticleClass1ID).Append("&c2=").Append(ArticleClass2ID).Append("&page=").Append(i).Append(">").Append(i).Append("</a>");
                }
                else
                {
                    allpage.Append("<b>").Append(i).Append("</b>");
                }
            }

            allpage.Append("</span>");
            if (_page <= TotalPage)
            {
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?c1=").Append(ArticleClass1ID).Append("&c2=").Append(ArticleClass2ID).Append("&page=").Append(_page + 1).Append(">下一页>></a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?c1=").Append(ArticleClass1ID).Append("&c2=").Append(ArticleClass2ID).Append("&page=").Append(TotalPage).Append(">尾页</a></div>");
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
    }
}