using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorAssembly.Service
{
    public class TaskAPIClient : ITaskAPIClient
    {
        public HttpClient _httpClient;

        public TaskAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/task", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<TaskDTO> GetTaskDetail(string id)
        {
            // đẩy http dạng Get lên - đẩy json lên và truyền vào url
            var result = await _httpClient.GetFromJsonAsync<TaskDTO>($"/api/task/{id}");
            return result;
        }

        public async Task<List<TaskDTO>> GetTaskList(TaskListSearch taskListSearch)
        {
            string url = $"/api/task?name={taskListSearch.Name}&/assigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>(url);
            return result;
        }

        
    }
}
