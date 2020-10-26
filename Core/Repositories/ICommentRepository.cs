using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByMusicId(int id);
        Task<IEnumerable<Comment>> GetLast5Comments();
    }
}
