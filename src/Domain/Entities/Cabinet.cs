using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Cabinet
{
    public Guid CabinetId { get; set; }

    public string? Description { get; set; }

    public Guid CustomerId { get; set; }

    public Guid LocationId { get; set; }

    public int CabinetTypeId { get; set; }

    public Guid ControllerId { get; set; }

    public virtual ICollection<Box> Boxes { get; set; } = new List<Box>();

    public virtual CabinetType CabinetType { get; set; } = null!;

    public virtual Controller Controller { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
