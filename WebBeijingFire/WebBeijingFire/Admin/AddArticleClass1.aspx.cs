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
    public partial class AddArticleClass1 : System.Web.UI.Page
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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strArticleClass1Name = txtArticleClass1Name.Text.Trim();
            string strShowLevel = txtShowLevel.Text.Trim();
            string strWords = txtWords.Text.Trim();

            ArticleClass1sEntity ac1 = new ArticleClass1sEntity();
            ac1.ArticleClass1Name = strArticleClass1Name;
            ac1.ShowLevel = Convert.ToInt32(strShowLevel);
            ac1.Words = strWords;

            WebClass.AddArticleClass1sEntity(ac1);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('添加大类成功！！')</script>");
            txtArticleClass1Name.Text = "";


        }
    }
}
