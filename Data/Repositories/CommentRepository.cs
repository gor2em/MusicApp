using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
        }
        private zumuziDbContext _zumuziDbContext
        {
            get => _context as zumuziDbContext;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByMusicId(int id)
        {
            return await _zumuziDbContext.Comments.Include(c=>c.UserDetail.User).Where(x => x.MusicId == id).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetLast5Comments()
        {
            return await _zumuziDbContext.Comments.Include(x => x.UserDetail.User).OrderByDescending(o => o.CreatedOn).Take(5).ToListAsync();
        }
    }
}
