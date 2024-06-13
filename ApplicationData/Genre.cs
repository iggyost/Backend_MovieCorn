using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MoviesGenre> MoviesGenres { get; set; } = new List<MoviesGenre>();
}
