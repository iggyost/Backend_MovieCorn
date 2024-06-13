using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Cover
{
    public int CoverId { get; set; }

    public string CoverPath { get; set; } = null!;

    public virtual ICollection<MoviesCover> MoviesCovers { get; set; } = new List<MoviesCover>();
}
