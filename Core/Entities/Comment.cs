using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int MusicId { get; set; }
        public int UserDetailId { get; set; }

        [Required(ErrorMessage ="zorunlu alan")]
        [Display(Name ="Content")]
        public string CommentContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Music Music { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
