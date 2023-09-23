using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class District
{
    public int DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public int ProvinceId { get; set; }

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
