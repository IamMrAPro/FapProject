﻿using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Major
{
    public int MajorId { get; set; }

    public string? MajorName { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
