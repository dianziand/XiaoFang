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
    public partial class TopBottom : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                literalTime.Text = DateTime.Now.ToShortDateString();
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        literalTime.Text += " 星期日"; break;
                    case DayOfWeek.Monday:
                        literalTime.Text += " 星期一"; break;
                    case DayOfWeek.Thursday:
                        literalTime.Text += " 星期四"; break;
                    case DayOfWeek.Wednesday:
                        literalTime.Text += " 星期三"; break;
                    case DayOfWeek.Tuesday:
                        literalTime.Text += " 星期二"; break;
                    case DayOfWeek.Friday:
                        literalTime.Text += " 星期五"; break;
                    case DayOfWeek.Saturday:
                        literalTime.Text += " 星期六"; break;
                    default:
                        literalTime.Text += "";
                        break;
                }
                IList<ArticlesEntity> list = WebClass.GetArticlesEntityList(18, " ArticleClass1ID=7  and len(sPic)>0 ", " ShowLevel asc,AddDate desc ");
                RepeaterYQLJPic.DataSource = list;
                RepeaterYQLJPic.DataBind();

                list = WebClass.GetArticlesEntityList(18, " ArticleClass1ID=7  and len(sPic)=0 ", " ShowLevel asc,AddDate desc ");
                RepeaterYQLJ.DataSource = list;
                RepeaterYQLJ.DataBind();
                
            }
        }
    }
}