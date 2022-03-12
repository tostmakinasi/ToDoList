using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;
using ToDoList.Core.Models;

namespace ToDoList.Core.Services
{
    public interface IItemService:IService<Item>
    {
        Task<CustomResponseDto<List<ItemWithStepsDto>>> GetAllItemsWithStepsAsync();

        Task<CustomResponseDto<ItemWithStepsDto>> GetItemWithSteps(int id);
    }
}
