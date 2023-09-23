using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Location
{
    public Guid LocationId { get; set; }

    public string? LocationDetail { get; set; }
}
