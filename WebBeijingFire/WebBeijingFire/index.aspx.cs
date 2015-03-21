using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;

namespace WebBeijingFire
{
    public partial class index : System.Web.UI.Page
    {
        public string pics = "", links = "", texts = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //通知公告
                RepeaterTZGG.DataSource = WebClass.GetArticlesListDataView(8, 15, 1, 1, "1");
                RepeaterTZGG.DataBind();

                //北京消防新闻
                RepeaterBJXFXW.DataSource = WebClass.GetArticlesListDataView(8, 22, 2, 7, "1");
                RepeaterBJXFXW.DataBind();

                //国内消防新闻
                IList<ArticlesEntity> list = WebClass.GetArticlesEntityList(4, 13, 2, 8, "1");
                int i = 0;
                foreach (var ae in WebClass.GetArticlesEntityList(8, 23, 2, 8, "1"))
                {
                    i++;
                    if (i > 4)
                    {
                        list.Add(ae);
                    }
                }
                RepeaterGNXFXW.DataSource = list;
                RepeaterGNXFXW.DataBind();
                list = WebClass.GetArticlesEntityList(1, " ArticleClass2ID=8  and len(sPic)>0 ", " ShowLevel asc,AddDate desc ");
                if (list.Count > 0)
                {
                    literalGNXFXWPIC.Text = "<a href="+list[0].Url+" target=\"_blank\"><img src=\"" + list[0].sPic + "\" width=\"117\" height=\"99\" border=\"0\" /></a>";
                }
                else
                {
                    literalGNXFXWPIC.Text = "<img src=\"images/ga6.jpg\" width=\"117\" height=\"99\" />";
                }

                //国际消防新闻

                list = WebClass.GetArticlesEntityList(4, 11, 2, 9, "1");
                i = 0;
                foreach (var ae in WebClass.GetArticlesEntityList(8, 20, 2, 9, "1"))
                {
                    i++;
                    if (i > 4)
                    {
                        list.Add(ae);
                    }
                }
                RepeaterGJXFXW.DataSource = list;
                RepeaterGJXFXW.DataBind(); 
                list = WebClass.GetArticlesEntityList(1, " ArticleClass2ID=9  and len(sPic)>0 ", " ShowLevel asc,AddDate desc ");
                if (list.Count > 0)
                {
                    literalGJXFXWPIC.Text = "<a href=" + list[0].Url + " target=\"_blank\"><img src=\"" + list[0].sPic + "\" width=\"117\" height=\"99\" border=\"0\"  /></a>";
                }
                else
                {
                    literalGJXFXWPIC.Text = "<img src=\"images/ga6.jpg\" width=\"117\" height=\"99\" />";
                }

                //协会动态
                RepeaterXHDT.DataSource = WebClass.GetArticlesListDataView(8, 15, 1, 3, "1");
                RepeaterXHDT.DataBind();

                //常务理事单位
                RepeaterCWLSDW.DataSource = WebClass.GetArticlesListDataView(7, 15, 1, 4, "1");
                RepeaterCWLSDW.DataBind();

                //理事单位
                RepeaterLSDW.DataSource = WebClass.GetArticlesListDataView(7, 15, 1, 5, "1");
                RepeaterLSDW.DataBind();

                //会员单位
                RepeaterHYDW.DataSource = WebClass.GetArticlesListDataView(6, 15, 1, 6, "1");
                RepeaterHYDW.DataBind();

                //学术园地
                RepeaterXSYD.DataSource = WebClass.GetArticlesListDataView(8, 22, 4, 0, "1");
                RepeaterXSYD.DataBind();

                //消防科普
                RepeaterXFKP.DataSource = WebClass.GetArticlesListDataView(8, 22, 5, 0, "1");
                RepeaterXFKP.DataBind();

                //产品推荐
                RepeaterCPTJ.DataSource = WebClass.GetArticlesEntityList(8, " ArticleClass1ID=6 and len(sPic)>0 ", " ShowLevel asc,AddDate desc ");
                RepeaterCPTJ.DataBind();

                //幻灯片
                list = WebClass.GetArticlesEntityList(8, " ArticleClass1ID<>6 and  ArticleClass1ID<>7 and len(sPic)>0 ", " ShowLevel asc,AddDate desc ");
                foreach(ArticlesEntity classEntity in list)
                {
                    pics += classEntity.sPic + "|";
                    links += classEntity.Url + "|";
                    texts += classEntity.Title + "|";
                }
                pics = pics.TrimEnd('|').Replace("'","");
                links = links.TrimEnd('|').Replace("'", "");
                texts = texts.TrimEnd('|').Replace("'", "");
            }
        }
    }
}