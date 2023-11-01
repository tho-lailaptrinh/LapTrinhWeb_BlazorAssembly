using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Repositories;
using TodoList.Model;
using TodoList.Model.Enums;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTaskList();
            var taskDto = tasks.Select(x => new TaskDTO()
            {
                Id = x.Id,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreateDate = x.CreateDate,
                Priority = x.Priority,
                Status = x.Status,
                AssigneeName = x.Assigness != null ? x.Assigness.FirstName + ' ' + x.Assigness.LastName : "N/A"
            });
            return Ok(taskDto);                                                               
        }
        // api/task/xxxx
        [HttpGet(template: "{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var tasks = await _taskRepository.GetById(id);
            if (tasks == null) return NotFound($"{id} is not found");
            return Ok(new TaskDTO()
            {
                Id = tasks.Id,
                Name = tasks.Name,
                AssigneeId = tasks.AssigneeId,
                CreateDate = tasks.CreateDate,
                Priority = tasks.Priority,
                Status = tasks.Status,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            // Nếu dữ liệu gửi lên Post không hợp lệ sẽ trả về lỗi BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // hợp lệ sẽ tạo ra task
            var tasks = await _taskRepository.Create(new Entities.Task()
            {
                Id = request.Id,
                Name = request.Name,
                Priority = request.Priority,
                CreateDate = DateTime.Now,
                Status = Status.Open
            });
            return CreatedAtAction(nameof(GetById), tasks);
        }

        [HttpPut] 
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskUpdateRequest request)
        {
            // Nếu dữ liệu gửi lên Post không hợp lệ sẽ trả về lỗi BadRequest
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //
            var taskFromDb = await _taskRepository.GetById(id);
            // check null
            if (taskFromDb == null) return NotFound($"{id} is not found");
            // Chỉ update name
            taskFromDb.Name = request.Name;
            taskFromDb.Priority = request.Priority;
            var taskResult = await _taskRepository.Update(taskFromDb);
            return Ok(new TaskDTO()
            {
                Id = taskResult.Id,
                Name = taskResult.Name,
                Priority = taskResult.Priority,
                Status = taskResult.Status,
                AssigneeId = taskResult.AssigneeId,
                CreateDate = taskResult.CreateDate
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,Entities.Task task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tasks = _taskRepository.Delete(task);
            return Ok(tasks);
        }
    }
}
