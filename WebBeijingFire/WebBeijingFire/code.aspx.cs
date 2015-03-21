using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBeijingFire
{
    public partial class code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private string DealModel(string input)
        {
            string ReVal = input;
            int intStart = 0;
            int intEnd = 1;
            string strTemp1 = "", strTemp2 = "";
            while (intEnd > 0)
            {

                intEnd = input.IndexOf("\n", intStart);
                if (intEnd < 0) break;
                strTemp1 = input.Substring(intStart, intEnd - intStart);
                intStart = intEnd + 1;
                strTemp2 = strTemp1;


                if (strTemp1.IndexOf("private") > -1 && strTemp1.IndexOf(" int") > -1)
                {
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }

                if (strTemp1.IndexOf("private") > -1 && strTemp1.IndexOf("long") > -1)
                {
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }

                if (strTemp1.IndexOf("private") > -1 && strTemp1.IndexOf("decimal") > -1)
                {
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }

                if (strTemp1.IndexOf("int?") > -1)
                {
                    strTemp1 = strTemp1.Replace("int?", "int");
                    //if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }
                if (strTemp1.IndexOf("DateTime?") > -1)
                {
                    strTemp1 = strTemp1.Replace("DateTime?", "DateTime");
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = DateTime.Now;");

                }
                if (strTemp1.IndexOf("long?") > -1)
                {
                    strTemp1 = strTemp1.Replace("long?", "long");
                    //if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }

                if (strTemp1.IndexOf("private bool") > -1)
                {
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = true;");
                }

                if (strTemp1.IndexOf("decimal?") > -1)
                {
                    strTemp1 = strTemp1.Replace("decimal?", "decimal");
                    //if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = 0;");
                }

                if (strTemp1.IndexOf("private") > -1 && strTemp1.IndexOf("string") > -1)
                {
                    if (strTemp1.IndexOf(";") > 0) strTemp1 = strTemp1.Replace(";", " = \"\";");
                }

                ReVal = ReVal.Replace(strTemp2, strTemp1);
            }
            //处理代码
            return ReVal;
        }



        private string DealSQL(string input)
        {
            string ReVal = input;



            ReVal = ReVal.Replace("object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);", "object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);");
            ReVal = ReVal.Replace("DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);", "SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);");
            ReVal = ReVal.Replace("DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);", "DataSet ds=SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);");




            int intStart = 0;
            int intEnd = 1;
            string strTemp1 = "", strTemp2 = "";
            string ClassName1 = "";
            string Namespace = "";
            while (intEnd > 0)
            {
                intEnd = input.IndexOf("\n", intStart);
                if (intEnd < 0) break;
                strTemp1 = input.Substring(intStart, intEnd - intStart);
                intStart = intEnd + 1;
                strTemp2 = strTemp1;

                if (strTemp1.IndexOf("Add(") > -1 && strTemp1.IndexOf(".Model.") > -1)
                {
                    int intS = 0, intE = 0;
                    intS = strTemp1.IndexOf("Add(");
                    intE = strTemp1.IndexOf(".Model.");
                    if (intS > 0 && intE > 0)
                    {
                        Namespace = strTemp1.Substring(intS + 4, intE - intS - 4);
                        Namespace += ".Model.";
                    }
                }


                if (strTemp1.IndexOf("public ") > -1 && strTemp1.IndexOf("(") > -1 && strTemp1.IndexOf(")") > -1 && strTemp1.IndexOf("()") == -1)
                {
                    strTemp1 = strTemp1.Replace("public ", "public static ");
                }

                if (strTemp1.IndexOf(" model)") > -1)
                {
                    int intS = 0, intE = 0;
                    string ClassName = "";
                    intS = strTemp1.IndexOf(".Model.");
                    intE = strTemp1.IndexOf(" model)");
                    if (intS > 0 && intE > 0) ClassName = strTemp1.Substring(intS + 7, intE - intS - 7);
                    strTemp1 = strTemp1.Replace("(", ClassName + "Info(");
                    ClassName1 = ClassName;
                }

                if (strTemp1.IndexOf("GetModel(") > -1)
                {
                    int intS = 0, intE = 0;
                    string ClassName = "";
                    intS = strTemp1.IndexOf(".Model.");
                    intE = strTemp1.IndexOf(" GetModel");
                    if (intS > 0 && intE > 0) ClassName = strTemp1.Substring(intS + 7, intE - intS - 7);
                    strTemp1 = strTemp1.Replace("GetModel(", "Get" + ClassName + "Info(");
                    ClassName1 = ClassName;
                }

                if (strTemp1.IndexOf("Delete(") > -1 && strTemp1.IndexOf("void") > -1)
                {
                    strTemp1 = strTemp1.Replace("Delete(", "Delete" + ClassName1 + "Info(");
                }



                if (strTemp1.IndexOf("dal.Add(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Add(", "dal.Add" + ClassName1 + "Info(");
                }


                if (strTemp1.IndexOf("dal.Update(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Update(", "dal.Update" + ClassName1 + "Info(");
                }

                if (strTemp1.IndexOf("dal.Delete(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Delete(", "dal.Delete" + ClassName1 + "Info(");
                }


                ReVal = ReVal.Replace(strTemp2, strTemp1);
            }

            if (Namespace.Length > 0)
                ReVal = ReVal.Replace(Namespace + ClassName1, ClassName1 + "Info");

            ReVal = ReVal.Replace("成员方法", ClassName1 + "自动生成成员方法");
            //处理代码
            return ReVal;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string strInput = TxtInput.Text;
            string strOutput = "";

            strOutput = DealModel(strInput);//处理Model

            strOutput = DealSQL(strOutput);//处理Model

            TxtOutput.Text = strOutput;
        }
    }
}