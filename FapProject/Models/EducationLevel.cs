using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class EducationLevel
{
    public int EducationLevelId { get; set; }

    public string? EducationLevelTitle { get; set; }

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
