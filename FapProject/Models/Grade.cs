using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Grade
{
    public int? GradeId { get; set; }

    public double? GradeValue { get; set; }

    public int? Weight { get; set; }

    public DateTime? GradeDate { get; set; }

    public string? StudentId { get; set; }

    public string? TeacherId { get; set; }

    public string? SubjectCode { get; set; }

    public int? GradeItemId { get; set; }
}
