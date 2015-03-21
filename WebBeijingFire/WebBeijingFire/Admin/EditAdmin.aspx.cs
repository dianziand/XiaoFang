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
    public partial class EditAdmin : System.Web.UI.Page
    {
        int AdminID = 0;

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

            try
            {
                if (Request.QueryString["AdminID"] == null)
                {
                    AdminID = 0;
                }
                else
                {
                    AdminID = int.Parse(Request.QueryString["AdminID"].ToString());
                }
            }
            catch
            {
                AdminID = 0;
            }

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
            string strAdminName = txtAdminName.Text.Trim();
            string strAdminPwd = txtAdminPwd.Text.Trim();
            string strActive = drpActive.SelectedValue;
            string strAdminGroupID = drpAdminGroupID.SelectedValue;

            AdminsEntity ai = WebClass.GetAdminsEntity(AdminID);

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
            WebClass.UpdateAdminsEntity(ai);


            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改管理员成功！！')</script>");
        }

    }
}
