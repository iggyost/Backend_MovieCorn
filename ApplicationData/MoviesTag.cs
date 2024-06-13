using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class MoviesTag
{
    public int MovieTagId { get; set; }

    public int MovieId { get; set; }

    public int TagId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
