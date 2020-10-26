using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> SignInAsync(User user);
        Task SignOutAsync();
    }
}
