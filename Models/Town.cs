using System;
using System.Collections.Generic;

namespace ERPSchool.Models;

public partial class Town
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? StatesFk { get; set; }

    public virtual ICollection<Neighbourhood> Neighbourhoods { get; } = new List<Neighbourhood>();

    public virtual State? StatesFkNavigation { get; set; }
}
