using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;
using ToDoList.Core.Models;

namespace ToDoList.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Item,ItemDto>().ReverseMap();
            CreateMap<Item, ItemWithStepsDto>();
            CreateMap<ItemUpdateDto, Item>();

            CreateMap<Step,StepDto>().ReverseMap();

            CreateMap<ItemList, ItemListDto>().ReverseMap();
            CreateMap<ItemList, ItemListWithItemsDto>();
            CreateMap<ItemList, ItemListWithItemsAndItemsStepsDto>();
        }
    }
}
