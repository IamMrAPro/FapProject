using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Teacher
{
    public string? TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public DateTime? TeacherDob { get; set; }

    public int? TeacherGender { get; set; }

    public string? TeacherEmail { get; set; }

    public string? TeacherPhone { get; set; }

    public int? EducationLevelId { get; set; }

    public int? Salary { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? DismissedDate { get; set; }
}
