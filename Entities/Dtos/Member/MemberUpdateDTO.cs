﻿namespace Entities.Dtos.Member
{
    public class MemberUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TCKNO { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
