using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Controller
{
    public Guid ControllerId { get; set; }

    public string? Ipaddress { get; set; }
}
