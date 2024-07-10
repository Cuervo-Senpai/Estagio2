using System;
using System.Collections.Generic;

namespace ex2_Remasterd_do_Remake.Models;

public partial class Results
{
    public int NumberKey { get; set; }

    public DateTime? Date { get; set; }

    public int? Winner { get; set; }

    public long? Gain { get; set; }

    public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();

    public virtual ICollection<Star> Stars { get; set; } = new List<Star>();
}
