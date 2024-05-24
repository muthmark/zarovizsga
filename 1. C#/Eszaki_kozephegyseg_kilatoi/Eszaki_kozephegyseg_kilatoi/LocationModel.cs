using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi
{
    internal class LocationModel
    {
        public int id { get; set; }
        public string? location { get; set; }

        public LocationModel(string row)
        {
            string[] data = row.Split(';');
            id = int.Parse(data[0]);
            location = data[1];
        }

        public static List<LocationModel> loadLocations(string fileName)
        {
            List<LocationModel> locationModels= new List<LocationModel>();
            foreach (var row in File.ReadAllLines(fileName).Skip(1))
            {
                locationModels.Add(new LocationModel(row));
            }
            return locationModels;
        }
    }
}
