using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfaceLibrary
{
    public interface IUnitOfWorkTransaction : IUnitOfWork
    {
        IDbTransaction Transaction { get; }
    }
}
