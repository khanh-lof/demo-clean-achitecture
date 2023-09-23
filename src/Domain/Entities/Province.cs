using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Province
{
    public int ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
