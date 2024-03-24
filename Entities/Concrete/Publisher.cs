﻿using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Publisher:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
