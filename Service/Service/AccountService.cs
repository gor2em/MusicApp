
using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : Service<User>, IAccountService
    {
        
        public AccountService(IRepository<User> repository, IUnitOfWork unitOfWork,SignInModel signInModel) : base(repository, unitOfWork)
        {
        }



    }
}
