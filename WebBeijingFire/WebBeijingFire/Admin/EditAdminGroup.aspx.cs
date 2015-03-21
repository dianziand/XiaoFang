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
    public partial class EditAdminGroup : System.Web.UI.Page
    {
        int AdminGroupID = 0;
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


            try
            {
                if (Request.QueryString["AdminGroupID"] == null)
                {
                    AdminGroupID = 0;
                }
                else
                {
                    AdminGroupID = int.Parse(Request.QueryString["AdminGroupID"].ToString());
                }
            }
            catch
            {
                AdminGroupID = 0;
            }
            if (!IsPostBack)
            {
                SetAdminGroupsValue(AdminGroupID);
            }
        }
        void SetAdminGroupsValue(int _AdminGroupID)
        {
            AdminGroupsEntity agi = WebClass.GetAdminGroupsEntity(_AdminGroupID);
            txtAdminGroupName.Text = agi.AdminGroupName;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strArticleClass1Name = txtAdminGroupName.Text.Trim();

            AdminGroupsEntity agi = WebClass.GetAdminGroupsEntity(AdminGroupID);
            agi.AdminGroupName = strArticleClass1Name;

            WebClass.UpdateAdminGroupsEntity(agi);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改管理组成功！！')</script>");

        }
    }
}
