using System;
using System.Collections.Generic;

namespace Reservations.Backend.DataEntity.EFModels;

public partial class rest_shift
{
    public int Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int DayOfWeek { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<rest_reservation> rest_reservation { get; set; } = new List<rest_reservation>();
}
