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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly zumuziDbContext _zumuziDbContext = null;

        public CategoryRepository(zumuziDbContext zumuziDbContext) : base(zumuziDbContext)
        {
            _zumuziDbContext = zumuziDbContext;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _zumuziDbContext.Categories.Select(x => new CategoryModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToListAsync();
        }
    }
}
