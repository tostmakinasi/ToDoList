using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;

namespace ToDoList.Service.Validations
{
    public class ItemValidator:AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage(ValidatorDefaultMessages.RequiredMessage);
            RuleFor(x => x.ItemListId).InclusiveBetween(0, int.MaxValue).WithMessage(ValidatorDefaultMessages.MustGreaterMessage);
            RuleFor(x=> x.EndDate).GreaterThanOrEqualTo(x=> x.StartingDate).WithMessage(x=> $"{nameof(x.EndDate)} must greater or equal than {nameof(x.StartingDate)}");
            RuleFor(x => x.Status).NotNull().WithMessage(ValidatorDefaultMessages.NotNullMessage);
        }
    }
}
