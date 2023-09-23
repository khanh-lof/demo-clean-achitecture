using System;
using System.Collections.Generic;

namespace CabinetManagement.Domain.Entities;

public partial class Box
{
    public Guid BoxId { get; set; }

    public bool Status { get; set; }

    public string? HashCode { get; set; }

    public Guid CabinetId { get; set; }

    public int BoxTypeId { get; set; }

    public virtual ICollection<BoxActivity> BoxActivities { get; set; } = new List<BoxActivity>();

    public virtual BoxType BoxType { get; set; } = null!;

    public virtual Cabinet Cabinet { get; set; } = null!;
}
