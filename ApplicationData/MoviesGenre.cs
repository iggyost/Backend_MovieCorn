using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class MoviesGenre
{
    public int MovieGenreId { get; set; }

    public int MovieId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
