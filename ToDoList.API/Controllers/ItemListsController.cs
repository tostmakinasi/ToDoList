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
    public class ItemListsController : CustomBaseController
    {
        private readonly IItemListService _service;
        private readonly IMapper _mapper;
        public ItemListsController(IItemListService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithItems()
        {
            var items = await _service.GetAllWithItemsAsync();

            return CreateActionResult(items);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithItemsAndSteps()
        {
            var items = await _service.GetAllWithItemsAndStepsAsync();

            return CreateActionResult(items);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetItemListByIdWithItem(int id)
        {
            var items = await _service.GetItemListByIdWithItemAsync(id);

            return CreateActionResult(items);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetItemListByIdWithItemAndSteps(int id)
        {
            var items = await _service.GetItemListByIdWithItemAndStepsAsync(id);

            return CreateActionResult(items);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itemListsDtos = _mapper.Map<List<ItemListDto>>(await _service.GetAllAsync());

            return CreateActionResult<List<ItemListDto>>(CustomResponseDto<List<ItemListDto>>.Success(200, itemListsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var itemListDto = _mapper.Map<List<ItemListDto>>(await _service.GetByIdAsync(id));

            return CreateActionResult<List<ItemListDto>>(CustomResponseDto<List<ItemListDto>>.Success(200, itemListDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ItemListDto itemListDto)
        {
            var itemList = await _service.AddAsync(_mapper.Map<ItemList>(itemListDto));

            var newItemListDto = _mapper.Map<ItemListDto>(itemList);

            return CreateActionResult<ItemListDto>(CustomResponseDto<ItemListDto>.Success(201, newItemListDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveRange(IEnumerable<ItemListDto> itemListDtos)
        {
            var itemLists = await _service.AddRangeAsync(_mapper.Map<List<ItemList>>(itemListDtos));
            var newItemListDtos = _mapper.Map<List<ItemListDto>>(itemLists);

            return CreateActionResult<List<ItemListDto>>(CustomResponseDto<List<ItemListDto>>.Success(201, newItemListDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemListDto itemListDto)
        {
            await _service.UpdateAsync(_mapper.Map<ItemList>(itemListDto));

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<ItemList>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var itemList = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(itemList);

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
