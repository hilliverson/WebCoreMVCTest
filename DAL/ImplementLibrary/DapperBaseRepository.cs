using DAL.CustomException;
using DAL.InterfaceLibrary;
using Dapper;
using DapperExtensions;
using LogLibrary.LogInterface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ImplementLibrary
{
    public class DapperBaseRepository
    {
        IUnitOfWorkTransaction _context;
        public DapperBaseRepository(IUnitOfWorkTransaction context, IMyLogger myLogger) 
        {
            _context = context;
            myLogger = myLogger;

        }

        

        public IMyLogger myLogger {  get; private set; }



       

        private TResult Execute<TResult>(Func<TResult> func,string sql, object parameters) 
        {
            try
            {
                CheckDBConnectionStatus();
                return func();
            }
            catch (DbException ex)
            {
                DBSqlException dBSqlException = new DBSqlException(ex);
                dBSqlException.errorSql = sql;
                throw dBSqlException;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected void Insert<T>(T obj) where T : class 
        {
            try
            {
                CheckDBConnectionStatus();
                this._context.Transaction.Connection.Insert<T>(obj, _context.Transaction);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected T ExecuteScalar<T>(string sql, object parameters = null)
        {
            Func<T> func = () =>
            {
                return this._context.Transaction.Connection.ExecuteScalar<T>(sql, parameters, _context.Transaction);
            };
            return Execute<T>(func, sql, parameters);
        }


        /// <summary>
        /// 執行SQL，一定要使用Transaction
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected int ExecuteSql(string sql, object parameters = null)
        {
            Func<int> func = () =>
            {
                return this._context.Transaction.Connection.Execute(sql, parameters, _context.Transaction);
            };
            return Execute<int>(func, sql, parameters);
            
        }

        /// <summary>
        /// 查詢，可使用dbConnection或是tansaction進行查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected List<T> QueryList<T>(string sql, object parameter = null)
        {
            Func<List<T>> func = () =>
            {
                
                return this._context.Transaction.Connection.Query<T>(sql, parameter, _context.Transaction).ToList<T>();
                
            };
            return Execute<List<T>>(func, sql, parameter);
            
        }

        private void CheckDBConnectionStatus()
        {
            if(_context.Transaction == null)
            {
                throw new Exception("DBTransaction is null");
            }

            if (this._context != null)
            {
                if (this._context.Transaction.Connection.State == ConnectionState.Closed ||
                   this._context.Transaction.Connection.State == ConnectionState.Broken)
                {
                    throw new Exception("DBConnection Status is not open,Please use UnitOfWork's Open()");
                }
            }

        }
    }
}
