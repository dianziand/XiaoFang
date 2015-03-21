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
    public partial class EditArticleClass1 : System.Web.UI.Page
    {
        int ArticleClass1ID = 0;
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
            if (!IsPostBack)
            {
                SetArticleClass1Value(ArticleClass1ID);
            }
        }
        void SetArticleClass1Value(int _ArticleClass1ID)
        {
            ArticleClass1sEntity ac1 = WebClass.GetArticleClass1sEntity(_ArticleClass1ID);
            txtArticleClass1Name.Text = ac1.ArticleClass1Name;
            txtShowLevel.Text = ac1.ShowLevel.ToString();
            txtWords.Text = ac1.Words;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strArticleClass1Name = txtArticleClass1Name.Text.Trim();
            string strShowLevel = txtShowLevel.Text.Trim();
            string strWords = txtWords.Text.Trim();

            ArticleClass1sEntity ac1 = WebClass.GetArticleClass1sEntity(ArticleClass1ID);
            ac1.ArticleClass1Name = strArticleClass1Name;
            ac1.ShowLevel = Convert.ToInt32(strShowLevel);
            ac1.Words = strWords;


            WebClass.UpdateArticleClass1sEntity(ac1);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改大类成功！！')</script>");


        }
    }
}
