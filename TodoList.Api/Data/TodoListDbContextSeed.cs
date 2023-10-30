using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Entities;
using TodoList.Model.Enums;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<AppUser> _passwordHasher = new PasswordHasher<AppUser>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(entity: new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same Task 1",
                    CreateDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                }) ;
            }

            if (!context.Users.Any())
            {
                var user = new Entities.AppUser()
                {
                    Id= Guid.NewGuid(),
                    FirstName = "Mr.",
                    LastName = "Tho",
                    Email = "thovvph31698@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName ="Admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, password: "Thocuong196@");
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
