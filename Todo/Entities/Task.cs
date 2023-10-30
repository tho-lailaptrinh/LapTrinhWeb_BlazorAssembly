using TodoList.Api.Enums;

namespace TodoList.Api.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? Assignee { get; set; }
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
