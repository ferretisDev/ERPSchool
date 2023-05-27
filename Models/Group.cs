using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MaxStudents { get; set; }

    public int SchoolFk { get; set; }

    public virtual School SchoolFkNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
