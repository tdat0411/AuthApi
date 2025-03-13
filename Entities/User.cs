using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}