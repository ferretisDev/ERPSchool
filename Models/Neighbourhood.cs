using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class Neighbourhood
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TownFk { get; set; }

    public virtual ICollection<School> Schools { get; } = new List<School>();

    public virtual Town? TownFkNavigation { get; set; }
}
