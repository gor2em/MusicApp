using Core.Entities;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetailService : Service<UserDetail>, IDetailService
    {
        public DetailService(IRepository<UserDetail> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        
    }
}
