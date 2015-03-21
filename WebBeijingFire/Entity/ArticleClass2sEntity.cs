using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ArticleClass2sEntity
    {
        public ArticleClass2sEntity()
        { }
        #region Model
        private int _articleclass2id = 0;
        private string _articleclass2name = "";
        private int _articleclass1id = 0;
        private int _showlevel = 0;
        private string _words = "";
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
        public string ArticleClass2Name
        {
            set { _articleclass2name = value; }
            get { return _articleclass2name; }
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
        public int ShowLevel
        {
            set { _showlevel = value; }
            get { return _showlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Words
        {
            set { _words = value; }
            get { return _words; }
        }
        #endregion Model

    }
}
