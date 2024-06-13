using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? CoverImage { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
