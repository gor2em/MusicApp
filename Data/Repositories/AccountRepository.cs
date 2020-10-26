using Core.Entities;
using Core.Models;
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
    public class AccountRepository : Repository<User>, IAccountRepository
    {
     
        private zumuziDbContext _zumuziDbContext
        {
            get => _context as zumuziDbContext;
        }

        public AccountRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
        }

        public  async Task<User> SignInAsync(User user)
        {
            var model = await _zumuziDbContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            return model;
            
        }

        public async Task SignOutAsync()
        {
          
        }


    }
}
