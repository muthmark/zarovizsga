using System;
using System.Collections.Generic;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models;

public partial class Viewpoint
{
    public int Id { get; set; }

    public string ViewpointName { get; set; } = null!;

    public string Mountain { get; set; } = null!;

    public double? Height { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? Built { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int Location { get; set; }

    public virtual Location LocationNavigation { get; set; } = null!;
}
