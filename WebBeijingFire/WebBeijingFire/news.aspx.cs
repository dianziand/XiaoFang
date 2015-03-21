using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;

namespace WebBeijingFire
{
    public partial class news : System.Web.UI.Page
    {
        public int  ArticleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Request.QueryString["ID"] == null)
                {
                    ArticleID = 0;
                }
                else
                {
                    ArticleID = int.Parse(Request.QueryString["ID"].ToString());
                }
            }
            catch
            {
                ArticleID = 0;
            }
            if (ArticleID == 0) return;
            if (!IsPostBack)
            {
                ArticlesEntity ai = WebClass.GetArticlesEntity(ArticleID);


                ai.Hits++;
                LtAddDate.Text = ai.AddDate.ToLongDateString();
                LtContent.Text = ai.Content;
                LtTitle.Text = ai.Title;
                if (ai.Source.Trim().Length > 0)
                {
                    if (ai.SourceUrl.Trim().Length > 0)
                        LtSource.Text = "来源：<a href=" + ai.SourceUrl + " target=_blank>" + ai.Source + "</a>";
                    else
                        LtSource.Text = "来源：" + ai.Source;
                }
                LtHits.Text = ai.Hits.ToString();
                ArticleClass1sEntity ar1 = WebClass.GetArticleClass1sEntity(ai.ArticleClass1ID);
                LtDaoHang.Text = "<a href=#>资讯</a> > <a href=/list.aspx?C1=" + ai.ArticleClass1ID + ">" + ar1.ArticleClass1Name + "</a>";

                Page.Title = ai.Title + " -- 北京消防网www.beijingfire.com";
                WebClass.UpdateHits(ArticleID);



                //右边资讯
                RepeaterRightZX.DataSource = WebClass.GetArticlesListDataView(15, 20, ai.ArticleClass1ID, ai.ArticleClass2ID, "1");
                RepeaterRightZX.DataBind();

            }
        }
    }
}