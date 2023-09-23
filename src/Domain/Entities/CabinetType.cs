using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class CabinetType
{
    public int CabinetTypeId { get; set; }

    public string? TypeName { get; set; }

    public string? Description { get; set; }
}
