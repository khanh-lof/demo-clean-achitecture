using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Command
{
    public Guid CommandId { get; set; }

    public string? CommandType { get; set; }

    public DateTime Time { get; set; }
}
