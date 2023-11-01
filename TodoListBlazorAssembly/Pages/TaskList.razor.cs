using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TodoList.Model;
using TodoList.Model.Enums;
using TodoListBlazorAssembly.Service;


namespace TodoListBlazorAssembly.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskAPIClient taskAPIClient { get; set; }
        [Inject] private IUsersService usersService { get; set; }

        private List<TaskDTO> taskDTOs;

        // Khai báo và khởi tạo giá trị cho from
        private TaskListSearch TaskListSearches  = new TaskListSearch();

        // Khai báo danh sách AssigneeId 
        private List<AssigneeDto> Assignees;
        protected override async Task OnInitializedAsync()  
        {
            taskDTOs = await taskAPIClient.GetTaskList();
            Assignees = await usersService.GetAssignee();
        }
        // Tạo Model search cho From
        public class TaskListSearch
        {
            public string Name { get; set; }
            public Guid AssigneeId { get; set; }
            public Priority Priority { get; set; }
        }
    }
}
