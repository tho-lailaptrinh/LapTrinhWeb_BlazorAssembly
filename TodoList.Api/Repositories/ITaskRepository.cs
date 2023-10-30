using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Entities;
using TodoList.Model;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDTO>> GetTaskList();
        Task<Task> GetById(Guid id);
        Task<Task> Create(Task task);
        Task<Task> Update(Task task);
        Task<Task> Delete(Task task);
    }
}
