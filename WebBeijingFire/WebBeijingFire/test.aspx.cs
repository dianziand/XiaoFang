using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBeijingFire
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strTemp = TextBox1.Text.Trim();
            for (int i = 0; i < 100; i++)
            {
                TextBox2.Text += strTemp.Replace("{0}", i.ToString())+"\n\r";
            }
        }
    }
}