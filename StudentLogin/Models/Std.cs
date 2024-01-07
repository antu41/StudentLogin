using System;
using System.Collections.Generic;

namespace StudentLogin.Models
{
    public partial class Std
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Email { get; set; } = null!;
        public decimal Phone { get; set; }
        public string Department { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
