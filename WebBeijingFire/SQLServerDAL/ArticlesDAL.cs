using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class ArticlesDAL
    {
        #region  Articles自动生成成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int AddArticlesEntity(ArticlesEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Articles(");
			strSql.Append("Title,CityID,ArticleClass1ID,ArticleClass2ID,Source,SourceUrl,AddDate,AdminID,Content,IsUrl,Url,ShowLevel,Hits,Pic,sPic,Attachment)");
			strSql.Append(" values (");
			strSql.Append("@Title,@CityID,@ArticleClass1ID,@ArticleClass2ID,@Source,@SourceUrl,@AddDate,@AdminID,@Content,@IsUrl,@Url,@ShowLevel,@Hits,@Pic,@sPic,@Attachment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass2ID", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.NVarChar,60),
					new SqlParameter("@SourceUrl", SqlDbType.NVarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsUrl", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,400),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Pic", SqlDbType.NVarChar,500),
					new SqlParameter("@sPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment", SqlDbType.NVarChar,1000)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.ArticleClass1ID;
			parameters[3].Value = model.ArticleClass2ID;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.SourceUrl;
			parameters[6].Value = model.AddDate;
			parameters[7].Value = model.AdminID;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.IsUrl;
			parameters[10].Value = model.Url;
			parameters[11].Value = model.ShowLevel;
			parameters[12].Value = model.Hits;
			parameters[13].Value = model.Pic;
			parameters[14].Value = model.sPic;
			parameters[15].Value = model.Attachment;

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
		public static void UpdateArticlesEntity(ArticlesEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Articles set ");
			strSql.Append("Title=@Title,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("ArticleClass1ID=@ArticleClass1ID,");
			strSql.Append("ArticleClass2ID=@ArticleClass2ID,");
			strSql.Append("Source=@Source,");
			strSql.Append("SourceUrl=@SourceUrl,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("AdminID=@AdminID,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsUrl=@IsUrl,");
			strSql.Append("Url=@Url,");
			strSql.Append("ShowLevel=@ShowLevel,");
			strSql.Append("Hits=@Hits,");
			strSql.Append("Pic=@Pic,");
			strSql.Append("sPic=@sPic,");
			strSql.Append("Attachment=@Attachment");
			strSql.Append(" where ArticleID=@ArticleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass1ID", SqlDbType.Int,4),
					new SqlParameter("@ArticleClass2ID", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.NVarChar,60),
					new SqlParameter("@SourceUrl", SqlDbType.NVarChar,400),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsUrl", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,400),
					new SqlParameter("@ShowLevel", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Pic", SqlDbType.NVarChar,500),
					new SqlParameter("@sPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment", SqlDbType.NVarChar,1000)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.ArticleClass1ID;
			parameters[4].Value = model.ArticleClass2ID;
			parameters[5].Value = model.Source;
			parameters[6].Value = model.SourceUrl;
			parameters[7].Value = model.AddDate;
			parameters[8].Value = model.AdminID;
			parameters[9].Value = model.Content;
			parameters[10].Value = model.IsUrl;
			parameters[11].Value = model.Url;
			parameters[12].Value = model.ShowLevel;
			parameters[13].Value = model.Hits;
			parameters[14].Value = model.Pic;
			parameters[15].Value = model.sPic;
			parameters[16].Value = model.Attachment;

			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static void DeleteArticlesEntity(int ArticleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Articles ");
			strSql.Append(" where ArticleID=@ArticleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)};
			parameters[0].Value = ArticleID;

			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static ArticlesEntity GetArticlesEntity(int ArticleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ArticleID,Title,CityID,ArticleClass1ID,ArticleClass2ID,Source,SourceUrl,AddDate,AdminID,Content,IsUrl,Url,ShowLevel,Hits,Pic,sPic,Attachment from Articles ");
			strSql.Append(" where ArticleID=@ArticleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)};
			parameters[0].Value = ArticleID;

			ArticlesEntity model=new ArticlesEntity();
			DataSet ds=SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ArticleID"].ToString()!="")
				{
					model.ArticleID=int.Parse(ds.Tables[0].Rows[0]["ArticleID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString()!="")
				{
					model.ArticleClass1ID=int.Parse(ds.Tables[0].Rows[0]["ArticleClass1ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArticleClass2ID"].ToString()!="")
				{
					model.ArticleClass2ID=int.Parse(ds.Tables[0].Rows[0]["ArticleClass2ID"].ToString());
				}
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				model.SourceUrl=ds.Tables[0].Rows[0]["SourceUrl"].ToString();
				if(ds.Tables[0].Rows[0]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AdminID"].ToString()!="")
				{
					model.AdminID=int.Parse(ds.Tables[0].Rows[0]["AdminID"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["IsUrl"].ToString()!="")
				{
					model.IsUrl=int.Parse(ds.Tables[0].Rows[0]["IsUrl"].ToString());
				}
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				if(ds.Tables[0].Rows[0]["ShowLevel"].ToString()!="")
				{
					model.ShowLevel=int.Parse(ds.Tables[0].Rows[0]["ShowLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(ds.Tables[0].Rows[0]["Hits"].ToString());
				}
				model.Pic=ds.Tables[0].Rows[0]["Pic"].ToString();
				model.sPic=ds.Tables[0].Rows[0]["sPic"].ToString();
				model.Attachment=ds.Tables[0].Rows[0]["Attachment"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到符合要求的对象实体列表
		/// </summary>
		public static IList<ArticlesEntity> GetArticlesEntityList(int Top, string strWhere, string filedOrder)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ArticleID,Title,CityID,ArticleClass1ID,ArticleClass2ID,Source,SourceUrl,AddDate,AdminID,Content,IsUrl,Url,ShowLevel,Hits,Pic,sPic,Attachment from Articles ");
			
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }

            IList<ArticlesEntity> modelList = new List<ArticlesEntity>();

DataSet ds=SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
                    ArticlesEntity model = new ArticlesEntity();
				if(ds.Tables[0].Rows[i]["ArticleID"].ToString()!="")
				{
					model.ArticleID=int.Parse(ds.Tables[0].Rows[i]["ArticleID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[i]["Title"].ToString();
				if(ds.Tables[0].Rows[i]["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(ds.Tables[0].Rows[i]["CityID"].ToString());
				}
				if(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString()!="")
				{
					model.ArticleClass1ID=int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
				}
				if(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString()!="")
				{
					model.ArticleClass2ID=int.Parse(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString());
				}
				model.Source=ds.Tables[0].Rows[i]["Source"].ToString();
				model.SourceUrl=ds.Tables[0].Rows[i]["SourceUrl"].ToString();
				if(ds.Tables[0].Rows[i]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[i]["AddDate"].ToString());
				}
				if(ds.Tables[0].Rows[i]["AdminID"].ToString()!="")
				{
					model.AdminID=int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
				}
				model.Content=ds.Tables[0].Rows[i]["Content"].ToString();
				if(ds.Tables[0].Rows[i]["IsUrl"].ToString()!="")
				{
					model.IsUrl=int.Parse(ds.Tables[0].Rows[i]["IsUrl"].ToString());
				}
				model.Url=ds.Tables[0].Rows[i]["Url"].ToString();
				if(ds.Tables[0].Rows[i]["ShowLevel"].ToString()!="")
				{
					model.ShowLevel=int.Parse(ds.Tables[0].Rows[i]["ShowLevel"].ToString());
				}
				if(ds.Tables[0].Rows[i]["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(ds.Tables[0].Rows[i]["Hits"].ToString());
				}
				model.Pic=ds.Tables[0].Rows[i]["Pic"].ToString();
				model.sPic=ds.Tables[0].Rows[i]["sPic"].ToString();
				model.Attachment=ds.Tables[0].Rows[i]["Attachment"].ToString();
				modelList.Add(model);
			}
		    return modelList;
        }

		#endregion  Articles自动生成成员方法

        #region Articles手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticlesEntity> GetArticlesEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ArticleID,Title,CityID,ArticleClass1ID,ArticleClass2ID,Source,SourceUrl,AddDate,AdminID,Content,IsUrl,Url,ShowLevel,Hits,Pic,sPic,Attachment from Articles  ");

            IList<ArticlesEntity> modelList = new List<ArticlesEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ArticlesEntity model = new ArticlesEntity();
                    if (ds.Tables[0].Rows[i]["ArticleID"].ToString() != "")
                    {
                        model.ArticleID = int.Parse(ds.Tables[0].Rows[i]["ArticleID"].ToString());
                    }
                    model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    if (ds.Tables[0].Rows[i]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[i]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString() != "")
                    {
                        model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString() != "")
                    {
                        model.ArticleClass2ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString());
                    }
                    model.Source = ds.Tables[0].Rows[i]["Source"].ToString();
                    model.SourceUrl = ds.Tables[0].Rows[i]["SourceUrl"].ToString();
                    if (ds.Tables[0].Rows[i]["AddDate"].ToString() != "")
                    {
                        model.AddDate = DateTime.Parse(ds.Tables[0].Rows[i]["AddDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["AdminID"].ToString() != "")
                    {
                        model.AdminID = int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
                    }
                    model.Content = ds.Tables[0].Rows[i]["Content"].ToString();
                    if (ds.Tables[0].Rows[i]["IsUrl"].ToString() != "")
                    {
                        model.IsUrl = int.Parse(ds.Tables[0].Rows[i]["IsUrl"].ToString());
                    }
                    model.Url = ds.Tables[0].Rows[i]["Url"].ToString();
                    if (ds.Tables[0].Rows[i]["ShowLevel"].ToString() != "")
                    {
                        model.ShowLevel = int.Parse(ds.Tables[0].Rows[i]["ShowLevel"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Hits"].ToString() != "")
                    {
                        model.Hits = int.Parse(ds.Tables[0].Rows[i]["Hits"].ToString());
                    }
                    model.Pic = ds.Tables[0].Rows[i]["Pic"].ToString();
                    model.sPic = ds.Tables[0].Rows[i]["sPic"].ToString();
                    model.Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }




        /// <summary>
        /// 返回新闻详细列表  ---首页显示
        /// </summary>
        /// <param name="nums">表示返回的记录数 （0表示无限制）</param>
        /// <param name="title_len">表示新闻标题的长度 （0表示无限制）</param>
        /// <param name="Class_ID">新闻类别的ID （0表示无限制）</param>
        /// <param name="is_show_time">是否显示时间 （0表示不显示 1表示显示）</param>
        /// <param name="OrderType">排序的方式 （0表示按id倒序排，1表示按优先级（高-低）方式，2表示按添加时间排序）</param>
        /// <returns>返回DataView   (id , name ,level,isshow)</returns>
        /// 
        public static IList<ArticlesEntity> GetArticlesEntityList(int Nums, int TitleLen, int ArticleClass1ID, int ArticleClass2ID, string OrderType)
        {
            string strSql = "select ";
            if (Nums > 0)
            {
                strSql += " top " + Nums.ToString();
            }

            if (TitleLen > 0)
            {
                strSql += " left(Title," + TitleLen.ToString() + ") as Title ,";
            }
            else
            {
                strSql += " Title,";
            }
            strSql += " ArticleID,Title,CityID,ArticleClass1ID,ArticleClass2ID,Source,SourceUrl,AddDate,AdminID,Content,IsUrl,Url,ShowLevel,Hits,Pic,sPic,Attachment from Articles where 1=1 ";
            if (ArticleClass1ID != 0)
            {
                strSql += " and ArticleClass1ID=" + ArticleClass1ID;
            }
            if (ArticleClass2ID != 0)
            {
                strSql += " and ArticleClass2ID=" + ArticleClass2ID;
            }


            switch (OrderType)
            {
                case "0":
                    strSql += " order by ArticleID desc ";
                    break;
                case "1":
                    strSql += " order by ShowLevel asc,AddDate desc ";
                    break;
                case "2":
                    strSql += " order by AddDate ";
                    break;
            }

            IList<ArticlesEntity> modelList = new List<ArticlesEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ArticlesEntity model = new ArticlesEntity();
                    if (ds.Tables[0].Rows[i]["ArticleID"].ToString() != "")
                    {
                        model.ArticleID = int.Parse(ds.Tables[0].Rows[i]["ArticleID"].ToString());
                    }
                    model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    if (ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString() != "")
                    {
                        model.ArticleClass1ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass1ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString() != "")
                    {
                        model.ArticleClass2ID = int.Parse(ds.Tables[0].Rows[i]["ArticleClass2ID"].ToString());
                    }
                    model.Source = ds.Tables[0].Rows[i]["Source"].ToString();
                    model.SourceUrl = ds.Tables[0].Rows[i]["SourceUrl"].ToString();
                    if (ds.Tables[0].Rows[i]["AddDate"].ToString() != "")
                    {
                        model.AddDate = DateTime.Parse(ds.Tables[0].Rows[i]["AddDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["AdminID"].ToString() != "")
                    {
                        model.AdminID = int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
                    }
                    model.Content = ds.Tables[0].Rows[i]["Content"].ToString();
                    if (ds.Tables[0].Rows[i]["IsUrl"].ToString() != "")
                    {
                        model.IsUrl = int.Parse(ds.Tables[0].Rows[i]["IsUrl"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["IsUrl"].ToString() == "0")
                    {
                        model.Url = "/news.aspx?ID=" + ds.Tables[0].Rows[i]["ArticleID"].ToString();
                    }
                    else
                    {
                        model.Url = ds.Tables[0].Rows[i]["Url"].ToString();
                    }

                    if (ds.Tables[0].Rows[i]["ShowLevel"].ToString() != "")
                    {
                        model.ShowLevel = int.Parse(ds.Tables[0].Rows[i]["ShowLevel"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Hits"].ToString() != "")
                    {
                        model.Hits = int.Parse(ds.Tables[0].Rows[i]["Hits"].ToString());
                    }
                    model.Pic = ds.Tables[0].Rows[i]["Pic"].ToString();
                    model.sPic = ds.Tables[0].Rows[i]["sPic"].ToString();
                    model.Attachment = ds.Tables[0].Rows[i]["Attachment"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 返回新闻详细列表  ---首页显示
        /// </summary>
        /// <param name="nums">表示返回的记录数 （0表示无限制）</param>
        /// <param name="title_len">表示新闻标题的长度 （0表示无限制）</param>
        /// <param name="Class_ID">新闻类别的ID （0表示无限制）</param>
        /// <param name="is_show_time">是否显示时间 （0表示不显示 1表示显示）</param>
        /// <param name="OrderType">排序的方式 （0表示按id倒序排，1表示按优先级（高-低）方式，2表示按添加时间排序）</param>
        /// <returns>返回DataView   (id , name ,level,isshow)</returns>
        /// 
        public static DataView GetArticlesListDataView(int Nums, int TitleLen, int ArticleClass1ID, int ArticleClass2ID, string OrderType)
        {
            string strSql = "select ";
            if (Nums > 0)
            {
                strSql += " top " + Nums.ToString();
            }

            if (TitleLen > 0)
            {
                strSql += " left(Title," + TitleLen.ToString() + ") as Title ,";
            }
            else
            {
                strSql += " Title,";
            }
            strSql += " ArticleID,AddDate,ArticleClass1ID,ArticleClass2ID,Content,IsUrl,Url,Hits,Pic,sPic,Attachment from Articles where 1=1 ";
            if (ArticleClass1ID != 0)
            {
                strSql += " and ArticleClass1ID=" + ArticleClass1ID;
            }
            if (ArticleClass2ID != 0)
            {
                strSql += " and ArticleClass2ID=" + ArticleClass2ID;
            }


            switch (OrderType)
            {
                case "0":
                    strSql += " order by ArticleID desc ";
                    break;
                case "1":
                    strSql += " order by ShowLevel asc,AddDate desc ";
                    break;
                case "2":
                    strSql += " order by AddDate ";
                    break;
            }


            DataView dv = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null).DefaultView;
            foreach (DataRowView drv in dv)
            {
                if (drv["IsUrl"].ToString() == "0")
                {
                    drv["Url"] = "/news.aspx?ID=" + drv["ArticleID"];
                }
            }
            return dv;
        }

        /// <summary>
        /// 增加点击数
        /// </summary>
        /// <param name="TableName">Articles,BBSTopic,CuXiaos,News共四个</param>
        /// <param name="ID"></param>
        public static void UpdateHits( int ID)
        {
            string strSql =  "update Articles set Hits=Hits+1 where ArticleID=" + ID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
        }

        #endregion Articles手写方法
    }
}