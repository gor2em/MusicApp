using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDetailRepository:IRepository<UserDetail>
    {
        Task<IEnumerable<UserDetail>> GetTopUsers();
        int GiveRandomScore(int number=0);
    }
}
