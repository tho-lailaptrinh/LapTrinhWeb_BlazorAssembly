using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorAssembly.Service
{
    public interface ITaskAPIClient
    {
        Task<List<TaskDTO>> GetTaskList(TaskListSearch taskListSearch);
        Task<TaskDTO> GetTaskDetail(string id);
        Task<bool> CreateTask(TaskCreateRequest request);
    }
}
