using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        // trong Role thì đã có thuộc tính id và name
        [Required]
        [MaxLength(200)]
        public string Description {  get; set; }
    }
}
