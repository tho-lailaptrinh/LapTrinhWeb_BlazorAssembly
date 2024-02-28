using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Model.Enums;

namespace TodoList.Api.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        [ForeignKey(name: "AssigneeId")]    
        public AppUser Assigness { get; set; }
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
