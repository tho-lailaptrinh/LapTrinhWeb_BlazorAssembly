using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorAssembly.Service
{
    public interface IUsersService
    {
        Task<List<AssigneeDto>> GetAssignee();
    }
}
