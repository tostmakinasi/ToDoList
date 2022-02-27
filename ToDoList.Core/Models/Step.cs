using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Models
{
    public class Step:BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
