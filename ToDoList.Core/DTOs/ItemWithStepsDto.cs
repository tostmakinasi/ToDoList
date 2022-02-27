using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class ItemWithStepsDto : ItemDto
    {
        public ICollection<StepDto> Steps { get; set; }
    }
}
