using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class GradeCategory
{
    public int GradeCategoryId { get; set; }

    public string? GradeCategoryName { get; set; }

    public string? SubjectCode { get; set; }

    public virtual ICollection<GradeItem> GradeItems { get; } = new List<GradeItem>();
}
