using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class School
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? StreetName { get; set; }

    public string? Number { get; set; }

    public int? NeighborhoodFk { get; set; }

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    public virtual Neighbourhood? NeighborhoodFkNavigation { get; set; }
}
