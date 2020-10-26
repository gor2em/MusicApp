using Core.Entities;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class CommentService : Service<Comment>,ICommentService
    {
        public CommentService(IRepository<Comment> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
