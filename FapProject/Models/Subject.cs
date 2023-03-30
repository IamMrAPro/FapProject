using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Subject
{
    public string SubjectCode { get; set; } = null!;

    public string? SubjectName { get; set; }

    public int? Credit { get; set; }

    public virtual ICollection<Curriculum> Curricula { get; } = new List<Curriculum>();

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();
}
