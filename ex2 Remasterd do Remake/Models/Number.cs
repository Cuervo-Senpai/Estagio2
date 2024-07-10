using System;
using System.Collections.Generic;

namespace ex2_Remasterd_do_Remake.Models;

public partial class Number
{
    public int Id { get; set; }

    public int? NumberKey { get; set; }

    public int? Number1 { get; set; }

    public int? Number2 { get; set; }

    public int? Number3 { get; set; }

    public int? Number4 { get; set; }

    public int? Number5 { get; set; }

    public virtual Results? NumberKeyNavigation { get; set; }
}
