using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;

namespace ToDoList.Service.Validations
{
    public class ItemListValidator:AbstractValidator<ItemListDto>
    {
        public ItemListValidator()
        {
                RuleFor(x=> x.Title).NotNull().NotEmpty().WithMessage(ValidatorDefaultMessages.RequiredMessage);
        }
    }
}
