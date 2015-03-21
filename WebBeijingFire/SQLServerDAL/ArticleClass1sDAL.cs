using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class ArticleClass1sDAL
    {
        #region  ArticleClass1s自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddArticleClass1sEntity(ArticleClass1sEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ArticleClass1s(");
            strSql.Append("ArticleClass1Name,ShowLevel,Words)");
            strSql.Append(" values (");
            strSql.Append("@ArticleClass1Name,@ShowLevel,@Words)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass1Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Words", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ArticleClass1Name;
            parameters[1].Value = model.ShowLevel;
            parameters[2].Value = model.Words;

            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateArticleClass1sEntity(ArticleClass1sEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleClass1s set ");
            strSql.Append("ArticleClass1Name=@ArticleClass1Name,");
            strSql.Append("ShowLevel=@ShowLevel,");
            strSql.Append("Words=@Words");
            strSql.Append(" where ArticleClass1ID=@ArticleClass1ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass1Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Words", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ArticleClass1ID;
            parameters[1].Value = model.ArticleClass1Name;
            parameters[2].Value = model.ShowLevel;
            parameters[3].Value = model.Words;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteArticleClass1sEntity(int ArticleClass1ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ArticleClass1s ");
            strSql.Append(" where ArticleClass1ID=@ArticleClass1ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4)};
            parameters[0].Value = ArticleClass1ID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ArticleClass1sEntity GetArticleClass1sEntity(int ArticleClass1ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ArticleClass1ID,ArticleClass1Name,ShowLevel,Words from ArticleClass1s ");
            strSql.Append(" where ArticleClass1ID=@ArticleClass1ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4)};
            parameters[0].Value = ArticleClass1ID;

            ArticleClass1sEntity model = new ArticleClass1sEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString() != "")
                {
                    model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString());
                }
                model.ArticleClass1Name = ds.Tables[0].Rows[0]["ArticleClass1Name"].ToString();
                if (ds.Tables[0].Rows[0]["ShowLevel"].ToString() != "")
                {
                    model.ShowLevel = int.Parse(ds.Tables[0].Rows[0]["ShowLevel"].ToString());
                }
                model.Words = ds.Tables[0].Rows[0]["Words"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  ArticleClass1s自动生成成员方法


        #region ArticleClass1s手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass1sEntity> GetArticleClass1sEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ArticleClass1ID,ArticleClass1Name,ShowLevel,Words from ArticleClass1s ");

            IList<ArticleClass1sEntity> modelList = new List<ArticleClass1sEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    ArticleClass1sEntity model = new ArticleClass1sEntity();
                    if (ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString() != "")
                    {
                        model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
                    }
                    model.ArticleClass1Name = ds.Tables[0].Rows[i]["ArticleClass1Name"].ToString();
                    if (ds.Tables[0].Rows[i]["ShowLevel"].ToString() != "")
                    {
                        model.ShowLevel = int.Parse(ds.Tables[0].Rows[i]["ShowLevel"].ToString());
                    }
                    model.Words = ds.Tables[0].Rows[i]["Words"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion ArticleClass1s手写方法
    }
}
