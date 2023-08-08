using System.Data.Common;

namespace DAL.CustomException
{
    public class DBSqlException : Exception
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