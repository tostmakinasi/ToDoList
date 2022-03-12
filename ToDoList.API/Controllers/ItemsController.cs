using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Filters;
using ToDoList.Core.DTOs;
using ToDoList.Core.Models;
using ToDoList.Core.Services;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : CustomBaseController
    {
        private readonly IItemService _service;
        private readonly IMapper _mapper;

        public ItemsController(IMapper mapper, IItemService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            var itemDtos = _mapper.Map<IEnumerable<ItemDto>>(items);

            return CreateActionResult<IEnumerable<ItemDto>>(CustomResponseDto<IEnumerable<ItemDto>>.Success(200, itemDtos));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithSteps()
        {
            var items = await _service.GetAllItemsWithStepsAsync();

            return CreateActionResult(items);
        }
        [ServiceFilter(typeof(NotFoundFilter<Item>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetItemByIdWithSteps(int id)
        {
            var items = await _service.GetItemWithSteps(id);

            return CreateActionResult(items);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ItemDto itemDto)
        {
            var item = await _service.AddAsync(_mapper.Map<Item>(itemDto));

            var nemItemDto = _mapper.Map<ItemDto>(item);

            return CreateActionResult<ItemDto>(CustomResponseDto<ItemDto>.Success(201, nemItemDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveRange(IEnumerable<ItemDto> itemDtos)
        {
            var items = await _service.AddRangeAsync(_mapper.Map<IEnumerable<Item>>(itemDtos));
            var newItemDtos = _mapper.Map<List<ItemDto>>(items);

            return CreateActionResult<List<ItemDto>>(CustomResponseDto<List<ItemDto>>.Success(201, newItemDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemDto itemDto)
        {
            await _service.UpdateAsync(_mapper.Map<Item>(itemDto));

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Step>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(item);

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
