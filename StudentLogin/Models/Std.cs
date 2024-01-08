using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentLogin.Models
{
    public partial class Std
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        [Required]  
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public decimal Phone { get; set; }
        [Required]
        public string Department { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
