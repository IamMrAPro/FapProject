using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? Length { get; set; }

    public int? ClassId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual Class? Class { get; set; }
}
