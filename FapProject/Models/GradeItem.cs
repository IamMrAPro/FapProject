using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class GradeItem
{
    public int? GradeItemId { get; set; }

    public string? GradeItemName { get; set; }

    public int? GradeCategoryId { get; set; }
}
