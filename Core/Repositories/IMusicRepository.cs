using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<Music> GetDetailsById(int id);
        Task<IEnumerable<Music>> GetLast5();
        Task<IEnumerable<Music>> GetPopularMusics();


    }
}
