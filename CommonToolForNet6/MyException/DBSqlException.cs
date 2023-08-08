using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolForNet6.MyException
{
    public class DBSqlException:Exception
    {
        private DbException _dbException;
        public DBSqlException(DbException db)
        {
            this._dbException = db;
        }
        public DbException dbException 
        { 
            get
            {
                return _dbException;
            }
        }
        public string errorSql { get; set; }
    }
}
