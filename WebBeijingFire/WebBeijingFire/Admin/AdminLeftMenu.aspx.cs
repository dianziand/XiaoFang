using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBeijingFire.Admin
{
    public partial class AdminLeftMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }


            PanelManageAdmin.Visible = false;
            PanelNews.Visible = false;
            PanelArticleClass12.Visible = false;

            //系统管理员
            if (Session["AdminGroupID"].ToString() == "1")
            {
                PanelManageAdmin.Visible = true;
                PanelNews.Visible = true;
                PanelArticleClass12.Visible = true;
            }

            //分站管理员
            if (Session["AdminGroupID"].ToString() == "2")
            {
                PanelNews.Visible = true;
            }

        }
    }
}
