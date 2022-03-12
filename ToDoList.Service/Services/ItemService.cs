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
    public class ItemService : Service<Item>, IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;
        public ItemService(IUnitOfWork unitOfWork, IItemRepository repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ItemWithStepsDto>>> GetAllItemsWithStepsAsync()
        {
            var items = await _repository.GetAllItemsWithStepsAsync();
            
            var itemsWithSteps = _mapper.Map<List<ItemWithStepsDto>>(items);
            return CustomResponseDto<List<ItemWithStepsDto>>.Success(200, itemsWithSteps);

        }

        public async Task<CustomResponseDto<ItemWithStepsDto>> GetItemWithSteps(int id)
        {
            var item = await _repository.GetItemWithSteps(id);

            var itemWithSteps = _mapper.Map<ItemWithStepsDto>(item);

            return CustomResponseDto<ItemWithStepsDto>.Success(200, itemWithSteps);
        }
    }
}
