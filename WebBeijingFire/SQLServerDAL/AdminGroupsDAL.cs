using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class AdminGroupsDAL
    {
        #region  AdminGroups自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddAdminGroupsEntity(AdminGroupsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminGroups(");
            strSql.Append("AdminGroupName)");
            strSql.Append(" values (");
            strSql.Append("@AdminGroupName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminGroupName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AdminGroupName;

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
        public static void UpdateAdminGroupsEntity(AdminGroupsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminGroups set ");
            strSql.Append("AdminGroupName=@AdminGroupName");
            strSql.Append(" where AdminGroupID=@AdminGroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminGroupID", SqlDbType.Int,4),
					new SqlParameter("@AdminGroupName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AdminGroupID;
            parameters[1].Value = model.AdminGroupName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteAdminGroupsEntity(int AdminGroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminGroups ");
            strSql.Append(" where AdminGroupID=@AdminGroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminGroupID", SqlDbType.Int,4)};
            parameters[0].Value = AdminGroupID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AdminGroupsEntity GetAdminGroupsEntity(int AdminGroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AdminGroupID,AdminGroupName from AdminGroups ");
            strSql.Append(" where AdminGroupID=@AdminGroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminGroupID", SqlDbType.Int,4)};
            parameters[0].Value = AdminGroupID;

            AdminGroupsEntity model = new AdminGroupsEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdminGroupID"].ToString() != "")
                {
                    model.AdminGroupID = int.Parse(ds.Tables[0].Rows[0]["AdminGroupID"].ToString());
                }
                model.AdminGroupName = ds.Tables[0].Rows[0]["AdminGroupName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  AdminGroups自动生成成员方法


        #region AdminGroups手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminGroupsEntity> GetAdminGroupsEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AdminGroupID,AdminGroupName from AdminGroups ");

            IList<AdminGroupsEntity> modelList = new List<AdminGroupsEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AdminGroupsEntity model = new AdminGroupsEntity();
                    if (ds.Tables[0].Rows[i]["AdminGroupID"].ToString() != "")
                    {
                        model.AdminGroupID = int.Parse(ds.Tables[0].Rows[i]["AdminGroupID"].ToString());
                    }
                    model.AdminGroupName = ds.Tables[0].Rows[i]["AdminGroupName"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion AdminGroups手写方法
    }
}
