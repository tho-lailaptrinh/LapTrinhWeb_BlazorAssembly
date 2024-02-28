using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Model.Enums;

namespace TodoList.Model
{
    public class TaskListSearch
    {
            public string Name { get; set; }
            public Guid? AssigneeId { get; set; }
            public Priority? Priority { get; set; }
    }
}
