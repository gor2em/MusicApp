using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IDeleteable
    {
         int TotalLikes { get; set; }
         int TotalComments { get; set; }
    }
}
