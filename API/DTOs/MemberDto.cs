using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
    }
}