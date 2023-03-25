using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class GradeReport
{
    public int? GradeReportId { get; set; }

    public int? GradeId { get; set; }

    public double? AverageGrade { get; set; }

    public string? Comment { get; set; }

    public string? Status { get; set; }
}
