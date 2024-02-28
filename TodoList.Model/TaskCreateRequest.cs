using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Model.Enums;

namespace TodoList.Model
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // khi khởi tạo, sẽ nhận giá trị mặc định

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public Priority? Priority { get; set; }
    }
}
