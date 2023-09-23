using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class BoxActivity
{
    public Guid LogBoxId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime Time { get; set; }
}
