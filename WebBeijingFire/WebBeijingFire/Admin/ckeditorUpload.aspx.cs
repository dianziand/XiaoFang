using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebBeijingFire.Admin
{
    public partial class ckeditorUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Write("<script>window.top.location='AdminLogin.aspx';</script>");
                return;
            }
            HttpFileCollection files = Request.Files; // From中获取文件对象
            if (files.Count > 0)
            {
                string path = ""; //路径字符串
                Random rnd = new Random();
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i]; //得到文件对象
                    if (file.ContentLength > 0)
                    {
                        string fileName = file.FileName;
                        string extension = Path.GetExtension(fileName).ToLower();
                        int num = rnd.Next(5000, 10000); //文件名称
                        path = "/UserFiles/" + num.ToString() + extension;
                        if (extension != ".jpg" 
                            && extension != ".jpeg" 
                            && extension != ".gif" 
                            && extension != ".png" 
                            && extension != ".doc"
                            && extension != ".xls"
                            && extension != ".docx"
                            && extension != ".xlsx"
                            )
                        {
                            return;
                        }
                        file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path)); //保存文件。
                    }
                }
                //Response.Write(path); //返回文件存储后的路径，用于回显。
                string callback = Request["CKEditorFuncNum"];
                string reVal = "<script type=\"text/javascript\">";
                reVal += "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'" + path + "','');";
                reVal += "</script>";
                Response.Write(reVal);
            }
        }
    }
}