using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Curriculum
{
    public int CurriculumId { get; set; }

    public string? SubjectCode { get; set; }

    public string? StudentId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? SubjectCodeNavigation { get; set; }
}
