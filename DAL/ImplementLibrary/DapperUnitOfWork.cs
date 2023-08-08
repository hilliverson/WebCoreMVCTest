using DAL.InterfaceLibrary;
using LogLibrary.LogInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL.ImplementLibrary
{
    public class DapperUnitOfWork : IUnitOfWorkTransaction
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private IMyLogger _logger;
        //private Dictionary<Type, Type> _repositoryMap;

        public IDbTransaction Transaction => _transaction;

        public DapperUnitOfWork(IDbConnection connection, IMyLogger logger)
        {
            this._connection = connection;
            this._logger = logger;
            //this._repositoryMap = new Dictionary<Type, Type>();

        }

        /// <summary>
        /// 打開dbconnection並取得transaction，如果要做transaction必須在初始化repository之前使用open
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Open()
        {
            if (_connection == null) throw new Exception("_connection is null");
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null) throw new Exception("_transaction is null");
            _transaction.Commit();
            _connection.Close();
        }

       

        ///// <summary>
        ///// 根據interface取得實作的class，優先使用transaction 建立物件，但若transaction為null，則使用dbconnection
        ///// </summary>
        ///// <typeparam name="TInterface"></typeparam>
        ///// <returns></returns>
        ///// <exception cref="ArgumentException"></exception>
        //public TInterface GetRepository<TInterface>() where TInterface : class
        //{
        //    var type = typeof(TInterface);
        //    if (!this._repositoryMap.ContainsKey(type))
        //        throw new ArgumentException("No such register map data");

        //    if (_transaction == null && _connection == null) 
        //        throw new Exception("transaction and connection are all null");

        //    if (_transaction != null)
        //    {
        //        return (TInterface)System.Activator.CreateInstance(this._repositoryMap[type], 
        //            _transaction, _logger);
        //    }
        //    else
        //    {
        //        return (TInterface)System.Activator.CreateInstance(this._repositoryMap[type], 
        //            _connection, _logger);
        //    }
        //}



        ///// <summary>
        ///// 註冊哪個interface對應到哪個class
        ///// </summary>
        ///// <typeparam name="TInterface">介面</typeparam>
        ///// <typeparam name="TImplement">實作的class</typeparam>
        //public void RegisterRepository<TInterface, TImplement>()
        //    where TInterface : class
        //    where TImplement : class
        //{
        //    if (this._repositoryMap.ContainsKey(typeof(TInterface)))
        //        return;
        //    if (this._repositoryMap.ContainsValue(typeof(TImplement)))
        //        return;

        //    this._repositoryMap.Add(typeof(TInterface), typeof(TImplement));

        //}
    }
}
