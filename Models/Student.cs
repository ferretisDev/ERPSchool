using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int SexFk { get; set; }

    public int GroupFk { get; set; }

    public virtual Group GroupFkNavigation { get; set; } = null!;

    public virtual Sex SexFkNavigation { get; set; } = null!;
}
