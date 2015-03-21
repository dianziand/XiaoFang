using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;

namespace WebBeijingFire.Admin
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            if (!IsPostBack)
            {
                drpAdminGroupID.DataSource = WebClass.GetAdminGroupsEntityList();
                drpAdminGroupID.DataTextField = "AdminGroupName";
                drpAdminGroupID.DataValueField = "AdminGroupID";
                drpAdminGroupID.DataBind();


            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strAdminName = txtAdminName.Text.Trim();
            string strAdminPwd = txtAdminPwd.Text.Trim();
            string strActive = drpActive.SelectedValue;
            string strAdminGroupID = drpAdminGroupID.SelectedValue;

            AdminsEntity ai = new AdminsEntity();
            ai.AdminGroupID = Convert.ToInt32(strAdminGroupID);
            if (strActive == "1")
            {
                ai.Active = 1;
            }
            else
            {
                ai.Active = 0;
            }
            ai.AdminName = strAdminName;
            ai.AdminPwd = strAdminPwd;
            WebClass.AddAdminsEntity(ai);


            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('添加管理员成功！！')</script>");
            txtAdminName.Text = "";
            txtAdminPwd.Text = "";
        }

    }
}
