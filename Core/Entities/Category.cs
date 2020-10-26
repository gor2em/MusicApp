using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Entities
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
