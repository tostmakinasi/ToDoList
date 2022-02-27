using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class StepDto:BaseEntityDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public int ItemId { get; set; }
    }
}
