using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;

namespace Common
{
    public static class CommonClass
    {
        #region 生成缩略图

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="UpFile">图片文件流</param>
        /// <param name="thumbnailPath">生成的图片路径（绝对路径）</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="mode">生成模式 "HW":指定高宽缩放（可能变形）"W":指定宽，高按比例  "H":指定高，宽按比例  "Cut":指定高宽裁减（不变形） </param>
        /// <param name="imgformat">图片格式，主要指图片的后缀名</param>
        /// <param name="ShowMyWebSite">是否在图片上显示网址（除了网址外，可以是任何文字）</param>
        /// <param name="MyWebSite">要显示的网址</param>
        /// <param name="_mycolor">要显示的文字颜色</param>
        public static void MakeThumbnail(HttpPostedFile UpFile, string thumbnailPath, int width, int height, string mode, string imgformat, bool ShowMyWebSite, string MyWebSite, string _mycolor)
        {
            //读取图片
            int FileLength = UpFile.ContentLength;

            Byte[] FileByteArray = new Byte[FileLength];
            Stream StreamObject = UpFile.InputStream;
            StreamObject.Read(FileByteArray, 0, FileLength);
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(StreamObject);


            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if ((Math.Abs(ow - width) < 20) && (Math.Abs(oh - height) < 20))
            {
                UpFile.SaveAs(thumbnailPath);
                return;
            }

            if (originalImage.Width < width || originalImage.Height < height)
            {
                width = originalImage.Width;
                height = originalImage.Height;
            }
            else
            {
                if (ow < oh)
                {
                    int itemp = height;
                    height = width;
                    width = itemp;
                    mode = "H";
                }
            }
            int towidth = width;
            int toheight = height;


            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）               
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）               
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = null;
            //bitmap = new System.Drawing.Bitmap(towidth, toheight+25);
            if (towidth > 310 && ShowMyWebSite)
            {
                bitmap = new System.Drawing.Bitmap(towidth, toheight + 28);
            }
            else
            {
                bitmap = new System.Drawing.Bitmap(towidth, toheight);
            }

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //清空画布并以透明背景色填充
            //g.Clear(Color.Transparent);
            g.Clear(Color.White);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);


            if (ShowMyWebSite && towidth > 310) //宽度必须大于310才加网址
            {
                ColorConverter wcc = new WebColorConverter();
                Color mycolor;
                try
                {
                    mycolor = (Color)wcc.ConvertFromString(_mycolor);
                }
                catch
                {
                    mycolor = (Color)wcc.ConvertFromString("#000000");
                }

                Brush b = new SolidBrush(mycolor);



                g.DrawString(MyWebSite, new Font("黑体", 16, FontStyle.Regular), b, new Point(towidth - 270, toheight));
            }

            try
            {
                //保存图片格式（jpg,gif,bmp,png）
                switch (imgformat.ToLower())
                {
                    case ".jpg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case ".bmp":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".png":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

            }
            catch (System.Exception e)
            {
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion



        /// <summary>
        /// 得到WEB.CONFIG的整型值,如无则指定缺省
        /// </summary>
        /// <param name="strKey">健值</param>
        /// <param name="nDefaultValue">默认值</param>
        /// <returns></returns>
        public static string GetWebConfig(string strKey, string nDefaultValue)
        {
            string nConfigValue = "";
            if (ConfigurationSettings.AppSettings[strKey] == null)
                nConfigValue = nDefaultValue;
            else
                nConfigValue = Convert.ToString(ConfigurationSettings.AppSettings[strKey]);
            return nConfigValue;
        }


        public static void DelFile(string FilePathandName)
        {
            try
            {
                FileInfo file = new FileInfo(FilePathandName);
                if (file.Exists) file.Delete();
            }
            catch
            {
            }
        }


        public static int GetWebConfig(string strKey, int nDefaultValue)
        {
            int nConfigValue = 100;
            if (ConfigurationSettings.AppSettings[strKey] == null)
                nConfigValue = nDefaultValue;
            else
                nConfigValue = Convert.ToInt32(ConfigurationSettings.AppSettings[strKey].ToString());
            return nConfigValue;
        }


        /// <summary>
        /// 生成HTML文件
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="strHtml">HTML</param>
        public static void WriteHtmlFile(string strFileName, string strHtml)
        {
            byte[] bHtml = System.Text.Encoding.Default.GetBytes(strHtml);
            FileStream fs = new FileStream(strFileName, FileMode.Create);
            foreach (byte b in bHtml)
                fs.WriteByte(b);
            fs.Close();
        }
        /// <summary>
        /// 根据搜索条件dataRow 转换成dataTable
        /// </summary>
        /// <param name="dt">待搜索DataTable</param>
        /// <param name="condition">条件</param>
        /// <returns>DataTable 搜索结果</returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable ndt = new DataTable();
            ndt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i <= dr.Length - 1; i++)
            {
                ndt.ImportRow((DataRow)dr[i]);
            }
            return ndt;
        }

        //获取查询结果
        public static string GetHtmlContent(string Url)
        {
            string strHtmlContent = "";
            try
            {
                //声明一个HttpWebRequest请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //连接超时时间
                request.Timeout = 200000;
                request.Headers.Set("Pragma", "no-cache");


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamHtmlCode = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("gb2312");
                StreamReader streamReader = new StreamReader(streamHtmlCode, encoding);
                strHtmlContent = streamReader.ReadToEnd();
            }
            catch (System.Net.WebException we)
            {

                if (we.Message.IndexOf("(500) 内部服务器错误") > -1) return "";
                if (we.Message.IndexOf("(503) 服务器不可用") > -1) return "";
                System.Web.HttpContext.Current.Response.Write(we.ToString());
                System.Web.HttpContext.Current.Response.End();
            }
            return strHtmlContent;
        }



