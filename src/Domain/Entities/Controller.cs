using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Controller
{
    public Guid ControllerId { get; set; }

    public string? Ipaddress { get; set; }

    public Guid LocationId { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();

    public virtual ICollection<Command> Commands { get; set; } = new List<Command>();

    public virtual Location Location { get; set; } = null!;
}
