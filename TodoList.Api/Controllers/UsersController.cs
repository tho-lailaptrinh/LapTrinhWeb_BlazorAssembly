using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Repositories;
using TodoList.Model;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _usersRepository.GetUserList();
            var assignee = users.Select(x => new AssigneeDto()
            {
                Id = x.Id,
                FullName = x.FirstName+" "+ x.LastName
            });
            return Ok(assignee);
        }
    }
}
