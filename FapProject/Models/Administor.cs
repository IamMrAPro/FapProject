using System;
using System.Collections.Generic;

namespace FapProject.Models;

public partial class Administor
{
    public int AdministorId { get; set; }

    public string? AdministorName { get; set; }

    public DateTime? AdministorDob { get; set; }

    public int? AdministorGender { get; set; }
}
