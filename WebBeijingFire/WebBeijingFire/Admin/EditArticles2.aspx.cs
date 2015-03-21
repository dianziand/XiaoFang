using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Business;
using Entity;
using Common;

namespace WebBeijingFire.Admin
{
    public partial class EditArticles2 : System.Web.UI.Page
    {
        int ArticleID = 0;
        public static readonly string UploadPath = System.Configuration.ConfigurationSettings.AppSettings["UploadPath"];
        string MuLu = "Images/";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }

            try
            {
                if (Request.QueryString["ArticleID"] == null)
                {
                    ArticleID = 0;
                }
                else
                {
                    ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                }
            }
            catch
            {
                ArticleID = 0;
            }

            if (!IsPostBack)
            {

                ArticlesEntity ni = WebClass.GetArticlesEntity(ArticleID);

                //信息分类
                DrpArticleClass1ID.DataSource = WebClass.GetArticleClass1sEntityList();
                DrpArticleClass1ID.DataTextField = "ArticleClass1Name";
                DrpArticleClass1ID.DataValueField = "ArticleClass1ID";
                DrpArticleClass1ID.DataBind();
                DrpArticleClass1ID.SelectedValue = ni.ArticleClass1ID.ToString();

                DrpArticleClass2ID.DataSource = WebClass.GetArticleClass2sEntityList(0, "ArticleClass1ID=" + DrpArticleClass1ID.SelectedValue, "");
                DrpArticleClass2ID.DataTextField = "ArticleClass2Name";
                DrpArticleClass2ID.DataValueField = "ArticleClass2ID";
                DrpArticleClass2ID.DataBind();

                TxtTitle.Text = ni.Title;
                TxtAddDate.Text = ni.AddDate.ToString();
                TxtHits.Text = ni.Hits.ToString();
                TxtShowLevel.Text = ni.ShowLevel.ToString();
                TxtUrl.Text = ni.Url;
                DrpArticleClass2ID.SelectedValue = ni.ArticleClass2ID.ToString();
                DrpIsUrl.SelectedValue = ni.IsUrl.ToString();

                myEditor.InnerText  = ni.Content;
                if (ni.IsUrl == 1)
                {
                    PanelContent.Visible = false;
                    PanelUrl.Visible = true;
                    TxtContent.Text = ni.Content;
                }
                else
                {
                    PanelContent.Visible = true;
                    PanelUrl.Visible = false;
                }


                if (ni.Pic.Trim().Length > 0)
                {
                    LtPic.Text = "<img src=" + ni.Pic + " width=300 />";
                }

                btnEdit.Attributes.Add("onclick", "return getContent();");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strTitle = TxtTitle.Text.Trim();
            string strArticleClass1ID = DrpArticleClass1ID.SelectedValue;
            string strArticleClass2ID = DrpArticleClass2ID.SelectedValue;
            string strAddDate = TxtAddDate.Text;
            string strContent = myEditor.InnerText;
            string strIsUrl = DrpIsUrl.SelectedValue;
            string strUrl = TxtUrl.Text.Trim();
            string strShowLevel = TxtShowLevel.Text.Trim();
            string strHits = TxtHits.Text.Trim();
            string strJianJie = TxtContent.Text;
            if (strArticleClass2ID == "")
            {
                strArticleClass2ID = "0";
            }
            ArticlesEntity ni = WebClass.GetArticlesEntity(ArticleID);

            #region 上传图片
            if (FileUpload1.FileName.Trim().Length > 0)
            {
                string strLocalPath = Server.MapPath("/");
                string strPath = UploadPath + MuLu + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";

                try
                {
                    DirectoryInfo director = new DirectoryInfo(strLocalPath + strPath.Replace("/", "\\"));
                    if (!director.Exists) //如果不存在就创建该文件夹
                    {
                        director.Create();
                    }
                }
                catch
                {
                }


                string fileext = ".jpg";
                string FileName = FileUpload1.FileName;
                if (FileName.LastIndexOf('.') < 0)
                {
                    try
                    {
                        fileext = "." + FileName.Substring(FileName.Length - 3, 3);
                    }
                    catch
                    {
                        fileext = ".jpg";
                    }
                }
                else
                {
                    fileext = FileName.Substring(FileName.LastIndexOf("."), FileName.Length - FileName.LastIndexOf("."));
                }

                string minFileName = CommonClass.GenRandPrefixName() + fileext.ToLower();
                FileName = strPath + minFileName;
                string sFileName = strPath + "s" + minFileName;

                int filelen = FileUpload1.PostedFile.ContentLength;
                if (filelen > 80 * 1024)       //自动缩小
                {

                    if (CheckBox1.Checked)
                        CommonClass.MakeThumbnail(FileUpload1.PostedFile, strLocalPath + FileName, 800, 600, "H", fileext, false, "", "#ff6600");
                    else
                        FileUpload1.SaveAs(strLocalPath + FileName);
                }
                else
                {
                    FileUpload1.SaveAs(strLocalPath + FileName);
                }

                CommonClass.MakeThumbnail(FileUpload1.PostedFile, strLocalPath + sFileName, 240, 180, "H", fileext, false, "", "#ff6600");


                ni.sPic = FileName;
                ni.Pic = FileName;

            }

            #endregion

            ni.AddDate = Convert.ToDateTime(strAddDate);
            ni.Title = strTitle;
            ni.Hits = Convert.ToInt32(strHits);
            ni.IsUrl = Convert.ToInt32(strIsUrl);
            ni.Url = strUrl;
            ni.ArticleClass1ID = Convert.ToInt32(strArticleClass1ID);
            ni.ArticleClass2ID = Convert.ToInt32(strArticleClass2ID);
            ni.Content = strContent;
            ni.ShowLevel = Convert.ToInt32(strShowLevel);
            ni.AdminID = Convert.ToInt32(Session["AdminID"].ToString());

            if (ni.IsUrl == 1)
            {
                ni.Content = strJianJie;
            }


            WebClass.UpdateArticlesEntity(ni);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript>alert('修改信息成功！！')</script>");

        }

        protected void DrpIsUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpIsUrl.SelectedValue == "1")
            {
                PanelContent.Visible = false;
                PanelUrl.Visible = true;
            }
            else
            {
                PanelContent.Visible = true;
                PanelUrl.Visible = false;
            }
        }

        protected void DrpArticleClass1ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrpArticleClass2ID.DataSource = WebClass.GetArticleClass2sEntityList(0, "ArticleClass1ID=" + DrpArticleClass1ID.SelectedValue, "");
            DrpArticleClass2ID.DataTextField = "ArticleClass2Name";
            DrpArticleClass2ID.DataValueField = "ArticleClass2ID";
            DrpArticleClass2ID.DataBind();
        }
    }
}
