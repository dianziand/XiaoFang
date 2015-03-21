using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class AdminsEntity
    {
        public AdminsEntity()
        { }
        #region Model
        private int _adminid = 0;
        private string _adminname = "";
        private string _adminpwd = "";
        private int _admingroupid = 0;
        private int _cityid = 0;
        private int _active = 0;
        private int _logincount = 0;
        private DateTime _lastlogintime = DateTime.Now;
        private string _ip = "";
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
        public string AdminName
        {
            set { _adminname = value; }
            get { return _adminname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminPwd
        {
            set { _adminpwd = value; }
            get { return _adminpwd; }
        }
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
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Active
        {
            set { _active = value; }
            get { return _active; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginCount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        #endregion Model

    }
}
