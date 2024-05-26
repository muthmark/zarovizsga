using System;
using System.Collections.Generic;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Location1 { get; set; } = null!;

    public virtual ICollection<Viewpoint> Viewpoints { get; set; } = new List<Viewpoint>();
}
