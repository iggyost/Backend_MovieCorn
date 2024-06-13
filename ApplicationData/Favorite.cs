using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int MovieId { get; set; }

    public int UserId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
