using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Cabinet
{
    public Guid CabinetId { get; set; }

    public string? Description { get; set; }
}
