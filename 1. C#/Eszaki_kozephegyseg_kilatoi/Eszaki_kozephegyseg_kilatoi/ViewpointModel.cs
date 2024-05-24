using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi
{
    internal class ViewpointModel
    {
        // id;viewpointName;mountain;height;description;built;imageUrl;location
        public int id { get; set; }
        public string? viewpointName { get; set; }
        public string? mountain { get; set; }
        public double height { get; set; }
        public string? description { get; set; }
        public DateOnly built { get; set; }
        public string? imageUrl { get; set; }
        public int location { get; set; }

        public ViewpointModel()
        {

        }
        public ViewpointModel(string row)
        {
            string[] data = row.Split(';');
            id = int.Parse(data[0]);    
            viewpointName = data[1];
            mountain = data[2];
            height = double.Parse(data[3].Replace('.',','));
            description = data[4];
            built = DateOnly.Parse(data[5]);
            imageUrl = data[6];
            location = int.Parse(data[7]);
        }

        public static List<ViewpointModel> loadViewpoints(string fileName)
        {
            List<ViewpointModel> ViewpointModels = new List<ViewpointModel>();
            foreach (var row in File.ReadAllLines(fileName).Skip(1))
            {
                ViewpointModels.Add(new ViewpointModel(row));
            }
            return ViewpointModels;
        }
    }
}
