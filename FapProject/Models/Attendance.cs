using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Attendance
{
    public int? AttendanceId { get; set; }

    public bool? StudentAttendance { get; set; }

    public string? StudentId { get; set; }

    public string? TeacherId { get; set; }

    public int? SlotId { get; set; }
}