        //获取查询结果
        public static string GetHtmlContent(string Url, string Referer)
        {
            string strHtmlContent = "";
            try
            {
                //声明一个HttpWebRequest请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);


                request.Referer = Referer;
                request.Method = "get";
                request.Headers.Add(Referer);

                //连接超时时间
                request.Timeout = 200000;
                request.Headers.Set("Pragma", "no-cache");


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamHtmlCode = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("gb2312");
                StreamReader streamReader = new StreamReader(streamHtmlCode, encoding);
                strHtmlContent = streamReader.ReadToEnd();
            }
            catch (System.Net.WebException we)
            {

                if (we.Message.IndexOf("(500) 内部服务器错误") > -1) return "";
                if (we.Message.IndexOf("(503) 服务器不可用") > -1) return "";
                System.Web.HttpContext.Current.Response.Write(we.ToString());
                System.Web.HttpContext.Current.Response.End();
            }
            return strHtmlContent;
        }


        //获取查询结果
        public static string GetHtmlContentUTF8(string Url, string Referer)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("Referer", Referer);
                wc.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA)");
                wc.Encoding = Encoding.GetEncoding("utf-8");
                return wc.DownloadString(Url);
            }
            catch (System.Net.WebException we)
            {
                if (we.Message.IndexOf("(500) 内部服务器错误") > -1) return "";
                if (we.Message.IndexOf("(503) 服务器不可用") > -1) return "";
                if (we.Message.IndexOf("(404)") > -1) return "";
                System.Web.HttpContext.Current.Response.Write(we.ToString());
                System.Web.HttpContext.Current.Response.End();
                return "";
            }
        }



        //获取查询结果
        public static string GetHtmlContentUTF8(string Url)
        {
            string strHtmlContent = "";
            try
            {
                //声明一个HttpWebRequest请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //连接超时时间
                request.Timeout = 200000;
                request.Headers.Set("Pragma", "no-cache");


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamHtmlCode = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(streamHtmlCode, encoding);
                strHtmlContent = streamReader.ReadToEnd();
            }
            catch (System.Net.WebException we)
            {
                return "";
                return "出错啦aguan";
            }
            return strHtmlContent;
        }

        /// <summary>
        /// 按时间随机生成图片主文件名
        /// </summary>
        /// <returns></returns>
        public static string GenRandPrefixName()
        {
            Random rnd = new Random();
            string imageName = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + rnd.Next(10000, 100000).ToString();
            return imageName;
        }


        /// <summary>全角转半角   
        /// 半角空格32,全角空格12288   
        /// 其他字符半角33~126,其他字符全角65281~65374,相差65248   
        /// </summary>   
        /// <param name="input"></param>   
        /// <returns></returns>   
        public static string SBCToDBC(string input)
        {
            char[] cc = input.ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] == 12288)
                {
                    // 表示空格   
                    cc[i] = (char)32;
                    continue;
                }
                if (cc[i] > 65280 && cc[i] < 65375)
                {
                    cc[i] = (char)(cc[i] - 65248);
                }

            }
            return new string(cc);
        }


        //检查文件格式是否非法
        public static bool IsValidFileType(string FileName)
        {
            string UploadFileTypes = System.Configuration.ConfigurationSettings.AppSettings["UploadFileTypes"];
            string[] AcceptedFileTypes = UploadFileTypes.Split('|');    //new string[] { "zip", "rar", "doc", "xls", "pdf", "ppt", "pps", "jpg", "jpeg", "gif", "bmp", "png", "txt" };//可以接收的附件格式


            string ext = FileName.Substring(FileName.LastIndexOf(".") + 1, FileName.Length - FileName.LastIndexOf(".") - 1).ToLower();
            for (int i = 0; i < AcceptedFileTypes.Length; i++)
            {
                if (ext == AcceptedFileTypes[i])
                {
                    return true;

                }
            }
            return false;
        }

        //验证电子邮件
        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 先弹出提示框,然后重定向
        /// </summary>
        /// <param name="content">要提示的内容</param>
        /// <param name="redirectUrl">要重定向的页面</param>
        public static void AlertAndRedirect(string content, string redirectUrl, System.Web.HttpResponse Response)
        {
            string mess;

            mess = "<script language='javascript'>alert('" + content + "');" + "location.href('" + redirectUrl + "');" + "</script>";

            Response.Write(mess);
        }

        public static void AlertJs(string strMessage, System.Web.HttpResponse Response, string mailUrl)
        {
            Response.Write("<script>if(confirm('" + strMessage + "')) {window.top.location='" + mailUrl + "'; } else{window.top.location='login.aspx';}</script>");
        }

        public static string GetRandomNumber(int length)
        {
            string chtamp = null;
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            string[] ca = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i < length; i++)
            {
                chtamp += ca[ra.Next(36)];
            }
            return chtamp;
        }

        /// <summary>
        /// 查看是否由数字组成
        /// </summary>
        /// <param name="checkstr">要检查的值</param>
        /// <returns>表示验证是否成功</returns>
        public static bool IsNum(string checkstr)
        {
            if (String.IsNullOrEmpty(checkstr)) checkstr = "";
            string substr = "";
            int ss = -1;
            if (checkstr.Length == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < checkstr.Length; i++)
                {
                    substr = checkstr.Substring(i, 1);
                    ss = "0123456789.".IndexOf(substr);
                    if (ss == -1)
                    {
                        return false;
                    }

                }
            }
            return true;
        }


        /// <summary>
        /// 根据SN返回公司类型
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static string GetTypeOfCompanyBySN(string SN)
        {
            string reVal = "";
            if (SN.Trim().Length == 0) return "";
            reVal = SN.Substring(2, 1);
            return reVal;
        }
    }
}
