using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Location
{
    public Guid LocationId { get; set; }

    public string? LocationDetail { get; set; }

    public int WardId { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();

    public virtual ICollection<Controller> Controllers { get; set; } = new List<Controller>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Ward Ward { get; set; } = null!;
}
