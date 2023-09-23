using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetManagement.Application.IO.CreateCabinetType;
using FluentValidation;

namespace CabinetManagement.Application.Handlers.CreateCabinetType;
public class CreateCabinetTypeValidator : AbstractValidator<CreateCabinetTypeCommand>
{
    public CreateCabinetTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(9);
    }
}
