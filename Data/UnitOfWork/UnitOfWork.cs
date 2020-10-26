using Core.Repositories;
using Core.Service;
using Core.UnitOfWork;
using Data.Repositories;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly zumuziDbContext _context;
        private CategoryRepository _categoryRepository;
        private DetailRepository _detailRepository;
        private AccountRepository _accountRepository;
        public UnitOfWork(zumuziDbContext context)
        {
            _context = context;
        }

        public IAccountRepository Account => _accountRepository = _accountRepository ?? new AccountRepository(_context);
        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public IDetailRepository Detail => _detailRepository = _detailRepository ?? new DetailRepository(_context);


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
