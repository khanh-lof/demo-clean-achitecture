using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CabinetManagement.Application.IO.CreateCabinetType;
public class CreateCabinetTypeCommand : IRequest<CreateCabinetTypeResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
