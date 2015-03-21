using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ArticlesEntity
    {
        public ArticlesEntity()
        { }
        #region Model
        private int _articleid = 0;
        private string _title = "";
        private int _cityid = 0;
        private int _articleclass1id = 0;
        private int _articleclass2id = 0;
        private string _source = "";
        private string _sourceurl = "";
        private DateTime _adddate = DateTime.Now;
        private int _adminid = 0;
        private string _content = "";
        private int _isurl = 0;
        private string _url = "";
        private int _showlevel = 0;
        private int _hits = 0;
        private string _pic = "";
        private string _spic = "";
        private string _attachment = "";
        /// <summary>
        /// 
        /// </summary>
        public int ArticleID
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ArticleClass1ID
        {
            set { _articleclass1id = value; }
            get { return _articleclass1id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ArticleClass2ID
        {
            set { _articleclass2id = value; }
            get { return _articleclass2id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceUrl
        {
            set { _sourceurl = value; }
            get { return _sourceurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AdminID
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsUrl
        {
            set { _isurl = value; }
            get { return _isurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShowLevel
        {
            set { _showlevel = value; }
            get { return _showlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sPic
        {
            set { _spic = value; }
            get { return _spic; }
        }
        /// <summary>
        /// 上传的附件，附件名称||url';附件名称||url格式
        /// </summary>
        public string Attachment
        {
            set { _attachment = value; }
            get { return _attachment; }
        }
        #endregion Model

    }
}
