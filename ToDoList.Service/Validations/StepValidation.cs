using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;

namespace ToDoList.Service.Validations
{
    public class StepValidation:AbstractValidator<StepDto>
    {
        
        public StepValidation()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage(ValidatorDefaultMessages.RequiredMessage);
            RuleFor(x=> x.ItemId).InclusiveBetween(0,int.MaxValue).WithMessage(ValidatorDefaultMessages.MustGreaterMessage);
            RuleFor(x=> x.Status).NotNull().WithMessage(ValidatorDefaultMessages.NotNullMessage);
        }
    }
}
