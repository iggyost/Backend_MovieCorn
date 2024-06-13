using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class FavoritesView
{
    public int FavoriteId { get; set; }

    public int MovieId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int ProduceYear { get; set; }

    public int CountryId { get; set; }

    public string Director { get; set; } = null!;

    public string Producer { get; set; } = null!;

    public int Age { get; set; }

    public int LengthMin { get; set; }

    public string CoverPath { get; set; } = null!;
}
