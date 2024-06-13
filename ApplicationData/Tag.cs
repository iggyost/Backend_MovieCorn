using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MoviesTag> MoviesTags { get; set; } = new List<MoviesTag>();
}
