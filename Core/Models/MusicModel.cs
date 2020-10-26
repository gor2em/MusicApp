using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class MusicModel
    {
        public int MusicId { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "minimum 5, maksimum 100 karakter olmalı")]
        [Required(ErrorMessage = "Müzik ismi boş geçilemez!")]
        public string MusicName { get; set; }

        [StringLength(500, ErrorMessage = "Maksimum 500 karakter olmalı")]
        [Required(ErrorMessage = "Açıklama boş geçilemez!")]
        public string MusicDescription { get; set; }

        [StringLength(500, ErrorMessage = "Maksimum 500 karakter olmalı")]
        [Required(ErrorMessage = "Link boş geçilemez!")]
        public string MusicLink { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public int UserDetailId { get; set; }

    }
}
