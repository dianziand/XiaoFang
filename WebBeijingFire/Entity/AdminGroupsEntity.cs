using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class AdminGroupsEntity
    {
        public AdminGroupsEntity()
        { }
        #region Model
        private int _admingroupid = 0;
        private string _admingroupname = "";
        /// <summary>
        /// 
        /// </summary>
        public int AdminGroupID
        {
            set { _admingroupid = value; }
            get { return _admingroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminGroupName
        {
            set { _admingroupname = value; }
            get { return _admingroupname; }
        }
        #endregion Model

    }
}
