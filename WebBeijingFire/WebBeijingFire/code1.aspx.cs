using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace WebBeijingFire
{
    public partial class code1 : System.Web.UI.Page
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


        private string AddGetEntityList(string input)
        {
            string ReVal = input;

            int intStart = -1;
            int intEnd = -1;

            intStart = input.IndexOf("/// 得到一个对象实体");
            if (intStart < 0) return input;
            intEnd = input.IndexOf("#endregion  成员方法");
            if (intStart > -1 && intEnd > intStart)
                ReVal = input.Substring(intStart, intEnd - intStart);
            ReVal = @"/// <summary>BeginAAA
		" + ReVal;
            input = input.Insert(intEnd, ReVal);
            return input;
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
                    strTemp1 = strTemp1.Replace("(", ClassName + "Entity(");
                    ClassName1 = ClassName;
                }

                if (strTemp1.IndexOf("GetModel(") > -1)
                {
                    int intS = 0, intE = 0;
                    string ClassName = "";
                    intS = strTemp1.IndexOf(".Model.");
                    intE = strTemp1.IndexOf(" GetModel");
                    if (intS > 0 && intE > 0) ClassName = strTemp1.Substring(intS + 7, intE - intS - 7);
                    strTemp1 = strTemp1.Replace("GetModel(", "Get" + ClassName + "Entity(");
                    ClassName1 = ClassName;
                }

                if (strTemp1.IndexOf("Delete(") > -1 && strTemp1.IndexOf("void") > -1)
                {
                    strTemp1 = strTemp1.Replace("Delete(", "Delete" + ClassName1 + "Entity(");
                }



                if (strTemp1.IndexOf("dal.Add(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Add(", "dal.Add" + ClassName1 + "Entity(");
                }


                if (strTemp1.IndexOf("dal.Update(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Update(", "dal.Update" + ClassName1 + "Info(");
                }

                if (strTemp1.IndexOf("dal.Delete(") > -1)
                {
                    strTemp1 = strTemp1.Replace("dal.Delete(", "dal.Delete" + ClassName1 + "Entity(");
                }


                ReVal = ReVal.Replace(strTemp2, strTemp1);
            }

            if (Namespace.Length > 0)
                ReVal = ReVal.Replace(Namespace + ClassName1, ClassName1 + "Entity");

            ReVal = ReVal.Replace("成员方法", ClassName1 + "自动生成成员方法");
            //处理代码
            return ReVal;
        }


        private string DealEntityList(string input)
        {
            string ReVal = "";
            string strTemp = "";
            string strTemp2 = "";
            string strTemp3 = "";

            int intStart = input.IndexOf("BeginAAA");
            if (intStart < 0) return input;
            int intEnd = input.IndexOf("#endregion  ");
            ReVal = input.Substring(intStart, intEnd - intStart);
            strTemp3 = ReVal;

            string EntityName = WebClass.GetNeiRong(ReVal, "public static ", " Get");
            strTemp = WebClass.GetNeiRong(ReVal, "public static ", ")");

            ReVal = ReVal.Replace("public static " + strTemp + ")", "public static IList<" + EntityName + "> Get" + EntityName + "List(int Top, string strWhere, string filedOrder)");


            strTemp = "\");\n";
            strTemp += "            if (Top > 0)\n";
            strTemp += "            {\n";
            strTemp += "                strSql.Append(\" top \" + Top.ToString());\n";
            strTemp += "            }\n";
            strTemp += "            strSql.Append(\"";

            ReVal = ReVal.Replace("top 1", strTemp);

            strTemp = WebClass.GetNeiRong(ReVal, "strSql.Append(\" where", "DataSet ds=SqlHelper");

            strTemp2 = "\n";
            strTemp2 += "            if (strWhere.Trim() != \"\")\n";
            strTemp2 += "            {\n";
            strTemp2 += "                strSql.Append(\" where \" + strWhere);\n";
            strTemp2 += "            }\n";
            strTemp2 += "            if (filedOrder.Trim() != \"\")\n";
            strTemp2 += "            {\n";
            strTemp2 += "                strSql.Append(\" order by \" + filedOrder);\n";
            strTemp2 += "            }\n";
            strTemp2 += "\n";
            strTemp2 += "            IList<" + EntityName + "> modelList = new List<" + EntityName + ">();\n";
            strTemp2 += "\n";

            ReVal = ReVal.Replace("strSql.Append(\" where" + strTemp, strTemp2);


            ReVal = ReVal.Replace("if(ds.Tables[0].Rows.Count>0)", "for (int i = 0; i < ds.Tables[0].Rows.Count; i++)");
            intStart = ReVal.IndexOf("ds.Tables[0].Rows.Count");
            intEnd = ReVal.IndexOf("{", intStart);
            if (intEnd > 0) intEnd++;
            strTemp2 = "\n";
            strTemp2 += "                    " + EntityName + " model = new " + EntityName + "();";
            ReVal = ReVal.Insert(intEnd, strTemp2);

            ReVal = ReVal.Replace("Rows[0]", "Rows[i]");


            strTemp = WebClass.GetNeiRong(ReVal, "return model;", "return null;");
            strTemp = "return model;" + strTemp + "return null;";
            strTemp2 = "modelList.Add(model);";

            ReVal = ReVal.Replace(strTemp, strTemp2);

            intStart = ReVal.LastIndexOf("}");
            ReVal = ReVal.Insert(intStart, "    return modelList;\n        ");
            ReVal = ReVal.Replace("BeginAAA", "");

            ReVal = ReVal.Replace("CommandType.Text, parameters);", "CommandType.Text, null);");
            ReVal = ReVal.Replace("得到一个对象实体", "得到符合要求的对象实体列表");
            ReVal = input.Replace(strTemp3, ReVal);
            return ReVal;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            string strInput = TxtInput.Text;
            string strOutput = "";


            strOutput = AddGetEntityList(strInput);//增加一个EntityList

            strOutput = DealModel(strOutput);//处理Model

            strOutput = DealSQL(strOutput);//处理Model


            strOutput = DealEntityList(strOutput);//处理EntityList

            TxtOutput.Text = strOutput;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string strInput = TxtInput.Text;
            string strOutput = "";


            strOutput = AddGetEntityList(strInput);//增加一个EntityList

            strOutput = DealModel(strOutput);//处理Model

            strOutput = DealSQL(strOutput);//处理Model


            strOutput = DealEntityList(strOutput);//处理EntityList

            strOutput = GetBLL(strOutput);//生成BLL


            TxtOutput.Text = strOutput;

        }

        private string GetBLL(string input)
        {
            int intStart = 0;
            int intEnd = 1;
            int len = 0;
            string strTemp = "";
            string strTemp2 = "";
            string TableName = WebClass.GetNeiRong(input, "into ", "(\")");
            string reVal = "		#region  " + TableName + "自动生成成员方法\n";
            while (intEnd > -1)
            {
                intStart = input.IndexOf("/// <summary>", intEnd);
                if (intStart < 0) break;
                intEnd = input.IndexOf(")", intStart);
                if (intEnd < 0) break;
                strTemp = input.Substring(intStart, intEnd - intStart + 1);
                reVal += strTemp + "\n{\n";
                len = strTemp.IndexOf("public");
                strTemp2 = strTemp.Substring(len, strTemp.Length - len);//获取函数头一行
                strTemp2 = strTemp2.Replace("public static ", "");
                strTemp2 = strTemp2.Replace(strTemp2.Split(' ')[0] + " ", "");
                strTemp2 = strTemp2.Replace(TableName + "Entity ", "");
                strTemp2 = strTemp2.Replace("int ", "");
                strTemp2 = strTemp2.Replace("string ", "");
                if (strTemp.IndexOf("void") > 0)
                {
                    reVal += "		    " + TableName + "Data." + strTemp2 + ";";
                }
                else
                {
                    reVal += "		    return " + TableName + "Data." + strTemp2 + ";";
                }

                reVal += "\n}\n\n";
            }
            reVal += "		#endregion  " + TableName + "自动生成成员方法";
            return reVal;
        }
    }
}