using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; } = new List<Town>();
}
