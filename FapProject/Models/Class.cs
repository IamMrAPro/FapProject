using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? Classroom { get; set; }

    public string? GoogleMeetLink { get; set; }

    public string? TeacherId { get; set; }

    public int? SemesterId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<ClassStudent> ClassStudents { get; } = new List<ClassStudent>();

    public virtual Semester? Semester { get; set; }

    public virtual ICollection<Slot> Slots { get; } = new List<Slot>();

    public virtual Teacher? Teacher { get; set; }
}
