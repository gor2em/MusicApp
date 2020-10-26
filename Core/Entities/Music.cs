using Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Music: IDeleteable
    {

        public int MusicId { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "minimum 5, maksimum 100 karakter olmalı")]
        [Required(ErrorMessage = "Müzik ismi boş geçilemez!")]
        public string MusicName { get; set; }
        [StringLength(500, ErrorMessage = "Maksimum 500 karakter olmalı")]
        [Required(ErrorMessage = "Açıklama boş geçilemez!")]
        public string MusicDescription{ get; set; }
        [StringLength(500, ErrorMessage = "Maksimum 500 karakter olmalı")]
        [Required(ErrorMessage = "Link boş geçilemez!")]
        public string MusicLink { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public int UserDetailId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

    }
}
