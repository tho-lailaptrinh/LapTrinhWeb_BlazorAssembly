using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorAssembly.Service
{
    public interface ITaskAPIClient
    {
        Task<List<TaskDTO>> GetTaskList();
        Task<TaskDTO> GetTaskDetail(string id);
    }
}
