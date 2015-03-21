using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Business;
using Entity;

namespace WebBeijingFire.Admin
{
    public partial class AddArticleClass2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //表单验证时需要加
            this.Page.Form.Attributes.Add("onsubmit", "return $.formValidator.pageIsValid('1')");
            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }
            if (!IsPostBack)
            {
                drpArticleClass1ID.DataSource = WebClass.GetArticleClass1sEntityList();
                drpArticleClass1ID.DataTextField = "ArticleClass1Name";
                drpArticleClass1ID.DataValueField = "ArticleClass1ID";
                drpArticleClass1ID.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strArticleClass2Name = txtArticleClass2Name.Text.Trim();
            string strShowLevel = txtShowLevel.Text.Trim();
            string strArticleClass1ID = drpArticleClass1ID.SelectedValue;
            string strWords = txtWords.Text.Trim();

            ArticleClass2sEntity ac2 = new ArticleClass2sEntity();
            ac2.ArticleClass2Name = strArticleClass2Name;
            ac2.ShowLevel = Convert.ToInt32(strShowLevel);
            ac2.ArticleClass1ID = Convert.ToInt32(strArticleClass1ID);
            ac2.Words = strWords;

            WebClass.AddArticleClass2sEntity(ac2);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('添加小类成功！！')</script>");
            txtArticleClass2Name.Text = "";

        }
    }
}
