using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<TaskDTO> GetTaskDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDTO>($"/api/task/{id}");
            return result;
        }

        public async Task<List<TaskDTO>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>("/api/task");
            return result;
        }
    }
}
