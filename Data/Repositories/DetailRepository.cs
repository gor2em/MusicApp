using Core.Entities;
using Core.Repositories;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DetailRepository : Repository<UserDetail>, IDetailRepository
    {

        public DetailRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
        }

        private zumuziDbContext _zumuziDbContext
        {
            get => _context as zumuziDbContext;
        }

        public async Task<IEnumerable<UserDetail>> GetTopUsers()
        {
            return await _zumuziDbContext.UserDetails.Include(x => x.Role).Include(x=>x.User).OrderByDescending(x => x.TotalScore).Take(6).ToListAsync();
        }

        public int GiveRandomScore(int number)
        {
            var random = new Random();
            if (number == 0)//comment&like
            {
                number = random.Next(2, 11);
            }
            else if (number == 1)//add music
            {
                number = random.Next(10, 81);
            }
            else//dislike
            {
                number = -10;
            }
            return number;
        }
    }
}
