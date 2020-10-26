using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UserDetail : IDeleteable
    {
        public int UserDetailId { get; set; }
        public int UserId { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public int TotalScore { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Music> Musics { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
