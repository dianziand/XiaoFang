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
    public partial class EditArticleClass2 : System.Web.UI.Page
    {
        int ArticleClass2ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //表单验证时需要加
            this.Page.Form.Attributes.Add("onsubmit", "return $.formValidator.pageIsValid('1')");
            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }

            try
            {
                if (Request.QueryString["ArticleClass2ID"] == null)
                {
                    ArticleClass2ID = 0;
                }
                else
                {
                    ArticleClass2ID = int.Parse(Request.QueryString["ArticleClass2ID"].ToString());
                }
            }
            catch
            {
                ArticleClass2ID = 0;
            }


            if (!IsPostBack)
            {



                SetArticleClass1Value(ArticleClass2ID);
            }
        }

        void SetArticleClass1Value(int _ArticleClass2ID)
        {

            drpArticleClass1ID.DataSource = WebClass.GetArticleClass1sEntityList();
            drpArticleClass1ID.DataTextField = "ArticleClass1Name";
            drpArticleClass1ID.DataValueField = "ArticleClass1ID";
            drpArticleClass1ID.DataBind();

            ArticleClass2sEntity ac2 = WebClass.GetArticleClass2sEntity(_ArticleClass2ID);
            txtArticleClass2Name.Text = ac2.ArticleClass2Name;
            drpArticleClass1ID.SelectedValue = ac2.ArticleClass1ID.ToString();
            txtShowLevel.Text = ac2.ShowLevel.ToString();
            txtWords.Text = ac2.Words;


        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strArticleClass2Name = txtArticleClass2Name.Text.Trim();
            string strShowLevel = txtShowLevel.Text.Trim();
            string strArticleClass1ID = drpArticleClass1ID.SelectedValue;
            string strWords = txtWords.Text.Trim();

            ArticleClass2sEntity ac2 = WebClass.GetArticleClass2sEntity(ArticleClass2ID);
            ac2.ArticleClass2Name = strArticleClass2Name;
            ac2.ShowLevel = Convert.ToInt32(strShowLevel);
            ac2.ArticleClass1ID = Convert.ToInt32(strArticleClass1ID);
            ac2.Words = strWords;

            WebClass.UpdateArticleClass2sEntity(ac2);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改小类成功！！')</script>");

        }
    }
}
