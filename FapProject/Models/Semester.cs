using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Semester
{
    public int? SemesterId { get; set; }

    public string? SemesterName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
