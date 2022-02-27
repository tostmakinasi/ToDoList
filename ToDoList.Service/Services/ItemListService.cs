using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;
using ToDoList.Core.Models;
using ToDoList.Core.Repositories;
using ToDoList.Core.Services;
using ToDoList.Core.UnitOfWorks;

namespace ToDoList.Service.Services
{
    public class ItemListService : Service<ItemList>, IItemListService
    {
        private readonly IItemListRepository _repository;
        private readonly IMapper _mapper;

        public ItemListService(IUnitOfWork unitOfWork, IItemListRepository repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ItemListWithItemsAndItemsStepsDto>> GetAllWithItemsAndStepsAsync()
        {
            var itemList = await _repository.GetAllWithItemsAndStepsAsync();
            var itemListWithItemsAndSteps = _mapper.Map<List<ItemListWithItemsAndItemsStepsDto>>(itemList);

            return itemListWithItemsAndSteps;
        }

        public async Task<List<ItemListWithItemsDto>> GetAllWithItemsAsync()
        {
            var itemList = await _repository.GetAllWithItemsAsync();
            var itemListWithItems = _mapper.Map<List<ItemListWithItemsDto>>(itemList);

            return itemListWithItems;
        }

        public async Task<ItemListWithItemsAndItemsStepsDto> GetItemListByIdWithItemAndStepsAsync(int id)
        {
            var itemList = await _repository.GetItemListByIdWithItemAndStepsAsync(id);
            var itemListWithItemsAndSteps = _mapper.Map<ItemListWithItemsAndItemsStepsDto>(itemList);

            return itemListWithItemsAndSteps;
        }

        public async Task<ItemListWithItemsDto> GetItemListByIdWithItemAsync(int id)
        {
            var itemList = await _repository.GetItemListByIdWithItemAsync(id);
            var itemListWithItems = _mapper.Map<ItemListWithItemsDto>(itemList);

            return itemListWithItems;
        }
    }
}
