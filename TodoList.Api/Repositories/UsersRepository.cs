using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Data;
using TodoList.Api.Entities;
using TodoList.Model;

namespace TodoList.Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TodoListDbContext _context;
        public UsersRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
