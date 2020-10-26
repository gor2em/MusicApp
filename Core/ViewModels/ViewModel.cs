using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class ViewModel 
    {
        public Music Music { get; set; }
        public IEnumerable<Music> LastMusics { get; set; }
        public IEnumerable<Music> PopularMusics { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public User User { get; set; }
        public UserDetail UserDetail { get; set; }
        public IEnumerable<UserDetail> UserDetails { get; set; }
    }
}
