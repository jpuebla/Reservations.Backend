using System;
using System.Collections.Generic;

namespace Reservations.Backend.DataEntity.EFModels;

public partial class rest_reservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TableId { get; set; }

    public int ShiftId { get; set; }

    public DateOnly Date { get; set; }

    public int People { get; set; }

    public virtual rest_shift Shift { get; set; } = null!;

    public virtual rest_table Table { get; set; } = null!;
}
