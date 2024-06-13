using System;
using System.Collections.Generic;

namespace Backend_MovieCorn.ApplicationData;

public partial class Country
{
    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
