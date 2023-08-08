using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DapperLibrary
{
    public static class DapperHelper
    {

        /// <summary>
        /// 根據傳入的DateTime取得符合informix的DateTime DbString
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DbString GetInformixDateTimeColStr(DateTime? dateTime)
        {
            if (dateTime == null) return new DbString 
            {   
                Value=null,
                IsFixedLength = true,
                Length = 0,
                IsAnsi = true
            };
            return DapperHelper.GetDbString(dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),20);
        }

        /// <summary>
        /// 根據傳入的DateTime取得符合informix的Date DbString
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DbString GetInformixDateColStr(DateTime? dateTime)
        {
            if (dateTime == null) return new DbString
            {
                Value = null,
                IsFixedLength = true,
                Length = 0,
                IsAnsi = true
            };
            return DapperHelper.GetDbString(dateTime.Value.ToString("yyyy-MM-dd"), 20);
        }


        public static DbString GetDbString(string value, int length = 30)
        {
            return new DbString
            {
                Value = value,
                IsFixedLength = true,
                Length = length,
                IsAnsi = true
            };
        }
    }
}
