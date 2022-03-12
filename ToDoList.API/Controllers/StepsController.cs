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
    public class StepsController : CustomBaseController
    {
        private readonly IService<Step> _service;
        private readonly IMapper _mapper;

        public StepsController(IMapper mapper, IService<Step> service)
        {
            _mapper = mapper;
            _service = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stepsDtos = _mapper.Map<List<StepDto>>(await _service.GetAllAsync());

            return CreateActionResult<List<StepDto>>(CustomResponseDto<List<StepDto>>.Success(200,stepsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stepsDtos = _mapper.Map<List<StepDto>>(await _service.GetByIdAsync(id));

            return CreateActionResult<List<StepDto>>(CustomResponseDto<List<StepDto>>.Success(200, stepsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(StepDto stepDto)
        {
            var step = await _service.AddAsync(_mapper.Map<Step>(stepDto));
            
            var newStepDto = _mapper.Map<StepDto>(step);

            return CreateActionResult<StepDto>(CustomResponseDto<StepDto>.Success(201, newStepDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveRange(IEnumerable<StepDto> stepDtos)
        {
            var steps = await _service.AddRangeAsync(_mapper.Map<List<Step>>(stepDtos));
            var newStepDtos = _mapper.Map<List<StepDto>>(steps);

            return CreateActionResult<List<StepDto>>(CustomResponseDto<List<StepDto>>.Success(201,newStepDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(StepDto stepDto)
        {
            await _service.UpdateAsync(_mapper.Map<Step>(stepDto));

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Step>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var step = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(step);

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
