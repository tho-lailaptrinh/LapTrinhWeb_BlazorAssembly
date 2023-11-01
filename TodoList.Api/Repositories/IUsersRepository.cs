using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Entities;
using TodoList.Model;

namespace TodoList.Api.Repositories
{
    public interface IUsersRepository
    {
        Task<List<AppUser>> GetUserList();
    }
}
