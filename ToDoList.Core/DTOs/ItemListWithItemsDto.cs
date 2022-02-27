using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class ItemListWithItemsDto:ItemListDto
    {
        public ICollection<ItemDto> Items { get; set; }
    }
}
