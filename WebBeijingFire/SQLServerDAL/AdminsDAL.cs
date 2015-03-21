using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class AdminsDAL
    {
        #region  Admins自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddAdminsEntity(AdminsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Admins(");
            strSql.Append("AdminName,AdminPwd,AdminGroupID,CityID,Active,LoginCount,LastLoginTime,IP)");
            strSql.Append(" values (");
            strSql.Append("@AdminName,@AdminPwd,@AdminGroupID,@CityID,@Active,@LoginCount,@LastLoginTime,@IP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@Active", SqlDbType.Int,4),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.AdminName;
            parameters[1].Value = model.AdminPwd;
            parameters[2].Value = model.AdminGroupID;
            parameters[3].Value = model.CityID;
            parameters[4].Value = model.Active;
            parameters[5].Value = model.LoginCount;
            parameters[6].Value = model.LastLoginTime;
            parameters[7].Value = model.IP;

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
        public static void UpdateAdminsEntity(AdminsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admins set ");
            strSql.Append("AdminName=@AdminName,");
            strSql.Append("AdminPwd=@AdminPwd,");
            strSql.Append("AdminGroupID=@AdminGroupID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("Active=@Active,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("IP=@IP");
            strSql.Append(" where AdminID=@AdminID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@Active", SqlDbType.Int,4),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.AdminID;
            parameters[1].Value = model.AdminName;
            parameters[2].Value = model.AdminPwd;
            parameters[3].Value = model.AdminGroupID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.Active;
            parameters[6].Value = model.LoginCount;
            parameters[7].Value = model.LastLoginTime;
            parameters[8].Value = model.IP;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteAdminsEntity(int AdminID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Admins ");
            strSql.Append(" where AdminID=@AdminID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)};
            parameters[0].Value = AdminID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AdminsEntity GetAdminsEntity(int AdminID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AdminID,AdminName,AdminPwd,AdminGroupID,CityID,Active,LoginCount,LastLoginTime,IP from Admins ");
            strSql.Append(" where AdminID=@AdminID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)};
            parameters[0].Value = AdminID;

            AdminsEntity model = new AdminsEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdminID"].ToString() != "")
                {
                    model.AdminID = int.Parse(ds.Tables[0].Rows[0]["AdminID"].ToString());
                }
                model.AdminName = ds.Tables[0].Rows[0]["AdminName"].ToString();
                model.AdminPwd = ds.Tables[0].Rows[0]["AdminPwd"].ToString();
                if (ds.Tables[0].Rows[0]["AdminGroupID"].ToString() != "")
                {
                    model.AdminGroupID = int.Parse(ds.Tables[0].Rows[0]["AdminGroupID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Active"].ToString() != "")
                {
                    model.Active = int.Parse(ds.Tables[0].Rows[0]["Active"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Admins自动生成成员方法



        #region Admins手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AdminID,AdminName,AdminPwd,AdminGroupID,CityID,Active,LoginCount,LastLoginTime,IP from Admins ");

            IList<AdminsEntity> modelList = new List<AdminsEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AdminsEntity model = new AdminsEntity();
                    if (ds.Tables[0].Rows[i]["AdminID"].ToString() != "")
                    {
                        model.AdminID = int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
                    }
                    model.AdminName = ds.Tables[0].Rows[i]["AdminName"].ToString();
                    model.AdminPwd = ds.Tables[0].Rows[i]["AdminPwd"].ToString();
                    if (ds.Tables[0].Rows[i]["AdminGroupID"].ToString() != "")
                    {
                        model.AdminGroupID = int.Parse(ds.Tables[0].Rows[i]["AdminGroupID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[i]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Active"].ToString() != "")
                    {
                        model.Active = int.Parse(ds.Tables[0].Rows[i]["Active"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[i]["LoginCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[i]["LastLoginTime"].ToString());
                    }
                    model.IP = ds.Tables[0].Rows[i]["IP"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList(string strWhere, string filedOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AdminID,AdminName,AdminPwd,AdminGroupID,CityID,Active,LoginCount,LastLoginTime,IP from Admins ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }

            IList<AdminsEntity> modelList = new List<AdminsEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AdminsEntity model = new AdminsEntity();
                    if (ds.Tables[0].Rows[i]["AdminID"].ToString() != "")
                    {
                        model.AdminID = int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
                    }
                    model.AdminName = ds.Tables[0].Rows[i]["AdminName"].ToString();
                    model.AdminPwd = ds.Tables[0].Rows[i]["AdminPwd"].ToString();
                    if (ds.Tables[0].Rows[i]["AdminGroupID"].ToString() != "")
                    {
                        model.AdminGroupID = int.Parse(ds.Tables[0].Rows[i]["AdminGroupID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[i]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Active"].ToString() != "")
                    {
                        model.Active = int.Parse(ds.Tables[0].Rows[i]["Active"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[i]["LoginCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[i]["LastLoginTime"].ToString());
                    }
                    model.IP = ds.Tables[0].Rows[i]["IP"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList(int Top,string strWhere, string filedOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AdminID,AdminName,AdminPwd,AdminGroupID,CityID,Active,LoginCount,LastLoginTime,IP from Admins ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }

            IList<AdminsEntity> modelList = new List<AdminsEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AdminsEntity model = new AdminsEntity();
                    if (ds.Tables[0].Rows[i]["AdminID"].ToString() != "")
                    {
                        model.AdminID = int.Parse(ds.Tables[0].Rows[i]["AdminID"].ToString());
                    }
                    model.AdminName = ds.Tables[0].Rows[i]["AdminName"].ToString();
                    model.AdminPwd = ds.Tables[0].Rows[i]["AdminPwd"].ToString();
                    if (ds.Tables[0].Rows[i]["AdminGroupID"].ToString() != "")
                    {
                        model.AdminGroupID = int.Parse(ds.Tables[0].Rows[i]["AdminGroupID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[i]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Active"].ToString() != "")
                    {
                        model.Active = int.Parse(ds.Tables[0].Rows[i]["Active"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[i]["LoginCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[i]["LastLoginTime"].ToString());
                    }
                    model.IP = ds.Tables[0].Rows[i]["IP"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion Admins手写方法
    }
}
