using Core.Entities;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MusicService : Service<Music>, IMusicService
    {
        public MusicService(IRepository<Music> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

    
    }
}
