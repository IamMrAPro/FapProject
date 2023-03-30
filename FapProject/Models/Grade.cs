using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public double? GradeValue { get; set; }

    public int? Weight { get; set; }

    public DateTime? GradeDate { get; set; }

    public string? StudentId { get; set; }

    public string? TeacherId { get; set; }

    public string? SubjectCode { get; set; }

    public int? GradeItemId { get; set; }

    public virtual GradeItem? GradeItem { get; set; }

    public virtual ICollection<GradeReport> GradeReports { get; } = new List<GradeReport>();

    public virtual Student? Student { get; set; }

    public virtual Subject? SubjectCodeNavigation { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
