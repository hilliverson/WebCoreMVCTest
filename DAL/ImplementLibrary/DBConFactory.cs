using DAL.InterfaceLibrary;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ImplementLibrary
{
    public class DBConFactory:IDBConFactory
    {
        private DBSetting _dbSetting;
        
        public DBConFactory(DBSetting dbSetting)
        {
            if (dbSetting == null) 
                throw new ArgumentNullException("DBConFactory parameter dbSetting is null");
            this._dbSetting = dbSetting; 
        }

       

        public IDbConnection GetConnection()
        {
            IDbConnection connection = null;

            switch (_dbSetting.dbProvider)
            {
                case DBProvider.Oracle:
                    //connection = new OracleConnection(_dbSetting.connectionStr);
                    break;
                case DBProvider.MsSqlServer:
                    connection = new SqlConnection(_dbSetting.connectionStr);
                    break;
                case DBProvider.Odbc:
                    connection=new OdbcConnection(_dbSetting.connectionStr);
                    break;
                default:
                    throw new ArgumentException($"No such type Data");
            }

            return connection;
        }
    }
}

