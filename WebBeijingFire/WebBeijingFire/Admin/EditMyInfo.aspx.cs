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
    public partial class EditMyInfo : System.Web.UI.Page
    {
        int AdminID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }

            AdminID = Convert.ToInt32(Session["AdminID"].ToString());

            //表单验证时需要加
            this.Page.Form.Attributes.Add("onsubmit", "return $.formValidator.pageIsValid('1')");

            if (!IsPostBack)
            {
                drpAdminGroupID.DataSource = WebClass.GetAdminGroupsEntityList();
                drpAdminGroupID.DataTextField = "AdminGroupName";
                drpAdminGroupID.DataValueField = "AdminGroupID";
                drpAdminGroupID.DataBind();

                AdminsEntity ai = WebClass.GetAdminsEntity(AdminID);
                txtAdminName.Text = ai.AdminName;
                txtAdminPwd.Text = ai.AdminPwd;
                drpAdminGroupID.SelectedValue = ai.AdminGroupID.ToString();

                if (ai.Active == 1)
                {
                    drpActive.SelectedValue = "1";
                }
                else
                {
                    drpActive.SelectedValue = "0";
                }

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strAdminPwd = txtAdminPwd.Text.Trim();

            AdminsEntity ai = WebClass.GetAdminsEntity(AdminID);


            ai.AdminPwd = strAdminPwd;
            WebClass.UpdateAdminsEntity(ai);


            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改成功！！')</script>");
        }
    }
}
