using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Journeys
{
    public class JourneyModel
    {
        
        public int Id { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public DateTime Departure { get; set; }
        public int? Capacity { get; set; }
        public VehicleModel Vehicle { get; set; }
        public string PictureUrl { get; set; }
        public JourneyModel()
        {

        }
        public JourneyModel(string row)
        {
            string[] data = row.Split(';');
            this.Id = Convert.ToInt32(data[0]);
            this.Vehicle = new VehicleModel() { Id = Convert.ToInt32(data[1]), 
                Type = data[2]};
            this.Country = data[3];
            this.Description = data[4];
            this.Departure = Convert.ToDateTime(data[5]);
            if (data[6] != "")
            {
                this.Capacity = Convert.ToInt32(data[6]);
            } else
            {
                this.Capacity = null;
            }
            this.PictureUrl = data[7];
        }

        public static IEnumerable<JourneyModel> LoadFromCsv(string filename)
        {
            foreach (string row in File.ReadLines(filename).Skip(1))
            {
                yield return new JourneyModel(row);
            }
        }

        public static IEnumerable<JourneyModel> LoadFromJson(string filename)
        {
            return JsonConvert.DeserializeObject<JourneyModel[]>(File.ReadAllText(filename));
        }
    }
}
