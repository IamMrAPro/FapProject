using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class ClassStudent
{
    public int ClassStudentId { get; set; }

    public string? StudentId { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
