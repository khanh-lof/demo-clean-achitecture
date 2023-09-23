using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CabinetManagement.Application.IO.Test;
public class TestRequest : IRequest<TestResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
