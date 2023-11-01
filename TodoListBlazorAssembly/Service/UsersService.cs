using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoList.Model;

namespace TodoListBlazorAssembly.Service
{
    public class UsersService : IUsersService
    {
        protected HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<AssigneeDto>> GetAssignee()
        {
            var result = _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/users");
            return result;
        }
    }
}
