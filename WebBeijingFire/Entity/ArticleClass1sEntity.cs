using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ArticleClass1sEntity
    {
        public ArticleClass1sEntity()
        { }
        #region Model
        private int _articleclass1id = 0;
        private string _articleclass1name = "";
        private int _showlevel = 0;
        private string _words = "";
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
        public string ArticleClass1Name
        {
            set { _articleclass1name = value; }
            get { return _articleclass1name; }
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
