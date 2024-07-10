using System;
using System.Collections.Generic;

namespace ex2_Remasterd_do_Remake.Models;

public partial class Star
{
    public int Id { get; set; }

    public int? NumberKey { get; set; }

    public int? Star1 { get; set; }

    public int? Star2 { get; set; }

    public virtual Results? NumberKeyNavigation { get; set; }
}
