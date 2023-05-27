using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class Sex
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
