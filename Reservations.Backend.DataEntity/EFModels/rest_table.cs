using System;
using System.Collections.Generic;

namespace Reservations.Backend.DataEntity.EFModels;

public partial class rest_table
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<rest_reservation> rest_reservation { get; set; } = new List<rest_reservation>();
}
