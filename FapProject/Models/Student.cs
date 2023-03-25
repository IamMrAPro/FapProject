using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Student
{
    public string? StudentId { get; set; }

    public string? StudentName { get; set; }

    public DateTime? StudentDob { get; set; }

    public int? StudentGender { get; set; }

    public string? StudentCitizenId { get; set; }

    public string? StudentPhone { get; set; }

    public string? StudentAddress { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentPassword { get; set; }

    public int? MajorId { get; set; }
}
