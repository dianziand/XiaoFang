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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //表单验证时需要加
            this.Page.Form.Attributes.Add("onsubmit", "return $.formValidator.pageIsValid('1')");
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            string strAdminName = txtAdminName.Text.Trim();
            string strAdminPwd = txtAdminPwd.Text.Trim();


            AdminsEntity ai = WebClass.GetAdminsEntity(strAdminName);
            if (ai == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('用户名错！')</script>");
                return;
            }

            if (ai.AdminPwd.Trim() != strAdminPwd)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('密码错！')</script>");
                return;
            }


            if (ai.Active == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('您已被禁止登陆！')</script>");
                return;
            }
            ai.LastLoginTime = DateTime.Now;
            ai.LoginCount++;
            ai.IP = Request.ServerVariables.GetValues("REMOTE_ADDR")[0].ToString();
            WebClass.UpdateAdminsEntity(ai);

            Session["AdminName"] = ai.AdminName;
            Session["AdminID"] = ai.AdminID;
            Session["AdminGroupID"] = ai.AdminGroupID;
            Session["CityID"] = ai.CityID;
            Response.Write("<script>window.top.location='AdminIndex.aspx';</script>");
        }
    }
}