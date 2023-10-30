using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength (200)]
        public string LastName { get; set; }

    }
}
