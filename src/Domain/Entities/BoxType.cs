using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class BoxType
{
    public int BoxTypeId { get; set; }

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    public decimal Depth { get; set; }

    public virtual ICollection<Box> Boxes { get; set; } = new List<Box>();
}
