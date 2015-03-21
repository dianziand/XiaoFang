using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBeijingFire.Admin
{
    public partial class AdminLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] != null)
            {
                Session["AdminName"] = null;
                Session["AdminID"] = null;
            }
            Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
            return;
        }
    }
}