using Core.Entities;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ILikeRepository:IRepository<Like>
    {
        Task<bool> LikeControl(int userId,int musicId);

    }
}
