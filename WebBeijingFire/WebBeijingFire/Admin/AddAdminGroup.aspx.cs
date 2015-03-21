using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Business;

namespace WebBeijingFire.Admin
{
    public partial class AddAdminGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //表单验证时需要加
            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }
            if (Session["AdminGroupID"].ToString() != "1")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('您没有该权限！')</script>");
                return;
            }
            //表单验证时需要加
            this.Page.Form.Attributes.Add("onsubmit", "return $.formValidator.pageIsValid('1')");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strArticleClass1Name = txtAdminGroupName.Text.Trim();

            AdminGroupsEntity agi = new AdminGroupsEntity();
            agi.AdminGroupName = strArticleClass1Name;

            WebClass.AddAdminGroupsEntity(agi);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('添加管理组成功！！')</script>");
            txtAdminGroupName.Text = "";


        }
    }
}
