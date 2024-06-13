using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class MoviesCover
{
    public int MovieCoverId { get; set; }

    public int MovieId { get; set; }

    public int CoverId { get; set; }

    public virtual Cover Cover { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
