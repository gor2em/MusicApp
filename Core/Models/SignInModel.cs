using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "şifre boş geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
