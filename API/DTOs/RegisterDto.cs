using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] public string Name { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public decimal Salary { get; set; }
    }
}