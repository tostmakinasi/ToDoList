using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Models
{
    public class ItemList:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
