using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            return Ok(tasks);
        }
        // api/task/xxxx
        [HttpGet(template: "{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tasks = await _taskRepository.GetById(id);
            if (tasks == null) return NotFound($"{id} is not found");
            return Ok(tasks);
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
        public async Task<IActionResult> Update(Guid id, Entities.Task task)
        {
            // Nếu dữ liệu gửi lên Post không hợp lệ sẽ trả về lỗi BadRequest
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //
            var taskFromDb = await _taskRepository.GetById(id);
            // check null
            if (taskFromDb == null) return NotFound($"{id} is not found");
            // Chỉ update name
            taskFromDb.Name = task.Name;
            var tasks = _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById), tasks);
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
