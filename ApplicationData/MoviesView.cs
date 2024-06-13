using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class MoviesView
{
    public int MovieCoverId { get; set; }

    public int MovieTagId { get; set; }

    public int MovieId { get; set; }

    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public string Tag { get; set; } = null!;

    public int ProduceYear { get; set; }

    public string Country { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public int Age { get; set; }

    public int LengthMin { get; set; }

    public string CoverPath { get; set; } = null!;
}
