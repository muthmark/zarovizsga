using System;
using System.Collections.Generic;

namespace JourneysGUI.Models
{
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            Journeys = new HashSet<JourneyModel>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public int JourneysCount { get
            {
                (App.Current.MainWindow as MainWindow).tac.Entry(this).Collection(s => s.Journeys).Load();
                return Journeys.Count;
            } 
        }
        public virtual ICollection<JourneyModel> Journeys { 
            get; 
            set; 
        }
    }
}
