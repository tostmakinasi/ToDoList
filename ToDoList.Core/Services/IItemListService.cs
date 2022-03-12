using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;
using ToDoList.Core.Models;

namespace ToDoList.Core.Services
{
    public interface IItemListService:IService<ItemList>
    {
        Task<CustomResponseDto<List<ItemListWithItemsDto>>> GetAllWithItemsAsync();

        Task<CustomResponseDto<List<ItemListWithItemsAndItemsStepsDto>>> GetAllWithItemsAndStepsAsync();

        Task<CustomResponseDto<ItemListWithItemsDto>> GetItemListByIdWithItemAsync(int id);

        Task<CustomResponseDto<ItemListWithItemsAndItemsStepsDto>> GetItemListByIdWithItemAndStepsAsync(int id);
    }
}
