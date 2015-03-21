using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class ArticleClass2sDAL
    {
        #region  ArticleClass2s自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddArticleClass2sEntity(ArticleClass2sEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ArticleClass2s(");
            strSql.Append("ArticleClass2Name,ArticleClass1ID,ShowLevel,Words)");
            strSql.Append(" values (");
            strSql.Append("@ArticleClass2Name,@ArticleClass1ID,@ShowLevel,@Words)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass2Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Words", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ArticleClass2Name;
            parameters[1].Value = model.ArticleClass1ID;
            parameters[2].Value = model.ShowLevel;
            parameters[3].Value = model.Words;

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
        public static void UpdateArticleClass2sEntity(ArticleClass2sEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleClass2s set ");
            strSql.Append("ArticleClass2Name=@ArticleClass2Name,");
            strSql.Append("ArticleClass1ID=@ArticleClass1ID,");
            strSql.Append("ShowLevel=@ShowLevel,");
            strSql.Append("Words=@Words");
            strSql.Append(" where ArticleClass2ID=@ArticleClass2ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass2ID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass2Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Words", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ArticleClass2ID;
            parameters[1].Value = model.ArticleClass2Name;
            parameters[2].Value = model.ArticleClass1ID;
            parameters[3].Value = model.ShowLevel;
            parameters[4].Value = model.Words;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteArticleClass2sEntity(int ArticleClass2ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ArticleClass2s ");
            strSql.Append(" where ArticleClass2ID=@ArticleClass2ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass2ID", SqlDbType.Int,4)};
            parameters[0].Value = ArticleClass2ID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ArticleClass2sEntity GetArticleClass2sEntity(int ArticleClass2ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ArticleClass2ID,ArticleClass2Name,ArticleClass1ID,ShowLevel,Words from ArticleClass2s ");
            strSql.Append(" where ArticleClass2ID=@ArticleClass2ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleClass2ID", SqlDbType.Int,4)};
            parameters[0].Value = ArticleClass2ID;

            ArticleClass2sEntity model = new ArticleClass2sEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ArticleClass2ID"].ToString() != "")
                {
                    model.ArticleClass2ID = int.Parse(ds.Tables[0].Rows[0]["ArticleClass2ID"].ToString());
                }
                model.ArticleClass2Name = ds.Tables[0].Rows[0]["ArticleClass2Name"].ToString();
                if (ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString() != "")
                {
                    model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString());
                }
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

        #endregion  ArticleClass2s自动生成成员方法


        #region ArticleClass2s手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass2sEntity> GetArticleClass2sEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ArticleClass2ID,ArticleClass2Name,ArticleClass1ID,ShowLevel,Words from ArticleClass2s ");

            IList<ArticleClass2sEntity> modelList = new List<ArticleClass2sEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ArticleClass2sEntity model = new ArticleClass2sEntity();
                    if (ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString() != "")
                    {
                        model.ArticleClass2ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString());
                    }
                    model.ArticleClass2Name = ds.Tables[0].Rows[i]["ArticleClass2Name"].ToString();
                    if (ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString() != "")
                    {
                        model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
                    }
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


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass2sEntity> GetArticleClass2sEntityList(int Top, string strWhere, string filedOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("  ArticleClass2ID,ArticleClass2Name,ArticleClass1ID,ShowLevel,Words from ArticleClass2s ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            IList<ArticleClass2sEntity> modelList = new List<ArticleClass2sEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ArticleClass2sEntity model = new ArticleClass2sEntity();
                    if (ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString() != "")
                    {
                        model.ArticleClass2ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString());
                    }
                    model.ArticleClass2Name = ds.Tables[0].Rows[i]["ArticleClass2Name"].ToString();
                    if (ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString() != "")
                    {
                        model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
                    }
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


        #endregion ArticleClass2s手写方法
    }

}