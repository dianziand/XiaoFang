using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class BigTypesEntity
    {
        public BigTypesEntity()
        { }
        #region Model
        private int _bigtypeid = 0;
        private string _bigname = "";
        /// <summary>
        /// 
        /// </summary>
        public int BigTypeID
        {
            set { _bigtypeid = value; }
            get { return _bigtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BigName
        {
            set { _bigname = value; }
            get { return _bigname; }
        }
        #endregion Model

    }
}
