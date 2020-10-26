using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IService<T> where T : class
    {
        //crud
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
