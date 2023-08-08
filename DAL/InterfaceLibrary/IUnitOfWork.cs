using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfaceLibrary
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 打開connection
        /// </summary>
        void Open();
        /// <summary>
        /// 進行Commit
        /// </summary>
        void Commit();
        ///// <summary>
        ///// 取得Repository
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //T GetRepository<T>() where T: class;
        
        /// <summary>
        /// 註冊Repository的interface與實作的對應關係，
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        //void RegisterRepository<TInterface, TImplement>() where TImplement :class where TInterface :class;   
    }
}
