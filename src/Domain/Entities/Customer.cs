using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }
}
