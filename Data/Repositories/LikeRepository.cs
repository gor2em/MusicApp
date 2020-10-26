using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        private zumuziDbContext _zumuziDbContext
        {
            get => _context as zumuziDbContext;
        }
        public LikeRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
        }

        public async Task<bool> LikeControl(int userId, int musicId)
        {
            var control = await _zumuziDbContext.Likes.AnyAsync(x => x.UserId == userId && x.MusicId == musicId);
            if (control)
                return true;
            else
                return false;
        }
    }
}
