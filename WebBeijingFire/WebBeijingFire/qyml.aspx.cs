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
    public partial class qyml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //企业名录
            RepeaterQYML.DataSource = WebClass.GetArticlesListDataView(18, 15, 3, 0, "1");
            RepeaterQYML.DataBind();

            //分小类展示企业名录
            RepeaterQYMLList.DataSource = WebClass.GetArticleClass2sEntityList(0, "ArticleClass1ID = 3", " ShowLevel asc ");
            RepeaterQYMLList.DataBind();

        }

        protected void RepeaterQYMLList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeaterQYMLDetail = ((Repeater)e.Item.FindControl("repeaterQYMLDetail"));
                ArticleClass2sEntity class2Entity = (ArticleClass2sEntity)e.Item.DataItem;


                repeaterQYMLDetail.DataSource = WebClass.GetArticlesListDataView(18, 15, class2Entity.ArticleClass1ID, class2Entity.ArticleClass2ID, "1");
                repeaterQYMLDetail.DataBind();
            }
        }
    }
}