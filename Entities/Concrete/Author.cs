using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //public string Image { get; set; }
    }
}
