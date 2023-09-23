using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Ward
{
    public int WardId { get; set; }

    public string? WardName { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
