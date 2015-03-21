using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Business;

namespace WebBeijingFire.Admin
{
    public partial class ManageAdmins : System.Web.UI.Page
    {
        private int page = 1;
        private int TotalPage = 0;
        private int totalRecord = 0;
        private int PageSize = 15;

        string url = "ManageAdmins.aspx";
        private int TotalPageLinkButton = 20;


        string Key = "";
        int Active = -1;
        int AdminGroupID = 0;


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
            getTheParam();

            if (!IsPostBack)
            {

                txtKey.Text = Server.UrlDecode(Key);
                drpAdminGroupID.DataSource = WebClass.GetAdminGroupsEntityList();
                drpAdminGroupID.DataTextField = "AdminGroupName";
                drpAdminGroupID.DataValueField = "AdminGroupID";
                drpAdminGroupID.DataBind();
                drpAdminGroupID.Items.Insert(0, new ListItem("全部", "0"));

                bindInfoListData(page);

            }


        }

        void getTheParam()
        {

            try
            {
                if (Request.QueryString["page"] == null)
                {
                    page = 1;
                }
                else
                {
                    page = int.Parse(Request.QueryString["page"].ToString());
                }
            }
            catch
            {
                page = 1;
            }

            try
            {
                if (Request.QueryString["Active"] == null)
                {
                    Active = -1;
                }
                else
                {
                    Active = int.Parse(Request.QueryString["Active"].ToString());
                }
            }
            catch
            {
                Active = -1;
            }

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


            try
            {
                if (Request.QueryString["Key"] == null)
                {
                    Key = "";
                }
                else
                {
                    Key = Request.QueryString["Key"].ToString();
                }
            }
            catch
            {
                Key = "";
            }


        }

        protected void LBDelete_Command(object sender, CommandEventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            int id = Convert.ToInt32(lb.ToolTip);
            WebClass.DeleteAdminsEntity(id);


            Key = txtKey.Text.Trim();
            Active = Convert.ToInt32(drpActive.SelectedValue);
            AdminGroupID = Convert.ToInt32(drpAdminGroupID.SelectedValue);

            bindInfoListData(page);
        }


        protected void List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((LinkButton)e.Item.FindControl("LBDelete")).Attributes["onclick"] = "return confirm('确认要删除么？')";
            }
        }

        void bindInfoListData(int _page)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 ");
            if (Key.Trim().Length > 0)
            {
                strWhere.Append(" and AdminName like '%").Append(Key).Append("%' ");
            }
            if (Active > -1)
            {
                strWhere.Append(" and Active =").Append(Active).Append(" ");
            }
            if (AdminGroupID > 0)
            {
                strWhere.Append(" and AdminGroupID =").Append(AdminGroupID).Append(" ");
            }

            ArticleRepeater.DataSource = WebClass.GetResultSP_Page2000(" Admins act ", "*,(select AdminGroupName from AdminGroups where AdminGroupID=act.AdminGroupID) as AdminGroupName ", PageSize, page, out TotalPage, out totalRecord, "AdminID", 0, strWhere.ToString(), "AdminID", 0);
            ArticleRepeater.DataBind();

            TotalPage = totalRecord / PageSize;

            if (totalRecord % PageSize > 0) //多一个就多一页
            {
                TotalPage++;
            }

            if (_page > TotalPage)
            {
                _page = TotalPage;
            }


            int temp = TotalPageLinkButton / 2;

            int start = _page - temp;
            int end = _page + temp;
            if (start < 0)
            {
                start = 1;
                end = TotalPageLinkButton;
            }

            if (end > TotalPage)
            {
                end = TotalPage;
                start = TotalPage - TotalPageLinkButton + 1;
            }
            if (start < 1) start = 1;

            StringBuilder allpage = new StringBuilder();

            if (_page >= 1)
            {
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&Active=").Append(Active).Append("&AdminGroupID=").Append(AdminGroupID).Append("&page=1>首页</a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&Active=").Append(Active).Append("&AdminGroupID=").Append(AdminGroupID).Append("&page=").Append(_page - 1).Append("><<上一页</a></div>");
            }
            allpage.Append("<span>");
            for (int i = start; i <= end; i++)
            {
                if (i != _page)
                {
                    allpage.Append("<a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&Active=").Append(Active).Append("&AdminGroupID=").Append(AdminGroupID).Append("&page=").Append(i).Append(">").Append(i).Append("</a>");
                }
                else
                {
                    allpage.Append("<b>").Append(i).Append("</b>");
                }
            }

            allpage.Append("</span>");
            if (_page <= TotalPage)
            {
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&Active=").Append(Active).Append("&AdminGroupID=").Append(AdminGroupID).Append("&page=").Append(_page + 1).Append(">下一页>></a></div>");
                allpage.Append("<div class='page070129'><a href=").Append(url).Append("?Key=").Append(Server.UrlEncode(Key)).Append("&Active=").Append(Active).Append("&AdminGroupID=").Append(AdminGroupID).Append("&page=").Append(TotalPage).Append(">尾页</a></div>");
            }


            LtPage1.Text = _page.ToString();// +"/" + TotalPage.ToString() + " 共" + totalRecord.ToString() + "条记录";
            LtTotalPage1.Text = TotalPage.ToString(); //总页数        


            AllCount1.Text = totalRecord.ToString(); //所有记录数

            AllPage1.Text = allpage.ToString();

            LtPageSize1.Text = PageSize.ToString();

            LtPage2.Text = LtPage1.Text;
            LtTotalPage2.Text = LtTotalPage1.Text;
            AllCount2.Text = AllCount1.Text;
            AllPage2.Text = AllPage1.Text;
            LtPageSize2.Text = LtPageSize1.Text;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Key = txtKey.Text.Trim();
            Key = txtKey.Text.Trim();
            Active = Convert.ToInt32(drpActive.SelectedValue);
            AdminGroupID = Convert.ToInt32(drpAdminGroupID.SelectedValue);
            bindInfoListData(1);
        }

    }
}
