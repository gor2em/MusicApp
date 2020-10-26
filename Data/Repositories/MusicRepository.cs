using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.UnitOfWork;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
        }

        private zumuziDbContext _zumuziDbContext
        {
            get => _context as zumuziDbContext;
        }

        public async Task<Music> GetDetailsById(int id)
        {
            return await _zumuziDbContext.Musics.Include(x => x.Category).Include(c => c.UserDetail.User).Include(r=>r.UserDetail.Role).FirstOrDefaultAsync(x => x.MusicId == id);
        }

        public async Task<IEnumerable<Music>> GetLast5()
        {
            return await _zumuziDbContext.Musics.Include(c => c.Category).Include(d => d.UserDetail.User).OrderByDescending(c => c.MusicId).Take(4).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetPopularMusics()
        {
            return await _zumuziDbContext.Musics.OrderByDescending(x => x.TotalLikes).Take(4).ToListAsync();
        }
    }
}
