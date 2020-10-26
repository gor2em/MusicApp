using Core.Repositories;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IDetailRepository Detail { get; }
        IAccountRepository Account { get; }
        Task CommitAsync();
        void Commit();
    }
}
