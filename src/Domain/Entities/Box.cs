using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Box
{
    public Guid BoxId { get; set; }

    public bool Status { get; set; }

    public string? HashCode { get; set; }
}
