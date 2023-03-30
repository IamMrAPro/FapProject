using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class GradeItem
{
    public int GradeItemId { get; set; }

    public string? GradeItemName { get; set; }

    public int? GradeCategoryId { get; set; }

    public virtual GradeCategory? GradeCategory { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();
}
