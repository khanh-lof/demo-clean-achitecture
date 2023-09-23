using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetManagement.Application.IO.Test;
using FluentValidation;

namespace CabinetManagement.Application.Handlers.Test;
public class TestValidator : AbstractValidator<TestRequest>
{
    public TestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(9);
    }
}
