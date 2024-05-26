using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Location1 { get; set; } = null!;

    public virtual ICollection<Viewpoint> Viewpoints { get; } = new List<Viewpoint>();

    [NotMapped]
    public ICollection<Viewpoint> OrderedViewpoints
    {
        get
        {
            return Viewpoints.OrderByDescending(x=>x.Height).ToList();
        }
    }
}
