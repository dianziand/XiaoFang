using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLServerDAL;
using Entity;

namespace Business
{
    public class WebClass
    {

        #region  AdminGroups自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddAdminGroupsEntity(AdminGroupsEntity model)
        {
            return AdminGroupsDAL.AddAdminGroupsEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateAdminGroupsEntity(AdminGroupsEntity model)
        {
            AdminGroupsDAL.UpdateAdminGroupsEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteAdminGroupsEntity(int AdminGroupID)
        {
            AdminGroupsDAL.DeleteAdminGroupsEntity(AdminGroupID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AdminGroupsEntity GetAdminGroupsEntity(int AdminGroupID)
        {
            return AdminGroupsDAL.GetAdminGroupsEntity(AdminGroupID);
        }

        #endregion  AdminGroups自动生成成员方法


        #region AdminGroups手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminGroupsEntity> GetAdminGroupsEntityList()
        {
            return AdminGroupsDAL.GetAdminGroupsEntityList();
        }
        #endregion AdminGroups手写方法



        #region  Admins自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddAdminsEntity(AdminsEntity model)
        {
            return AdminsDAL.AddAdminsEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateAdminsEntity(AdminsEntity model)
        {
            AdminsDAL.UpdateAdminsEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteAdminsEntity(int AdminID)
        {
            AdminsDAL.DeleteAdminsEntity(AdminID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AdminsEntity GetAdminsEntity(int AdminID)
        {
            return AdminsDAL.GetAdminsEntity(AdminID);
        }

        #endregion  Admins自动生成成员方法



        #region Admins手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList()
        {
            return AdminsDAL.GetAdminsEntityList();
        }

        public static AdminsEntity GetAdminsEntity(string AdminName)
        {
            IList<AdminsEntity> modelList = AdminsDAL.GetAdminsEntityList("AdminName='" + AdminName+"'", "");
            if (modelList.Count > 0)
            {
                return modelList[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList(string strWhere, string filedOrder)
        {
            return AdminsDAL.GetAdminsEntityList(strWhere, filedOrder);
        }

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<AdminsEntity> GetAdminsEntityList(int Top, string strWhere, string filedOrder)
        {
            return AdminsDAL.GetAdminsEntityList(Top,strWhere, filedOrder);
        }
        #endregion Admins手写方法


        #region  ArticleClass1s自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddArticleClass1sEntity(ArticleClass1sEntity model)
        {
            return ArticleClass1sDAL.AddArticleClass1sEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateArticleClass1sEntity(ArticleClass1sEntity model)
        {
            ArticleClass1sDAL.UpdateArticleClass1sEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteArticleClass1sEntity(int ArticleClass1ID)
        {
            ArticleClass1sDAL.DeleteArticleClass1sEntity(ArticleClass1ID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ArticleClass1sEntity GetArticleClass1sEntity(int ArticleClass1ID)
        {
            return ArticleClass1sDAL.GetArticleClass1sEntity(ArticleClass1ID);
        }

        #endregion  ArticleClass1s自动生成成员方法


        #region ArticleClass1s手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass1sEntity> GetArticleClass1sEntityList()
        {
            return ArticleClass1sDAL.GetArticleClass1sEntityList();
        }
        #endregion ArticleClass1s手写方法


        #region  ArticleClass2s自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddArticleClass2sEntity(ArticleClass2sEntity model)
        {
            return ArticleClass2sDAL.AddArticleClass2sEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateArticleClass2sEntity(ArticleClass2sEntity model)
        {
            ArticleClass2sDAL.UpdateArticleClass2sEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteArticleClass2sEntity(int ArticleClass2ID)
        {
            ArticleClass2sDAL.DeleteArticleClass2sEntity(ArticleClass2ID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ArticleClass2sEntity GetArticleClass2sEntity(int ArticleClass2ID)
        {
            return ArticleClass2sDAL.GetArticleClass2sEntity(ArticleClass2ID);
        }

        #endregion  ArticleClass2s自动生成成员方法


        #region ArticleClass2s手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass2sEntity> GetArticleClass2sEntityList()
        {
            return ArticleClass2sDAL.GetArticleClass2sEntityList();
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticleClass2sEntity> GetArticleClass2sEntityList(int Top, string strWhere, string filedOrder)
        {

            return ArticleClass2sDAL.GetArticleClass2sEntityList(Top,strWhere,filedOrder);
        }


        #endregion ArticleClass2s手写方法


        #region  Articles自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddArticlesEntity(ArticlesEntity model)
        {
            return ArticlesDAL.AddArticlesEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateArticlesEntity(ArticlesEntity model)
        {
            ArticlesDAL.UpdateArticlesEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteArticlesEntity(int ArticleID)
        {
            ArticlesDAL.DeleteArticlesEntity(ArticleID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ArticlesEntity GetArticlesEntity(int ArticleID)
        {
            return ArticlesDAL.GetArticlesEntity(ArticleID);
        }

        #endregion  Articles自动生成成员方法

        #region Articles手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticlesEntity> GetArticlesEntityList()
        {
            return ArticlesDAL.GetArticlesEntityList();
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<ArticlesEntity> GetArticlesEntityList(int Top, string strWhere, string filedOrder)
        {

            return ArticlesDAL.GetArticlesEntityList(Top,strWhere,filedOrder);
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
            return ArticlesDAL.GetArticlesListDataView(Nums, TitleLen, ArticleClass1ID, ArticleClass2ID, OrderType);
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
            return ArticlesDAL.GetArticlesEntityList(Nums, TitleLen, ArticleClass1ID, ArticleClass2ID, OrderType);
        }
        
        /// <summary>
        /// 增加点击数
        /// </summary>
        /// <param name="TableName">Articles,BBSTopic,CuXiaos,News共四个</param>
        /// <param name="ID"></param>
        public static void UpdateHits( int ID)
        {
            ArticlesDAL.UpdateHits(ID);
        }
        #endregion Articles手写方法


        #region  BigTypes自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddBigTypesEntity(BigTypesEntity model)
        {
            return BigTypesDAL.AddBigTypesEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateBigTypesEntity(BigTypesEntity model)
        {
            BigTypesDAL.UpdateBigTypesEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteBigTypesEntity(int BigTypeID)
        {
            BigTypesDAL.DeleteBigTypesEntity(BigTypeID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static BigTypesEntity GetBigTypesEntity(int BigTypeID)
        {
            return BigTypesDAL.GetBigTypesEntity(BigTypeID);
        }

        #endregion  BigTypes自动生成成员方法


        #region BigTypes手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<BigTypesEntity> GetBigTypesEntityList()
        {
            return BigTypesDAL.GetBigTypesEntityList();
        }
        #endregion BigTypes手写方法


        #region  LittleTypes自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddLittleTypesEntity(LittleTypesEntity model)
        {
            return LittleTypesDAL.AddLittleTypesEntity(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateLittleTypesEntity(LittleTypesEntity model)
        {
            LittleTypesDAL.UpdateLittleTypesEntity(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteLittleTypesEntity(int LittleTypeID)
        {
            LittleTypesDAL.DeleteLittleTypesEntity(LittleTypeID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static LittleTypesEntity GetLittleTypesEntity(int LittleTypeID)
        {
            return LittleTypesDAL.GetLittleTypesEntity(LittleTypeID);
        }

        #endregion  LittleTypes自动生成成员方法

        #region LittleTypes手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<LittleTypesEntity> GetLittleTypesEntityList()
        {
            return LittleTypesDAL.GetLittleTypesEntityList();
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<LittleTypesEntity> GetLittleTypesEntityList(int Top, string strWhere, string filedOrder)
        {
            return LittleTypesDAL.GetLittleTypesEntityList(Top, strWhere, filedOrder);
        }
        #endregion LittleTypes手写方法


        #region CommonDAL手动编写

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要显示的字段列表</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的记录数</param>
        /// <param name="fldSort">排序字段列表或条件</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="StrCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>
        /// <returns></returns>
        public static DataTable GetResultSP_Page2000(
            string tblName,
            string fldName,
            int pageSize,
            int page,
            out int pageCount,

            out int Counts,
            string fldSort,
            int Sort,
            string strCondition,
            string ID,

            int Dist)
        {
            return CommonDAL.GetResultSP_Page2000(tblName, fldName, pageSize, page, out pageCount, out Counts, fldSort, Sort, strCondition, ID, Dist);
        }
        #endregion CommonDAL手动编写




        public static string GetNeiRong(string strContent, string strStart, string strEnd, int iStart, int iEnd)
        {
            string reVal = "";
            if (iEnd > 0 && iEnd > iStart && iEnd < strContent.Length)
                strContent = strContent.Substring(iStart, iEnd - iStart);
            iStart = strContent.IndexOf(strStart, iStart);
            if (iStart < 0) return "";
            iEnd = strContent.IndexOf(strEnd, iStart);
            iStart += strStart.Length;
            if (iStart > 0 && iEnd > 0 && iEnd > iStart)
            {
                reVal = strContent.Substring(iStart, iEnd - iStart);
            }
            return reVal;
        }


        public static string GetNeiRong(string strContent, string strStart, string strEnd)
        {
            return GetNeiRong(strContent, strStart, strEnd, 0, 0);
        }

    }
}
