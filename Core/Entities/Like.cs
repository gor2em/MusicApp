using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MusicId { get; set; }
        public  User User { get; set; }
        public virtual  Music Music { get; set; }
    }
}
