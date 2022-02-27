using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class ItemDto:BaseEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
        public int ItemListId { get; set; }
    }
}
