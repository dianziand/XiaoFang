using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class LittleTypesEntity
    {
        public LittleTypesEntity()
        { }
        #region Model
        private int _littletypeid = 0;
        private string _littlename = "";
        private int _bigtypeid = 0;
        /// <summary>
        /// 
        /// </summary>
        public int LittleTypeID
        {
            set { _littletypeid = value; }
            get { return _littletypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LittleName
        {
            set { _littlename = value; }
            get { return _littlename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BigTypeID
        {
            set { _bigtypeid = value; }
            get { return _bigtypeid; }
        }
        #endregion Model

    }
}
