using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class ItemListWithItemsAndItemsStepsDto:ItemListDto
    {
        public ICollection<ItemWithStepsDto> Items { get; set; }
    }
}
