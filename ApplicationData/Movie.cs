using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Name { get; set; } = null!;

    public int ProduceYear { get; set; }

    public int CountryId { get; set; }

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public int Age { get; set; }

    public int LengthMin { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<MoviesCover> MoviesCovers { get; set; } = new List<MoviesCover>();

    public virtual ICollection<MoviesGenre> MoviesGenres { get; set; } = new List<MoviesGenre>();

    public virtual ICollection<MoviesTag> MoviesTags { get; set; } = new List<MoviesTag>();
}
