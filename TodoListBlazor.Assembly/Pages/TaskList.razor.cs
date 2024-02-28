using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
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
        [Inject] private IToastService toastService { get; set; }

        private List<TaskDTO> taskDTOs;

        // Khai báo và khởi tạo giá trị cho from
        private TaskListSearch TaskListSearches  = new TaskListSearch();

        // Khai báo danh sách AssigneeId 
        private List<AssigneeDto> Assignees;
        protected override async Task OnInitializedAsync()  
        {
            taskDTOs = await taskAPIClient.GetTaskList(TaskListSearches);
            Assignees = await usersService.GetAssignee();
        }
        private async Task SearchForm(EditContext context)
        {
            toastService.ShowInfo("Search completed","Info");
            taskDTOs = await taskAPIClient.GetTaskList(TaskListSearches);
        }
        // Tạo Model search cho From
       
    }
}
