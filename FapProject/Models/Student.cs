using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? StudentName { get; set; }

    public DateTime? StudentDob { get; set; }

    public int? StudentGender { get; set; }

    public string? StudentCitizenId { get; set; }

    public string? StudentPhone { get; set; }

    public string? StudentAddress { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentPassword { get; set; }

    public int? MajorId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual ICollection<ClassStudent> ClassStudents { get; } = new List<ClassStudent>();

    public virtual ICollection<Curriculum> Curricula { get; } = new List<Curriculum>();

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Major? Major { get; set; }
}
